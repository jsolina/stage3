using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Domain.Models;
using RestSharp;

namespace Infrastracture.Persistence
{
    public class TaskListRest
    {
        Client Clients = new Client();
        RestClient restClient = new RestClient();
        RestRequest request = new RestRequest();

        public string _request = "api/tasklist/";
        public TaskListModel TaskLists { get; set; }

        public TaskListRest()
        {
            restClient = new RestClient(Clients.client);
        }

        public IEnumerable<TaskListModel> GetRequest()
        {
            request = new RestRequest(_request, Method.GET);
            var queryResult = restClient.Execute<List<TaskListModel>>(request).Data;
            return queryResult;
        }


        public TaskListModel GetByIdRequest(int entity)
        {
            request = new RestRequest(_request +"{IdTask}", Method.GET);
            request.AddUrlSegment("IdTask", entity);

            var queryResult = restClient.Execute<TaskListModel>(request).Data;
            return queryResult;
        }

        public void PostRequest(TaskListModel entity)
        {
            request = new RestRequest(_request, Method.POST);
            MakeRequest(entity);
        }

        public void PutRequest(TaskListModel entity)
        {
            request = new RestRequest(_request, Method.PUT);
            MakeRequest(entity);
        }

        public void DeleteRequest(int entity)
        {
            request = new RestRequest(_request +"{IdTask}", Method.DELETE);
            request.AddUrlSegment("IdTask", entity);
            restClient.Execute<TaskListModel>(request);
        }

        public void MakeRequest(TaskListModel entity)
        {
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(entity);
            request.AddParameter("Application/Json", entity, ParameterType.RequestBody);
            restClient.Execute(request);
        }

    }
}
