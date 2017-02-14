using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;
using AdminDal.DataAccess;

namespace AdminDal.Manager
{
    public class AdminManager
    {
        AdminRepository _objAccountReps = new AdminRepository();
        News_SchemesRepository _objNewsScheme = new News_SchemesRepository();

        public List<Admin> GetAdminDetailByUserId(Int32 id)
        {
            return _objAccountReps.GetAdminDetailByUserId(id);
        }
        public int EditAdmin(Admin adm)
        {
            return _objAccountReps.EditAdmin(adm);
        }
        public Admin GetAdminByID(int? id)
        {
            return _objAccountReps.GetAdminByID(id);
        }
        public int DeleteAdmin(int? id)
        {
            return _objAccountReps.DeleteAdmin(id);
        }
        public int AdminStatusChange(int? id)
        {
            return _objAccountReps.AdminStatusChange(id);
        }
        public List<Admin> GetAllAdmin()
        {
            return _objAccountReps.GetAllAdmin();
        }
        public int Resetpassword(ResetPassword rp)
        {
            return _objAccountReps.ResetPassword(rp);
        }
        public List<Account> GetAllUserAccount()
        {
            return _objAccountReps.GetAllUserAccount();
        }
        public int DeleteUser(int? id)
        {
            return _objAccountReps.DeleteUser(id);
        }
        public Account GetUserByID(int? id)
        {
            return _objAccountReps.GetUserByID(id);
        }
        public int EditUser(Account act)
        {
            return _objAccountReps.EditUser(act);
        }
        public int UserStatusChange(int? id)
        {
            return _objAccountReps.UserStatusChange(id);
        }
        public KeyValuePair<int, int> AddUser(Account acc)
        {
            return _objAccountReps.AddUser(acc);
        }
        public KeyValuePair<int, int> AddAdmin(Admin ad)
        {
            return _objAccountReps.AddAdmin(ad);
        }
        public int UpdateProfilePhoto(Admin adm)
        {
            return _objAccountReps.UpdateProfilePhoto(adm);
        }
    }
}
