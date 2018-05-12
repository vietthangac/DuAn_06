using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class JoinPostDocument
    {
        public int DocumentID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentContent { get; set; }
        public string DocumentDescription { get; set; }
        public Nullable<int> DocumentPoint { get; set; }
        public Nullable<System.DateTime> DatePost { get; set; }
        public Nullable<int> PostBy { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Tag { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<double> Rate { get; set; }
        public string DocumentFile { get; set; }
        public Nullable<bool> Status { get; set; }
        public int CommentID { get; set; }
        public Nullable<int> ComentName { get; set; }
        public Nullable<System.DateTime> DateComment { get; set; }
        public string ComentContent { get; set; }
    }
}
