using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bodhtree.Common;
namespace AdminDal.Common
{
    public class ExceptionHandlingError : HandleErrorAttribute
    {
        Logging log = new Logging();
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            log.Logflatfile_Ex(filterContext.Exception);
            filterContext.Result = new ViewResult
            {
                ViewName = "_LoginError"
            };
            if (filterContext.ExceptionHandled)
            {
                return;
            }
        }
    }
}
