using NUnit.Framework;
using System.Diagnostics;

namespace Model_GameBalance
{
    public class Logic<T>
    {

        public Create_postDTO TestPOST(string endpoint, dynamic jsonData)
        {
            
        var user = new APIHelper<Create_postDTO>();
            var url = user.SetUrl(endpoint);
            var jsonReq = user.Serialize(jsonData);
            var request = user.UserTokenPost(jsonReq);
            var response = user.GetResponse(url, request);
            Assert.AreEqual(201, (int)response.StatusCode);
           // Debug.WriteLine(response.Content);
            Create_postDTO content = user.Deserialize<Create_postDTO>(response);
            return content;
        }

        public Response_postDTO ResponseValidationPOST(string endpoint, dynamic jsonData, string tokens)
        {
            var user = new APIHelper<Create_postDTO>();
            var url = user.SetUrl(endpoint);
            var jsonReq = user.Serialize(jsonData);
            var request = user.VerifyPostBody(jsonReq, tokens);
            var response = user.GetResponse(url, request);
            Assert.AreEqual(201, (int)response.StatusCode);
            //Debug.WriteLine(response.Content);
            Response_postDTO content = user.Deserialize<Response_postDTO>(response);
            return content;
        }
    }
}