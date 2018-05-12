using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THPDocument.Common
{
    [Serializable]
    public class UserLogin
    {
        public string Username { get; set; }
        public int ID { get; set; }
        public string FullName { get; set; }
        public int? Point { get; set; }
    }
}