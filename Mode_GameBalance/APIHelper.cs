using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace Model_GameBalance
{
    public class APIHelper<t>
    {
        public IRestClient restClient;
        public IRestRequest restRequest;
        public string baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseURL"];
        //public string baseUrl = "https://reqres.in/";

        public IRestClient SetUrl(string endpoint)
        {

            var url = Path.Combine(baseUrl, endpoint);
            restClient = new RestClient(url);
            return restClient;
        }

        public IRestRequest UserTokenPost(string body)
        {
            string CorrelationId = System.Configuration.ConfigurationManager.AppSettings["X-CorrelationId"];
            string Forwarded = System.Configuration.ConfigurationManager.AppSettings["X-Forwarded-For"];
            string Clienttypeid = System.Configuration.ConfigurationManager.AppSettings["X-Clienttypeid"];
            restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("X-CorrelationId", CorrelationId);
            restRequest.AddHeader("X-Forwarded-For", Forwarded);
            restRequest.AddHeader("X-Clienttypeid", Clienttypeid);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("application/json", body, ParameterType.RequestBody);
            return restRequest;
        }

        public IRestRequest VerifyPostBody(string body, string token)
        {
            //app config properties
            string moduleID = System.Configuration.ConfigurationManager.AppSettings["moduleID1"];
            string clientID = System.Configuration.ConfigurationManager.AppSettings["clientID1"];
            string Clienttypeid = System.Configuration.ConfigurationManager.AppSettings["X-Clienttypeid1"];
            string CorrelationId = System.Configuration.ConfigurationManager.AppSettings["X-CorrelationId1"];
            string XProductId = System.Configuration.ConfigurationManager.AppSettings["X-Route-ProductId"];
            string XModuleId = System.Configuration.ConfigurationManager.AppSettings["X-Route-ModuleId"];

            restRequest = new RestRequest(Method.POST);
            restRequest.AddParameter("moduleID", moduleID);
            restRequest.AddParameter("clientID", clientID);
            restRequest.AddHeader("Authorization", "Bearer " + token);
            restRequest.AddHeader("X-Clienttypeid", Clienttypeid);
            restRequest.AddHeader("X-CorrelationId", CorrelationId);
            restRequest.AddHeader("X-Route-ProductId", XProductId);
            restRequest.AddHeader("X-Route-ModuleId", XModuleId);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("application/json", body, ParameterType.RequestBody);
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

        public string Serialize(dynamic content)
        {
            string serializeobject = JsonConvert.SerializeObject(content,Formatting.Indented);
            return serializeobject;
        }
    }
}
