using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MentorshipWebAPI_001.Classes
{
    public class OverPaymentDetailResponse
    {
        public int memberId { get; set; }
        public string claimNumber { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        public string balanceAmt { get; set; }
        public string overpaymentAmt { get; set; }
        public string amtPaid { get; set; }
        public int daysLeftToPay { get; set; }
    }
}