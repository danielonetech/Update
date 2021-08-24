using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.Formula.Functions;
using RestSharp;
using System;
using System.Diagnostics;
using System.Windows;

namespace CSharp2
{
    [TestClass]
    public class Parameter_Delete
    {
        private string getURL = "https://reqres.in/api/";

        [TestMethod]
        public void SampleDeleteRequ()
        {
            IRestClient restClient = new RestClient(getURL);
            IRestRequest restRequest = new RestRequest("users/{id}", Method.DELETE);
            restRequest.AddParameter("id", "2");
            IRestResponse restResponse = restClient.Delete(restRequest);
            Console.WriteLine(restResponse.IsSuccessful);
            Console.WriteLine(restResponse.StatusCode);
            int StatusCode = (int)restResponse.StatusCode;
            Assert.AreEqual(204, StatusCode, "Status code is not 200");
            Console.WriteLine(restResponse.ErrorMessage);
            Console.WriteLine(restResponse.ErrorException);
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("response body " + restResponse.Content);
            }
        }
    }
}
