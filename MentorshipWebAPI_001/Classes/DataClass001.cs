using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MentorshipWebAPI_001.Classes
{
    public class DataClass001
    {
        [System.Text.Json.Serialization.JsonPropertyName ("key")]
        public string Key { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName ("value")]
        public string Value { get; set; }
    }
}