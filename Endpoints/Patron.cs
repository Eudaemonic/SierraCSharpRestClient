using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SierraCSharpRestClient.Endpoints
{
    class Patron 
    {

        private readonly SierraRestClient _sierraRestClient;

        public Patron()
        {
            _sierraRestClient = new SierraRestClient();


        }

        /// <summary>
        /// Returns a true if barcode is already in the system
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public bool CheckIfBarcodeExists(string barcode)
        {
            var request = _sierraRestClient(ApiEndPoint.patrons,"find", Method.GET);

            request.AddQueryParameter("varFieldTag", "b");
            request.AddQueryParameter("varFieldContent", barcode.Trim());
            request.AddQueryParameter("fields", "id");

            var result = _sierraRestClient.Client.Execute(request);

            if (result.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public string Create(Patron patron)
        {
            var request = _sierraRestClient.RestRequest("patrons/", Method.POST);

            var json = JsonConvert.SerializeObject(patron);

            request.AddParameter("text/json", json, ParameterType.RequestBody);

            var result = _sierraRestClient.Client.Execute(request);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return GetIdFromLink(result.Content);
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns a patron object with certain of the strongly type fields removed from the varFields array
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Patron GetById(int id)
        {
            var request = _sierraRestClient.RestRequest("patrons/" + id, Method.GET);

            request.AddQueryParameter("fields",
                "id,names,barcodes,addresses,expirationDate,patronCodes,varFields,emails,patronType,moneyOwed");
            // execute the request

            IRestResponse<Patron> response2 = _sierraRestClient.Client.Execute<Patron>(request);
            var name = response2.Data;

            var newVarFields = new List<VarField>();
            foreach (var item in name.varFields.ToList())
            {
                if (item.fieldTag == "j")
                {
                    newVarFields.Add(item);
                }
                if (item.fieldTag == "i")
                {
                    newVarFields.Add(item);
                }
                if (item.fieldTag == "y")
                {
                    newVarFields.Add(item);
                }
                if (item.fieldTag == "x")
                {
                    newVarFields.Add(item);
                }
            }

            name.varFields.Clear();
            name.varFields = newVarFields;

            return response2.Data;
        }

        /// <summary>
        /// Returns a full patron objedt with all var fields. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Patron GetById2(int id)
        {
            var request = _sierraRestClient.RestRequest("patrons/" + id.ToString(), Method.GET);


            request.AddQueryParameter("fields",
                "id,names,barcodes,addresses,expirationDate,patronCodes,varFields,emails,patronType,moneyOwed");
            // execute the request

            IRestResponse<Patron> response2 = _sierraRestClient.Client.Execute<Patron>(request);

            return response2.Data;
        }

        /// <summary>
        /// Method accepts the varField tag and returns a single record. 
        /// Returns all fines data for a specified patron record.
        /// </summary>
        /// <param name="varFieldTag"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public Patron GetPatronByVarField(char varFieldTag, string query)
        {
            var request = _sierraRestClient.RestRequest("patrons/find", Method.GET);

            request.AddQueryParameter("varFieldTag", varFieldTag.ToString());
            request.AddQueryParameter("varFieldContent", query);
            request.AddQueryParameter("fields",
                "id,names,barcodes,addresses,expirationDate,patronCodes,varFields,emails,patronType,moneyOwed");
            // execute the request

            IRestResponse<Patron> response2 = _sierraRestClient.Client.Execute<Patron>(request);


            return response2.Data;
        }

        /// <summary>
        /// Get pcode{0} etc
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public PatronMetaData GetPatronMetaData(string code)
        {
            var request = _sierraRestClient.RestRequest("patrons/metadata", Method.GET);

            request.AddQueryParameter("fields", code);

            var response = _sierraRestClient.Client.Execute<PatronMetaData>(request);

            var result = JsonConvert.DeserializeObject<PatronMetaData>(response.Content.Substring(1, response.Content.Length - 2));


            return result;
        }

        /// <summary>
        /// The main search interface. No other endpoint will give you 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Patrons GetPatronsByName(string name, int offset = 0, int limit = 10)
        {
            var query = Regex.Matches(name, @"\b[a-zA-Z]{2,}\b");

            var json = string.Empty;

            if (string.IsNullOrEmpty(name))
                return null;
            if (name.StartsWith("u") && Char.IsDigit(name[1]))
            {
                json = @"{'target':{'record':{'type': 'patron'}, 'field':{'tag': 'u'}}, 'expr':{'op': 'equals', 'operands': [ '" + name.Remove(0, 1) + @"', '']}}";
            }
            else
            {


                if (Char.IsDigit(name[0]))
                {
                    json =
                        @"{'target': {'record': {'type': 'patron'},'field': {'tag': 'b' } }, 'expr': { 'op': 'equals', 'operands': [ '" + name + "', '' ] } }";
                }
                else
                {
                    if (query.Count > 0)
                    {
                        int count = 0;

                        json = @"{'queries': [";

                        foreach (var field in query)
                        {
                            if (count == 0)
                            {
                                json += @"{'target': {'record': {'type': 'patron'},'field': {'tag': 'n' } }, 'expr': { 'op': 'has', 'operands': [ '" + field.ToString() + "', '' ] } }";
                            }
                            else
                            {
                                json += @", 'and' , {'target': {'record': {'type': 'patron'},'field': {'tag': 'n' } }, 'expr': { 'op': 'has', 'operands': [ '" + field.ToString() + "', '' ] } }";
                            }

                            count++;
                        }

                        json += "]}";
                    }
                    else
                    {
                        json =
                            @"{'target': {'record': {'type': 'patron'},'field': {'tag': 'n' } }, 'expr': { 'op': 'has', 'operands': [ '" + name + "', '' ] } }";
                    }
                }
            }

            var patrons = new Patrons();

            var request = _sierraRestClient.RestRequest("patrons/query", Method.POST);


            request.AddParameter("text/json", json, ParameterType.RequestBody);

            request.AddQueryParameter("offset", offset.ToString());

            request.AddQueryParameter("limit", limit.ToString());

            IRestResponse response = _sierraRestClient.Client.Execute(request);

            var result = JsonConvert.DeserializeObject<PatronSearch>(response.Content);

            var results = result.entries;

            if (results.Any())
            {
                var listOfPatrons = new List<Patron>();

                string[] ids = new string[results.Count()];

                var firstSlash = results.FirstOrDefault().link.LastIndexOf("/") + 1;

                if (firstSlash != null)
                {
                    for (var i = 0; i < results.Count(); i++)
                    {
                        ids[i] = results[i].link.Remove(0, firstSlash);
                    }
                }

                return GetListOfPatrons(ids);
            }

            return patrons;
        }

        /// <summary>
        /// Gets account as list of varFields and fixedFields
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Record GetRecord(int id)
        {
            var request = _sierraRestClient.RestRequest("patrons/" + id.ToString(), Method.GET);

            request.AddQueryParameter("fields",
                "id,varFields,fixedFields");
            // execute the request

            IRestResponse<Record> response2 = _sierraRestClient.Client.Execute<Record>(request);

            return response2.Data;
        }

        /// <summary>
        /// Update Patron values
        /// </summary>
        /// <param name="patron">
        /// </param>
        /// <returns>
        /// </returns>
        public void UpdateAccount(Patron patron)
        {
            var request = _sierraRestClient.RestRequest("patrons/" + patron.id.ToString(), Method.PUT);

            var json = JsonConvert.SerializeObject(patron);

            request.AddParameter("text/json", json, ParameterType.RequestBody);

            _sierraRestClient.Client.Execute(request);
        }
        /// <summary>
        /// Returns the properties of patron objects from the submitted array of ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        private Patrons GetListOfPatrons(string[] ids)
        {
            var request = _sierraRestClient.RestRequest("patrons", Method.GET);

            request.AddQueryParameter("id", string.Join(",", ids));

            request.AddQueryParameter("fields",
                "id,names,barcodes,patronCodes");
            // execute the request

            IRestResponse<Patrons> response2 = _sierraRestClient.Client.Execute<Patrons>(request);

            return response2.Data;
        }




        public Fines GetFines(int id)
        {
            var request = _sierraRestClient.RestRequest("patrons/" + id + "/fines", Method.GET);

            IRestResponse<Fines> response = _sierraRestClient.Client.Execute<Fines>(request);

            return response.Data;

        }

        #region StringHelpers

        string GetIdFromLink(string link)
        {
            if (link.Contains('/'))
            {
                return link.Substring(link.LastIndexOf("/") + 1, 7);
            }

            return string.Empty;
        }

        #endregion

  
    }
}
