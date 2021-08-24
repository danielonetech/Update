using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.Formula.Functions;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Diagnostics;
using System.Windows;

namespace CSharp2
{
    [TestClass]
    public class Bearer
    {
        private string getURL = "https://api.github.com/user/repos";
        private string token = "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";

        [TestMethod]
        public void BearToken()
        {
            string jsonData = "{" +
                                    "\"name\": \"GetPower\"," +
                                   "\"description\": \"Update\"" +
            "}";

            IRestClient restclient = new RestClient(getURL);
            IRestRequest request = new RestRequest();


            //what format of data sending
            request.AddHeader("Authorization","Bearer "+ token);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(jsonData);

            IRestResponse response = restclient.Post(request);
            Assert.AreEqual(201, (int)response.StatusCode);
            Debug.WriteLine(response.Content);
        }
    }
}
