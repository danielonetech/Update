using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace CSharpFinal
{
    public class APIHelper<t>
    {
        public IRestClient restClient;
        public IRestRequest restRequest;
        public string baseUrl = "https://reqres.in/";

        public IRestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            restClient = new RestClient(url);
            return restClient;
        }

        public IRestRequest CreatePost(string body)
        {
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", body, ParameterType.RequestBody);
            return restRequest;
        }

        public IRestRequest CreatePut(string body)
        {
            restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", body, ParameterType.RequestBody);
            return restRequest;
        }

        public IRestRequest CreateGet()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestRequest CreateDelete()
        {
            restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestResponse GetResponse(IRestClient client,IRestRequest request)
        {
            return client.Execute(request);
        }

        public DTO Deserialize<DTO>(IRestResponse response)
        {
            var content = response.Content;
            DTO dt = JsonConvert.DeserializeObject<DTO>(content);
            return dt;
        }
    }
}
