using System;
using RestSharp;
using System.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace ApiFramework
{
    public class ApiHelper
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        private IRestResponse _restResponse;
        private string _apiUrl;
        public string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];

        public string SetApiEndpoint(string partUrl)
        {
            _apiUrl = BaseUrl + partUrl;
            return _apiUrl;
        }

        public RestRequest MakeAGetRequest()
        {
            _restRequest = new RestRequest(Method.GET);
            return _restRequest;
        }

        public RestRequest MakeAPostRequest(string jsonString)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            return _restRequest;
        }

        public IRestResponse GetResponse()
        {
            _restClient = new RestClient(_apiUrl);
            _restResponse = _restClient.Execute(_restRequest);
            return _restResponse;
        }

        public T DeserializeJsonObject<T>(string response) where T : BaseClass, new()
        {
            return JsonConvert.DeserializeObject<T>(response);
        }

        private IConfiguration GetConfig()
        {
            var filePath = AppContext.BaseDirectory;

            var builder = new ConfigurationBuilder()
                .AddJsonFile("configuration.json")
                .Build();
            return builder;
        }
    }
}
