using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    public interface IAmbientScopeProvider<T>
    {
        T GetValue(string contextKey);

        IDisposable BeginScope(string contextKey, T value);
    }
}
