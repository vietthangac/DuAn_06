using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AccountData
    {
        DocumentsEntities db;
        public AccountData()
        {
            db = new DocumentsEntities();
        }
        public List<Account> ListAccount()
        {
            var res = db.Accounts.ToList();
            return res;
        }
        public int InsertAccount(Account entity)
        {
            db.Accounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool UpdateAccount(Account entity)
        {
            var ac = db.Accounts.Find(entity.ID);
            ac.FullName = entity.FullName;
            ac.DateOfBirth = entity.DateOfBirth;
            ac.Avatar = entity.Avatar;
            ac.Address = entity.Address;
            db.SaveChanges();
            return true;
        }
        public bool DeleteAccount(int id)
        {
            var ac = db.Accounts.Find(id);
            db.Accounts.Remove(ac);
            db.SaveChanges();
            return true;
        }
        public bool checkLogin(string Username, string Password)
        {
            var res = db.Accounts.Count(x => x.Username == Username && x.Password == Password);
            if(res>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Account GetByID(string username)
        {
            return db.Accounts.SingleOrDefault(x=>x.Username == username);
        }
    }
}
