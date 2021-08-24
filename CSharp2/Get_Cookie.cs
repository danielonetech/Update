using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Diagnostics;
using System.Windows;

namespace CSharp2
{
    [TestClass]
    public class Get_Cookie
    {
        private string getURL = "https://searchconsole.googleapis.com/$discovery/rest?version=v1";
        Random rand = new Random();

        [TestMethod]
        public void TestGetEndpoint()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(getURL);

            restRequest.AddHeader("Accept", "application/xml");
            restRequest.AddCookie("QA","Test");
            // to get response
            IRestResponse restResponse = restClient.Get(restRequest);
            Debug.WriteLine(restResponse.IsSuccessful);
            Debug.WriteLine(restResponse.StatusCode);
            Debug.WriteLine(restResponse.ErrorMessage);
            // to retreive the complete Stack Trace error.
            Debug.WriteLine(restResponse.ErrorException);
            // to Grab the resonse body or content
            if (restResponse.IsSuccessful)
            {
                Debug.WriteLine("Response Content " + restResponse.Content);
                //MessageBox.Show("ParentHello");
            }
            else
            {
                Debug.WriteLine("Unsuccessfully");
                MessageBox.Show("Hello");
            }
        }
        public static void Main()
        {
        //    Get a = new Get();
        //    Post b = new Post();
        //    Put_Delete c = new Put_Delete();
        //    Auth d = new Auth();
        //    Auth2 e = new Auth2();
        //    Example f = new Example();
        //    a.TestGetEndpoint();
        //    b.TestwithsonData();
        //    c.Test();
        //    d.TestAuth();
        //    e.TestAuth2();
        //    f.SampleDeleteRequ();
        }
    }
}
