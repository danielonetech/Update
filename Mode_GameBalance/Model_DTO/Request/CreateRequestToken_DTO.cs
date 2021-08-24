using System.Collections.Generic;

namespace Model_GameBalance
{
    public class Environment
    {
        public int clientTypeId { get; set; }
        public string languageCode { get; set; }
    }

    public class CreateRequestToken_DTO
    {
        public Environment environment { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string sessionProductId { get; set; }
        public int numLaunchTokens { get; set; }
        public string marketType { get; set; }
    }
}
