using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Domain.Models;
using RestSharp;

namespace Infrastracture.Persistence
{
    public class RsharpItem
    {
        Client Clients = new Client();
        RestClient restClient = new RestClient();
        RestRequest request = new RestRequest();

        public string _request = "api/itemlist/";
        public Item Items { get; set; }

        public RsharpItem()
        {
            restClient = new RestClient(Clients.client);
        }

        public IEnumerable<Item> GetRequest()
        {
            request = new RestRequest(_request, Method.GET);
            var queryResult = restClient.Execute<List<Item>>(request).Data;
            return queryResult;
        }

        public void PostRequest(Item entity)
        {
            request = new RestRequest(_request, Method.POST);
            MakeRequest(entity);
        }

        public void PutRequest(Item entity)
        {
            request = new RestRequest(_request, Method.PUT);
            MakeRequest(entity);
        }

        public void DeleteRequest(Item entity)
        {
            request = new RestRequest(_request + entity.IdItem, Method.DELETE);
            MakeRequest(entity);
        }

        public void MakeRequest(Item entity)
        {
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(entity);
            request.AddParameter("Application/Json", entity, ParameterType.RequestBody);
            restClient.Execute(request);
        }

    }
}

