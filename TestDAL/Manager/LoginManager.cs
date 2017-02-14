using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.DataAccess;

using AdminDal.Entity;
namespace AdminDal.Manager
{
    public class LoginManager
    {
        LoginRepository _objLoginReps = new LoginRepository();


        public void SetFormAuthCookie(Admin accountObj, bool remember)
        {
            _objLoginReps.SetFormAuthCookie(accountObj, remember);
        }
        public string GetRememberCookie()
        {
            return _objLoginReps.GetRememberCookie();
        }
        public List<Admin> GetAdmin(Login account)
        {
            return _objLoginReps.GetAdmin(account);
        }
        public int ForgetPassword(string mail)
        {
            return _objLoginReps.ForgetPass(mail);
        }
    }
}
