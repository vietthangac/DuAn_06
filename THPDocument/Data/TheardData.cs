using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TheardData
    {
        DocumentsEntities db;
        public TheardData()
        {
            db = new DocumentsEntities();
        }
        public List<Theard> ListTheard()
        {
            return db.Theards.ToList();
        }
        public bool InsertTheard(Theard entity)
        {
            db.Theards.Add(entity);
            db.SaveChanges();
            return true;
        }
        public bool UpdateTheard(Theard entity)
        {
            var fi = db.Theards.Find(entity.TheardID);
            fi.TheardName = entity.TheardName;
            db.SaveChanges();
            return true;
        }
        public bool DeleteTheard(int id)
        {
            var fi = db.Theards.Find(id);
            db.Theards.Remove(fi);
            db.SaveChanges();
            return true;
        }
    }
}
