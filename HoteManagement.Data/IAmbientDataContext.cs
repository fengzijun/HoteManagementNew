using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    public interface IAmbientDataContext
    {
        void SetData(string key, object value);

        object GetData(string key);
    }
}
