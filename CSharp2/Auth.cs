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
    public class Auth
    {
        private string getURL = "http://httpbin.org/#/basic-auth";

        [TestMethod]
        public void TestAuth()
        {
            IRestClient restclient = new RestClient(getURL);
            restclient.Authenticator = new HttpBasicAuthenticator("user", "passwd");
            IRestRequest request = new RestRequest();


            //what format of data sending
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            IRestResponse response = restclient.Get(request);
            Assert.AreEqual(200, (int)response.StatusCode);
            Debug.WriteLine(response.Content);
        }
    }
}
