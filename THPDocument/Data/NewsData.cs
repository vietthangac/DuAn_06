using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class NewsData
    {
        DocumentsEntities db;
        public NewsData()
        {
            db = new DocumentsEntities();
        }
        public List<News> ListNews()
        {
            return db.News.ToList();
        }
        public int InsertNews(News entity)
        {
            db.News.Add(entity);
            db.SaveChanges();
            return entity.NewsID;
        }
        public List<News> ListNewsHome()
        {
            var model = db.News.OrderByDescending(x => x.CreateDate).ToList();
            return model;
        }
        public bool DeleteNews(int id)
        {
            var fi = db.News.Find(id);
            db.News.Remove(fi);
            db.SaveChanges();
            return true;
        }
        public bool UpdateNews(News entity)
        {
            var di = db.News.Find(entity.NewsID);
            di.NewsTitle = entity.NewsTitle;
            di.NewsContent = entity.NewsContent;
            di.Description = entity.Description;
            di.CreateDate = entity.CreateDate;
            di.Thumbnail = entity.Thumbnail;
            di.Tag = entity.Tag;
            di.TheardID = entity.TheardID;
            db.SaveChanges();
            return true;
        }
    }
}
