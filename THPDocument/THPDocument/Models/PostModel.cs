using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace THPDocument.Models
{
    public class PostModel
    {
        public Document Documents { get; set; }
        public Comment Comments { get; set; }
    }
}