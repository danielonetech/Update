using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model_GameBalance;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace GameBalance_API
{
    [TestClass]
    public class GameBalanceTestSuite
    {
        public string tokens;
        public TestContext TestContext { get; set; }
        [DeploymentItem("TestData\\TestDataSet.csv"),
            DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestDataSet.csv", "TestDataSet#csv",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void StoreUserToken_POST()
        {
            string endpointURL = System.Configuration.ConfigurationManager.AppSettings["endPointofToken"];
            //string jsonData = "{" +
            //                        "\"environment\": \"{" +
            //                         "\"clientTypeId\": \"5\"," +
            //                        "\"languageCode\": \"en\"" +
            //                    "}\"," +
            //                        "\"userName\": \"{{userName}}\"," +
            //                        "\"password\": \"{{password}}\"," +
            //                        "\"sessionProductId\": \"{ { productID} }\"," +
            //                        "\"numLaunchTokens\": \"1\"," +
            //                        "\"marketType\": \"{{mmarket}}\"" +
            //                    "}";
            var users = new CreateRequestToken_DTO();
            var users1 = new Model_GameBalance.Environment();
            users.userName = TestContext.DataRow["UserName"].ToString();
            users.password = TestContext.DataRow["Password"].ToString();
            users.sessionProductId = TestContext.DataRow["sessionProductId"].ToString();
            users.marketType = TestContext.DataRow["marketType"].ToString();
            users.numLaunchTokens = (int)TestContext.DataRow["numLaunchTokens"] ;
            users1.clientTypeId = (int)TestContext.DataRow["clientTypeId"];
            users1.languageCode = TestContext.DataRow["languageCode"].ToString();
            users.environment = users1;
            var demo = new Logic<Create_postDTO>();
            var user = demo.TestPOST(endpointURL, users);
            tokens = user.tokens.userToken;
        }

        [TestMethod]
        public void VerifyResponseBody_POST()
        {
            string MID = System.Configuration.ConfigurationManager.AppSettings["mid"];
            string CID = System.Configuration.ConfigurationManager.AppSettings["cid"];
            string SID = System.Configuration.ConfigurationManager.AppSettings["sid"];
            string sessionID = System.Configuration.ConfigurationManager.AppSettings["sessionid"];
            string jsonData = "{" +
                                    "\"packet\": {" +
                                    "\"packetType\": 7," +
                                    "\"payload\": \"<Pkt version='6'><Id mid='" + MID + "' cid='" + CID + "' sid='" + SID + "' sessionid='"+ sessionID +"' verb='AdvSlot' clientLang='en'/><Request verbex='Refresh'/></Pkt>\"," +
                                    "\"useFilter\": true," +
                                    "\"isBase64Encoded\": false" +
                                    "}" +
                             "}";
            //string jsonData = "{" + string.Format("\"packet\": {" +
            //    "\"packetType\": 7," +
            //    "\"payload\": \"<Pkt version='6'><Id mid='{0}' cid='{1}' sid='{2}' sessionid='{3}' verb='AdvSlot' clientLang='en'/><Request verbex='Refresh'/></Pkt>\"," +
            //    "\"useFilter\": true," +
            //    "\"isBase64Encoded\": false}", MID, CID, SID, sessionID) + "}";


            var demo = new Logic<Response_postDTO>();
            var user = demo.ResponseValidationPOST("v1/games/module/{moduleID}/client/{clientID}/play", jsonData , tokens);
            var financialbalance =user.context.balances.totalInAccountCurrency;
            Type b=financialbalance.GetType();
            //bool b1 = Microsoft.VisualBasic.Information.IsNumeric(financialbalance);
            Assert.IsTrue(Regex.IsMatch(Convert.ToString(financialbalance), "^[0-9]+$"));
            if (b.Equals(typeof(string))) 
                Debug.WriteLine("Responce is not numeric");
            else
                Debug.WriteLine("Responce is numeric");
        }
    }
}
