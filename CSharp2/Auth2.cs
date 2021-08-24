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
    public class Auth2
    {
        private string getURL = "http://example.com";

        [TestMethod]
        public void TestAuth2()
        {
            IRestClient restclient = new RestClient(getURL);
            restclient.Authenticator = new SimpleAuthenticator("username", "foo", "password", "bar");

            IRestRequest request = new RestRequest();
            IRestResponse response = restclient.Get(request);

            //what format of data sending
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            Assert.AreEqual(200, (int)response.StatusCode);
            Debug.WriteLine(response.Content);
        }
    }
}
