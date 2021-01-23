using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Domain.Models;
using RestSharp;

namespace Infrastracture.Persistence
{
    public class ItemRest
    {
        Client Clients = new Client();
        RestClient restClient = new RestClient();
        RestRequest request = new RestRequest();

        public string _request = "api/itemlist/";
        public ItemModel Items { get; set; }

        public ItemRest()
        {
            restClient = new RestClient(Clients.client);
        }

        public IEnumerable<ItemModel> GetRequest()
        {
            request = new RestRequest(_request, Method.GET);
            var queryResult = restClient.Execute<List<ItemModel>>(request)
                .Data;
            return queryResult;
        }

        public ItemModel GetByIdRequest(int entity)
        {
            request = new RestRequest(_request + "{IdItem}", Method.GET);
            request.AddUrlSegment("IdItem", entity);

            var queryResult = restClient.Execute<ItemModel>(request).Data;
            return queryResult;
        }


        public void PostRequest(ItemModel entity)
        {
            request = new RestRequest(_request, Method.POST);
            MakeRequest(entity);
        }

        public void PutRequest(ItemModel entity)
        {
            request = new RestRequest(_request, Method.PUT);
            MakeRequest(entity);
        }

        public void DeleteRequest(int entity)
        {
            request = new RestRequest(_request + "{IdItem}", Method.DELETE);
            request.AddUrlSegment("IdItem", entity);
            restClient.Execute<ItemModel>(request);
        }

        public void MakeRequest(ItemModel entity)
        {
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(entity);
            request.AddParameter("Application/Json", entity, ParameterType.RequestBody);
            restClient.Execute(request);
        }

    }
}

