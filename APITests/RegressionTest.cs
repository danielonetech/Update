using CSharpFinal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace APITests
{
    [TestClass]
    public class RegressionTest
    {
        [TestMethod]
        public void VerifyGetResponse()
        {
            var demo = new Demo<ResponseGETDTO>();
            var response1 = demo.CheckGET("api/users?page=2");
            Assert.AreEqual(2, response1.page);
            Assert.AreEqual("Michael", response1.data[0].first_name);
            Assert.AreEqual("Lawson", response1.data[0].last_name);
            Assert.AreEqual(7, response1.data[0].id);
            Assert.AreEqual("michael.lawson@reqres.in", response1.data[0].email);
            Assert.AreEqual(2, response1.total_pages);

        }

        [TestMethod]
        public void VerifyPostResponse()
        {
            string jsonData = "{" +
                                    "\"name\": \"pathak\"," +
                                   "\"job\": \"leader\"" +
            "}";
            var demo = new Demo<Create_postDTO>();
            var user = demo.TestPOST("api/users", jsonData);

            Assert.AreEqual("pathak", user.name);
            Assert.AreEqual("leader", user.job);
        }
    }
}
