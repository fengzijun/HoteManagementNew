using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    public class CallContextAmbientDataContext : IAmbientDataContext
    {
        public void SetData(string key, object value)
        {
            if (value == null)
            {
                CallContext.FreeNamedDataSlot(key);
                return;
            }

            CallContext.LogicalSetData(key, value);
        }

        public object GetData(string key)
        {
            return CallContext.LogicalGetData(key);
        }
    }
}
