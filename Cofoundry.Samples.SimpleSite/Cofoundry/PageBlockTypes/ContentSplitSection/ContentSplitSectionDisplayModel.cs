﻿using Cofoundry.Domain;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cofoundry.Samples.SimpleSite
{
    /// <summary>
    /// Each blcck type must have a display model that is marked with
    /// IPageBlockTypeDisplayModel. This is the model that is rendered 
    /// in the view. In simple scenarios you can simply mark up the data 
    /// model as the display model, but here we want to transform the 
    /// HtmlText property so we need to define a separate model.
    /// 
    /// See https://github.com/cofoundry-cms/cofoundry/wiki/Page-Block-Types
    /// for more information
    /// </summary>
    public class ContentSplitSectionDisplayModel : IPageBlockTypeDisplayModel
    {
        public string Title { get; set; }

        public IHtmlContent HtmlText { get; set; }

        public ImageAssetRenderDetails Image { get; set; }
    }
}