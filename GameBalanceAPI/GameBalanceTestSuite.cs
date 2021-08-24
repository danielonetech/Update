

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model_GameBalance;
using NUnit.Framework;
using System.Diagnostics;
using Assert = NUnit.Framework.Assert;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace GameBalanceAPI
{
    [TestFixture]
    public class GameBalanceTestSuite
    {
        public string tokens;
        public TestContext testContextInstance { get; set; }
        [DeploymentItem("TestData\\TestDataSet.csv"),
            DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestDataSet.csv", "TestDataSet#csv",
            DataAccessMethod.Sequential)]
        [Test]
        public void StoreUserToken_POST()
        {
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
            users.userName = testContextInstance.DataRow["userName"].ToString();
            var demo = new Logic<Create_postDTO>();
            var user = demo.TestPOST("v1/accounts/login/real", users);
            tokens = user.tokens.userToken;
        }

        [Test]
        public void VerifyResponseBody_POST()
        {
            string jsonData =    "{"+
                                    "\"packet\": \"{"+
                                    "\"packetType\": \"7\","+
                                    "\"payload\": \"<Pkt version='6'><Id mid='{{MID}}' cid='{{CID}}' sid='{{PID}}' sessionid='' verb='AdvSlot' clientLang='en'/><Request verbex='Refresh'/></Pkt>\","+
                                    "\"useFilter\": \"true\","+
                                    "\"isBase64Encoded\": \"false\""+
                                     "}\""+
                                "}";


            var demo = new Logic<Response_postDTO>();
            var user = demo.ResponseValidationPOST("v1/games/module/{moduleID}/client/{clientID}/play", jsonData , tokens);
            var financialbalance =user.context.balances.totalInAccountCurrency;
            bool b1 = Microsoft.VisualBasic.Information.IsNumeric(financialbalance);
            if(b1)
                Debug.WriteLine("Responce is numeric");
            else
                Debug.WriteLine("Responce is not numeric");
        }
    }
}
