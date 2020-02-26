using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using SierraCSharpRestClient.Enums;
using SierraCSharpRestClient.Interfaces;
using SierraCSharpRestClient.Models;
using SierraCSharpRestClient.Models.BibSubset;

namespace SierraCSharpRestClient.Concretes
{
    public class BibsApiStronglyTyped : IBibsApiStronglyTyped
    {
        private readonly IBibsApi _bibsApi;

        public BibsApiStronglyTyped(ISierraRestClient sierraRestClient)
        {
            _bibsApi = new BibsApi(sierraRestClient);
        }

        public BibsModel GetById(int id, string[] fields = null)
        {
            var bib = _bibsApi.GetById(id, fields);

            return JsonConvert.DeserializeObject<BibsModel>(bib); ;

        }

        public SimpleBib GetBasicModelById(int id, string[] fields = null)
        {
            var bib = _bibsApi.GetById(id, fields);

            return JsonConvert.DeserializeObject<SimpleBib>(bib); ;

        }

        public BibSearchModel Search(Indexes index,  string query, string[] fields = null, int limit = 20)
        {


            //var reader = new JsonTextReader(new StringReader("noul"));

             var JavaScriptSerializer = new JavaScriptSerializer();

             return JavaScriptSerializer.Deserialize<BibSearchModel>(_bibsApi.Search(index, query, fields, limit));

            //var response = new BibSearchModel();
            //var entries = new List<Entry>();
            //var currentProp = string.Empty;
           
            //while (reader.Read())
            //{
            //    if (reader.Value != null)
            //    {
            //        var entry = new Entry();
            //        var bib = new Bib();

            //        //Get property name
            //        if (reader.TokenType == JsonToken.PropertyName)
            //            currentProp = reader.Value.ToString();


            //        if (reader.TokenType == JsonToken.String && currentProp == "id")
            //            bib.id = reader.Value.ToString();

            //        if (reader.TokenType == JsonToken.String && currentProp == "title")
            //            bib.title = reader.Value.ToString();

            //        if (reader.TokenType == JsonToken.String && currentProp == "author")
            //            bib.author = reader.Value.ToString();

            //        if (reader.TokenType == JsonToken.Integer && currentProp == "publishYear")
            //            bib.publishYear = Int32.Parse(reader.Value.ToString());

            //        if (reader.TokenType == JsonToken.String && currentProp == "id")
            //            bib.id = reader.Value.ToString();
            //    }
            //}

            //return response;
        }


    }
}
