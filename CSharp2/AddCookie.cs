using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Diagnostics;
using System.Windows;

namespace CSharp2
{
    [TestClass]
    public class AddCookie
    {

        private const string BaseUrl = "http://steamcommunity.com/market/search/render/";

        [TestMethod]
        public void Search()
    {
        IRestClient restClient = new RestClient(BaseUrl);

        IRestRequest request = new RestRequest("/", Method.GET);
        request.AddHeader("Accept", "*/*");
        request.AddHeader("Accept-Enclding", "gzip,deflat,sdch");
        request.AddHeader("Cache-Control", "no-cache");
        request.AddHeader("HOST", "steamcommunity.com");

        request.AddCookie("__ngDebug", "false");
        request.AddCookie("Steam_Language", "english");
        request.AddCookie("sessionid", "MTE3OTk1OTgyNQ");
        request.AddCookie("steamCC_67_167_177_70", "US");
        request.AddCookie("__utma", "268881843.805413192.1378770011.1382167972.1382171160.10");
        request.AddCookie("__utmb", "268881843.1.10.1382171160");
        request.AddCookie("__utmc", "268881843");
        request.AddCookie("__utmz", "268881843.1382171160.10.6.utmcsr=google|utmccn=(organic)|utmcmd=organic|utmctr=(not provided)");
        //request.AddCookie("timezoneOffset", "-14400,0");

        //request.Timeout = 5*1000;
        request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36");

        IRestResponse response = restClient.Get(request);
        Debug.WriteLine(response.Content);
        Debug.WriteLine((int)response.StatusCode);
    }
}
}