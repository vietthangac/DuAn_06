using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Data
{
    public class HomeData
    {
        DocumentsEntities db;
        public HomeData()
        {
            db = new DocumentsEntities();
        }
        public IEnumerable<Document> ListDocumentPaging(int page, int pageSize)
        {
            return db.Documents.OrderByDescending(x=>x.DatePost).Where(x=>x.Status == true).ToPagedList(page, pageSize);
            
        }
        public IEnumerable<Document> ListDocumentYeuThich(int page, int pageSize)
        {
            return db.Documents.OrderByDescending(x => x.Rate).Where(x => x.Status == true).ToPagedList(page, pageSize);
        }
    }
}
