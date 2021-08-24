using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.Formula.Functions;
using RestSharp;
using System;
using System.Diagnostics;
using System.Windows;

namespace CSharp2
{
    [TestClass]
    public class Post
    {
        private string getURL = "https://reqres.in/";

        [TestMethod]
        public void TestwithsonData()
        {
            string jsonData = "{" +
                                    "\"name\": \"pathak\","+
                                   "\"job\": \"leader\""+
            "}";
                IRestClient restclient = new RestClient(getURL);
              IRestRequest request = new RestRequest("api/users");

            //what format of data sending
            request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("Accept", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(jsonData);
            IRestResponse response = restclient.Post(request);
            Assert.AreEqual(201, (int)response.StatusCode);
            Debug.WriteLine(response.Content);
        }
    }
}
