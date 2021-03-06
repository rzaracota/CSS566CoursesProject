﻿using Backend_Api.Repo_Model;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Api.Repository
{
    public class DocDBRepo: IDocDBRepo
    {
        private static readonly string DatabaseID = "css566";//generally write in config file- SHMA_CRUD id db name
        private static readonly string CollectionID = "items";
        private static readonly string AzureEndPoint = "https://css566.documents.azure.com:443/"; //URI from Key section in Azure cosmos DB setup
        private static readonly string AzureAuthKey = "f3wRntz9c5DuuTd3aLY4M4BE9Vz82tKVC4WNaAVXuF3BCwdsiIdWmIJm7mlHpYscYWdpJcsSTv9JVZMk3BsK0A=="; //Azure primary key from key section COSMOS DB- primary key values
        private static DocumentClient client; //DocumentDB package 

        //Client Initialization
        public void Initialize()
        {
            client = new DocumentClient(new Uri(AzureEndPoint), AzureAuthKey,
                new ConnectionPolicy { EnableEndpointDiscovery = false });//client initialization
            CreateDbIfNotExist().Wait();//create database if it does not exist
            CreateCollectionIfNotExist().Wait(); //create collection if it does not exist.creat async wait version
        }

        //Create collection
        private async Task CreateCollectionIfNotExist()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(
                    UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID));

            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseID),
                        new DocumentCollection { Id = CollectionID },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw ex;
                }
            }
        }

        //Create database
        private async Task CreateDbIfNotExist()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseID));
            }
            catch (DocumentClientException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseID });
                }
            }
        }

        //Create record/document
        public async Task<Document> CreateCourseAsync(Course value)
        {
            return await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID), value);
        }

        public async Task<Document> CreateModuleAsync(Module value)
        {
            return await client.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(DatabaseID, CollectionID), value);
        }

        //Delete Document
        public async Task DeleteCourseAsync(string id)
        {
            var course = await this.GetCourseAsync(id);
            if (course != null)
            {
                await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseID, CollectionID, course.Id));
            }
        }
        public async Task DeleteModuleAsync(string id)
        {
            var module = await this.GetModuleAsync(id);
            if (module != null)
            {
                await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseID, CollectionID, module.Id));
            }
        }

        //Read Module information from database document
        public async Task<Module> GetModuleAsync(string pid)
        {
            var queryS = "SELECT * FROM c WHERE c.ModuleId = @moduleId";
            var pars = new SqlParameterCollection();

            pars.Add(new SqlParameter("@moduleId", pid));

            SqlQuerySpec query = new SqlQuerySpec(queryS, pars);
            FeedOptions option = new FeedOptions() { MaxItemCount = 1000 };
            try
            {
                var querySalesOrder = client.CreateDocumentQuery<Module>
            (UriFactory.CreateCollectionUri(DatabaseID, CollectionID), query, option).AsDocumentQuery();

                var results = await querySalesOrder.ExecuteNextAsync<Module>();
                foreach (var result in results)
                {
                    return result;
                }
            }
            catch (Exception e)
            {

            }
            return null;

        }
        public async Task<Course> GetCourseAsync(string pid)
        {
            var queryS = "SELECT * FROM c WHERE c.CourseId = @courseId";
            var pars = new SqlParameterCollection();

            pars.Add(new SqlParameter("@courseId", pid));

            SqlQuerySpec query = new SqlQuerySpec(queryS, pars);
            FeedOptions option = new FeedOptions() { MaxItemCount = 1000 };
            try
            {
                var querySalesOrder = client.CreateDocumentQuery<Course>
            (UriFactory.CreateCollectionUri(DatabaseID, CollectionID), query, option).AsDocumentQuery();

                var results = await querySalesOrder.ExecuteNextAsync<Course>();
                foreach (var result in results)
                {
                    return result;
                }
            }
            catch (Exception e)
            {

            }
            return null;

        }

        public async Task<List<Course>> GetAllCourseAsync()
        {
            List<Course> courses = new List<Course>();
            var queryS = "SELECT * FROM c WHERE c.Doctype = @course";
            var pars = new SqlParameterCollection();

            pars.Add(new SqlParameter("@course", "Course"));

            SqlQuerySpec query = new SqlQuerySpec(queryS, pars);
            FeedOptions option = new FeedOptions() { MaxItemCount = 1000 };
            try
            {
                var querySalesOrder = client.CreateDocumentQuery<Course>
            (UriFactory.CreateCollectionUri(DatabaseID, CollectionID), query, option).AsDocumentQuery();

                var results = await querySalesOrder.ExecuteNextAsync<Course>();
                foreach (var result in results)
                {
                    courses.Add(result);
                }

                return courses;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public async Task<List<Module>> GetAllModuleAsync()
        {
            List<Module> modules = new List<Module>();
            var queryS = "SELECT * FROM c WHERE c.Doctype = @module";
            var pars = new SqlParameterCollection();

            pars.Add(new SqlParameter("@module", "Module"));

            SqlQuerySpec query = new SqlQuerySpec(queryS, pars);
            FeedOptions option = new FeedOptions() { MaxItemCount = 1000 };
            try
            {
                var querySalesOrder = client.CreateDocumentQuery<Module>
            (UriFactory.CreateCollectionUri(DatabaseID, CollectionID), query, option).AsDocumentQuery();

                var results = await querySalesOrder.ExecuteNextAsync<Module>();
                foreach (var result in results)
                {
                    modules.Add(result);
                }

                return modules;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public async Task<Document> UpdateCourseAsync(string id, Course value)
        {
            // retrieve the document ID
            Course dataModel = await GetCourseAsync(id);
            value.Id = dataModel.Id;
            return await client.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(DatabaseID, CollectionID, dataModel.Id),
                value);
        }

        public async Task<Document> UpdateModuleAsync(string id, Module value)
        {
            // retrieve the document ID
            Module dataModel = await GetModuleAsync(id);
            value.Id = dataModel.Id;
            return await client.ReplaceDocumentAsync(
                UriFactory.CreateDocumentUri(DatabaseID, CollectionID, dataModel.Id), 
                value);
        }
    }
}
