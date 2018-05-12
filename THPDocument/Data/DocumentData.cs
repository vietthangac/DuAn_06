using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DocumentData
    {
        DocumentsEntities db;
        public DocumentData()
        {
            db = new DocumentsEntities();
        }
        public List<Document> ListDocument()
        {
            return db.Documents.ToList();
        }
        public int InsertDocument(Document entity)
        {
            db.Documents.Add(entity);
            db.SaveChanges();
            return entity.DocumentID;
        }
        public List<Document> ListDocumentByUser(int id)
        {
            var model = db.Documents.Where(x => x.PostBy == id).ToList();
            return model;
        }
        public bool DeleteDocument(int id)
        {
            var item = db.Documents.Find(id);
            db.Documents.Remove(item);
            db.SaveChanges();
            return true;
        }
        public bool UpdateDocument(Document entity)
        {
            var it = db.Documents.Find(entity.DocumentID);
            it.DocumentName = entity.DocumentName;
            it.DocumentDescription = entity.DocumentDescription;
            it.DocumentContent = entity.DocumentContent;
            it.DocumentPoint = entity.DocumentPoint;
            it.Tag = entity.Tag;
            it.Thumbnail = entity.Thumbnail;
            db.SaveChanges();
            return true;
        }
        public List<Document> ListNotPublist()
        {
            var model = db.Documents.Where(x => x.Status == false).ToList();
            return model;
        }
        public bool? StatusKD(int id)
        {
            var document = db.Documents.Find(id);
            document.Status = !document.Status;
            db.SaveChanges();
            return document.Status;
        }
        public List<Document> ListDocumentPublist()
        {
            return db.Documents.Where(x => x.Status == true).ToList();
        }
        public void AddPoint(int? point, int id)
        {
            var po = db.Accounts.Find(id);
            po.AccountPoint = point;
            db.SaveChanges();
        }
    }
}
