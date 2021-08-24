using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.Formula.Functions;
using RestSharp;
using System;
using System.Diagnostics;
using System.Windows;

namespace CSharp2
{
    [TestClass]
    public class Put_Delete
    {
        private string getURL = "https://reqres.in/";

        [TestMethod]
        public void Test()
        {
            string jsonData = "{" +
                                    "\"name\": \"pathak\","+
                                    "\"job\": \"Tester\""+
            "}";
            IRestClient restclient = new RestClient(getURL);
            IRestRequest request = new RestRequest("api/users/2");

            //what format of data sending
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddJsonBody(jsonData);

            IRestResponse response = restclient.Put(request);
            //IRestResponse<JsonRootOject> restResponsel = restclient.Put<JsonRootObject>(request);
           // Assert.IsTrue(restResponse1.Deto.Features.Feature.Conteins("New feature"), "Feature did not got updated");
            Assert.AreEqual(200, (int)response.StatusCode);
            Debug.WriteLine(response.Content);

            //DELETE Method
            IRestResponse response1 = restclient.Delete(request);
            Assert.AreEqual(204, (int)response1.StatusCode);
            int code = (int)response1.StatusCode;
            Debug.WriteLine(code);
        }
    }
}
