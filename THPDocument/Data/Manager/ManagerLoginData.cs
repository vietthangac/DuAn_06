using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Manager
{
    public class ManagerLoginData
    {
        DocumentsEntities db;
        public ManagerLoginData()
        {
            db = new DocumentsEntities();
        }
        public bool checkAdminLogin(string userName, string passWord)
        {
            var res = db.Accounts.Where(u=>u.RoleID > 1).Count(x => x.Username == userName && x.Password == passWord);
            if(res>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
