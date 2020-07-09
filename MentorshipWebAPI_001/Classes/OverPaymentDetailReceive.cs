using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MentorshipWebAPI_001.Classes
{
    public class OverPaymentDetailReceive
    {

        [System.Text.Json.Serialization.JsonPropertyName ("overpayment_id")]
        public int OverPaymentID { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("member_id")]
        public int MemberID { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("claim_number")]
        public string ClaimNumber { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("balance_amt")]
        public decimal BalanceAmt { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("overpayment_amt")]
        public decimal OverPaymentAmt { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("create_date")]
        public string CreateDate { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("sys_src_sync_date")]
        public string SysSrcSyncDate { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }
    }
}