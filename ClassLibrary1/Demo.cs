using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFinal
{
    public class Demo<T>
    {
       
        public ResponseGETDTO CheckGET(string endpoint)
        {
            var user = new APIHelper<ResponseGETDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGet();
            var response = user.GetResponse(url, request);
            Assert.AreEqual(200, (int)response.StatusCode);
            Debug.WriteLine(response.Content);
            ResponseGETDTO content = user.Deserialize<ResponseGETDTO>(response);
            return content;

            //var restclient = new RestClient("https://reqres.in/");
            //var request = new RestRequest("api/users?page=2", Method.GET);

            //what format of data sending
            //request.AddHeader("Content-Type", "application/json");
            //request.RequestFormat = DataFormat.Json;
            //request.AddHeader("Accept", "application/json");

            //IRestResponse response = restclient.Execute(request);
            //Assert.AreEqual(200, (int)response.StatusCode);
            //Debug.WriteLine(response.Content);

            //var content = response.Content;
            //var users = JsonConvert.DeserializeObject<ResponseGETDTO>(content);
            //return users;
        }

        //public Create_postDTO TestPOST()
        //{
        //    var restclient = new RestClient("https://reqres.in/");
        //    var request = new RestRequest("api/users?page=2", Method.GET);

        //    //what format of data sending
        //    request.AddHeader("Content-Type", "application/json");
        //    //request.RequestFormat = DataFormat.Json;
        //    request.AddHeader("Accept", "application/json");

        //    IRestResponse response = restclient.Execute(request);
        //    Assert.AreEqual(200, (int)response.StatusCode);
        //    Debug.WriteLine(response.Content);

        //    var content = response.Content;
        //    var users = JsonConvert.DeserializeObject<Create_postDTO>(content);
        //    return users;
        //}

        public Create_postDTO TestPOST(string endpoint, string jsonData)
        {
            var user = new APIHelper<Create_postDTO>();
            var url = user.SetUrl(endpoint);
            var request = user.CreatePost(jsonData);
            var response = user.GetResponse(url, request);
            Assert.AreEqual(201, (int)response.StatusCode);
            Debug.WriteLine(response.Content);
            Create_postDTO content = user.Deserialize<Create_postDTO>(response);
            return content;
        }
    }
}