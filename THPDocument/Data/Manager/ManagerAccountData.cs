using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Manager
{
    public class ManagerAccountData
    {
        DocumentsEntities db;
        public ManagerAccountData()
        {
            db = new DocumentsEntities();
        }
        public List<Account> ListAccount()
        {
            return db.Accounts.ToList();
        }
    }
}
