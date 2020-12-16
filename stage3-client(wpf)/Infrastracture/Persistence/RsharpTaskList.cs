using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Domain.Models;
using RestSharp;

namespace Infrastracture.Persistence
{
    public class RsharpTaskList
    {
        Client Clients = new Client();
        RestClient restClient = new RestClient();
        RestRequest request = new RestRequest();

        public string _request = "api/tasklist/";
        public TaskList TaskLists { get; set; }

        public RsharpTaskList()
        {
            restClient = new RestClient(Clients.client);
        }

        public IEnumerable<TaskList> GetRequest()
        {
            request = new RestRequest(_request, Method.GET);
            var queryResult = restClient.Execute<List<TaskList>>(request).Data;
            return queryResult;
        }

        public void PostRequest(TaskList entity)
        {
            request = new RestRequest(_request, Method.POST);
            MakeRequest(entity);
        }

        public void PutRequest(TaskList entity)
        {
            request = new RestRequest(_request, Method.PUT);
            MakeRequest(entity);
        }

        public void DeleteRequest(TaskList entity)
        {
            request = new RestRequest(_request + entity.idTask, Method.DELETE);
            MakeRequest(entity);
        }

        public void MakeRequest(TaskList entity)
        {
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(entity);
            request.AddParameter("Application/Json", entity, ParameterType.RequestBody);
            restClient.Execute(request);
        }

    }
}
