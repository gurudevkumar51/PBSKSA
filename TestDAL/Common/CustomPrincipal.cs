using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;

namespace AdminDal.Common
{
        public class CustomPrincipal : IPrincipal
        {
            public CustomPrincipal(IIdentity identity)
            {
                Identity = identity;
            }
            public IIdentity Identity
            {
                get;
                private set;
            }
            public CustomAdmin User { get; set; }
            public bool IsInRole(string role)
            {
                return true;
            }
        }

}
