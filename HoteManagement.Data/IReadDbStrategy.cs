using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    public interface IReadDbStrategy
    {
        /// <summary>
        /// 获取读库
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}