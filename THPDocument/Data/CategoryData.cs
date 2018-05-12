using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CategoryData
    {
        DocumentsEntities db;
        public CategoryData()
        {
            db = new DocumentsEntities();
        }
        public List<Category> ListCategory()
        {
            return db.Categories.ToList();
        }
        public bool DeleteCategory(int id)
        {
            var model = db.Categories.Find(id);
            db.Categories.Remove(model);
            db.SaveChanges();
            return true;
        }
    }
}
