using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_GameBalance
{
    public class Financials
    {
        public double betAmount { get; set; }
        public double payoutAmount { get; set; }
    }

    public class Balances
    {
        public int loyaltyBalance { get; set; }
        public double totalInAccountCurrency { get; set; }
    }

    public class Context
    {
        public Financials financials { get; set; }
        public Balances balances { get; set; }
    }

    public class Packet
    {
        public string payload { get; set; }
        public int packetType { get; set; }
        public bool isBase64Encoded { get; set; }
    }

    public class Response_postDTO
    {
        public Context context { get; set; }
        public Packet packet { get; set; }
    }

}
