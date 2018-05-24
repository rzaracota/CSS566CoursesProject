﻿using Cofoundry.Core;
using Cofoundry.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofoundry.Samples.SimpleSite
{
    public class BlogPostListViewComponent : ViewComponent
    {
        private readonly ICustomEntityRepository _customEntityRepository;
        private readonly IImageAssetRepository _imageAssetRepository;

        public BlogPostListViewComponent(
            ICustomEntityRepository customEntityRepository,
            IImageAssetRepository imageAssetRepository
            )
        {
            _customEntityRepository = customEntityRepository;
            _imageAssetRepository = imageAssetRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // ModelBinder is not supported in view components so we have to bind
            // this manually. We have an issue open to try and improve the experience here
            // https://github.com/cofoundry-cms/cofoundry/issues/125
            var webQuery = new SearchBlogPostsQuery();
            webQuery.PageNumber = IntParser.ParseOrDefault(Request.Query[nameof(webQuery.PageNumber)]);
            webQuery.PageSize = IntParser.ParseOrDefault(Request.Query[nameof(webQuery.PageSize)]);
            webQuery.CategoryId = IntParser.ParseOrDefault(Request.Query[nameof(webQuery.CategoryId)]);

            var query = new SearchCustomEntityRenderSummariesQuery();
            query.CustomEntityDefinitionCode = BlogPostCustomEntityDefinition.DefinitionCode;
            query.PageNumber = webQuery.PageNumber;
            query.PageSize = 30;
            query.PublishStatus = PublishStatusQuery.Published;

            // TODO: Filtering by Category (webQuery.CategoryId)
            // Searching/filtering custom entities is not implemented yet, but it
            // is possible to build your own search index using the message handling
            // framework or writing a custom query against the UnstructuredDataDependency table
            // See issue https://github.com/cofoundry-cms/cofoundry/issues/12

            var entities = await _customEntityRepository.SearchCustomEntityRenderSummariesAsync(query);
            var viewModel = await MapBlogPostsAsync(entities);

            return View(viewModel);
        }

        private async Task<PagedQueryResult<BlogPostSummary>> MapBlogPostsAsync(PagedQueryResult<CustomEntityRenderSummary> customEntityResult)
        {
            var blogPosts = new List<BlogPostSummary>(customEntityResult.Items.Count());

            var imageAssetIds = customEntityResult
                .Items
                .Select(i => (BlogPostDataModel)i.Model)
                .Select(m => m.ThumbnailImageAssetId)
                .Distinct();

            var images = await _imageAssetRepository.GetImageAssetRenderDetailsByIdRangeAsync(imageAssetIds);

            foreach (var customEntity in customEntityResult.Items)
            {
                var model = (BlogPostDataModel)customEntity.Model;

                var blogPost = new BlogPostSummary();
                blogPost.Title = customEntity.Title;
                blogPost.ShortDescription = model.ShortDescription;
                blogPost.ThumbnailImageAsset = images.GetOrDefault(model.ThumbnailImageAssetId);
                blogPost.FullPath = customEntity.PageUrls.FirstOrDefault();
                blogPost.PostDate = customEntity.PublishDate;

                blogPosts.Add(blogPost);
            }

            return customEntityResult.ChangeType(blogPosts);
        }
    }
}
