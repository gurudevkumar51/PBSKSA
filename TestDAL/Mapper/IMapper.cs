using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AdminDal.Mapper
{
    public interface IMapper<T> where T : new()
    {
        T Map(IDataReader r);
    }
}
