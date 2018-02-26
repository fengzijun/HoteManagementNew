using HoteManagement.Configuration;
using HoteManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Data
{
    /// <summary>
	/// 定义一个接口 <see cref="IDbConnectionInterceptor"/> 的默认空实现；
	/// <para>提供当在 EF 框架中创建或更改 <see cref="DbConnection"/> 时所引发的通知。</para>
	/// <para>详情请参见接口 <see cref="IDbConnectionInterceptor"/>。</para>
	/// </summary>
	public class NullDbConnectionInterceptor : IDbConnectionInterceptor
    {
        /// <summary>
        /// 在开启一个数据库事务动作完成后瞬间触发。
        /// </summary>
        public virtual void BeganTransaction(DbConnection connection, BeginTransactionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在开启一个数据库事务动作执行前瞬间触发。
        /// </summary>
        public virtual void BeginningTransaction(DbConnection connection, BeginTransactionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在关闭数据库连接动作完成后瞬间触发。
        /// </summary>
        public virtual void Closed(DbConnection connection, DbConnectionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在关闭数据库连接动作执行前瞬间触发。
        /// </summary>
        public virtual void Closing(DbConnection connection, DbConnectionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在获取数据库连接字符串动作执行前瞬间触发。
        /// </summary>
        public virtual void ConnectionStringGetting(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在获取数据库连接字符串动作完成后瞬间触发。
        /// </summary>
        public virtual void ConnectionStringGot(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在设置数据库连接字符串动作完成后瞬间触发。
        /// </summary>
        public virtual void ConnectionStringSet(DbConnection connection, DbConnectionPropertyInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在设置数据库连接字符串动作执行前瞬间触发。
        /// </summary>
        public virtual void ConnectionStringSetting(DbConnection connection, DbConnectionPropertyInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在获取数据库连接超时时间动作执行前瞬间触发。
        /// </summary>
        public virtual void ConnectionTimeoutGetting(DbConnection connection, DbConnectionInterceptionContext<int> interceptionContext) { }

        /// <summary>
        /// 在获取数据库连接超时时间动作完成后瞬间触发。
        /// </summary>
        public virtual void ConnectionTimeoutGot(DbConnection connection, DbConnectionInterceptionContext<int> interceptionContext) { }

        /// <summary>
        /// 在获取 数据源服务器名称/IP 名称动作执行前瞬间触发。
        /// </summary>
        public virtual void DataSourceGetting(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在获取 数据源服务器名称/IP 名称动作完成后瞬间触发。
        /// </summary>
        public virtual void DataSourceGot(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在获取数据库名称动作执行前瞬间触发。
        /// </summary>
        public virtual void DatabaseGetting(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在获取数据库名称动作完成后瞬间触发。
        /// </summary>
        public virtual void DatabaseGot(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在数据库连接对象 <see cref="DbConnection"/> 资源销毁动作完成后瞬间触发。
        /// </summary>
        public virtual void Disposed(DbConnection connection, DbConnectionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在数据库连接对象 <see cref="DbConnection"/> 资源销毁动作执行前瞬间触发。
        /// </summary>
        public virtual void Disposing(DbConnection connection, DbConnectionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在数据库操作事务提交动作完成后瞬间触发。
        /// </summary>
        public virtual void EnlistedTransaction(DbConnection connection, EnlistTransactionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在数据库操作事务提交动作执行前瞬间触发。
        /// </summary>
        public virtual void EnlistingTransaction(DbConnection connection, EnlistTransactionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在打开数据库连接动作完成后瞬间触发。
        /// </summary>
        public virtual void Opened(DbConnection connection, DbConnectionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在打开数据库连接动作执行前瞬间触发。
        /// </summary>
        public virtual void Opening(DbConnection connection, DbConnectionInterceptionContext interceptionContext) { }

        /// <summary>
        /// 在获取数据库版本信息动作执行前瞬间触发。
        /// </summary>
        public virtual void ServerVersionGetting(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在获取数据库版本信息动作完成后瞬间触发。
        /// </summary>
        public virtual void ServerVersionGot(DbConnection connection, DbConnectionInterceptionContext<string> interceptionContext) { }

        /// <summary>
        /// 在获取数据库连接状态动作执行前瞬间触发。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="interceptionContext"></param>
        public virtual void StateGetting(DbConnection connection, DbConnectionInterceptionContext<ConnectionState> interceptionContext) { }

        /// <summary>
        /// 在获取数据库连接状态动作完成后瞬间触发。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="interceptionContext"></param>
        public virtual void StateGot(DbConnection connection, DbConnectionInterceptionContext<ConnectionState> interceptionContext) { }
    }

    public class DbMasterSlaveConnectionInterceptor: NullDbConnectionInterceptor
    {
        private readonly string _masterConnectionString;
        private readonly string _slaveConnectionString;

        public DbMasterSlaveConnectionInterceptor()
        {
            var config = EngineContext.Current.Resolve<ArticleConfig>();
            _slaveConnectionString = config.MsSqlConnectionString;
            _masterConnectionString = config.MsSqlWriteConnectionString;
        }

        public override void Opening(DbConnection connection, DbConnectionInterceptionContext interceptionContext)
        {
            // interceptionContext.
            //UpdateConnectionStringIfNeed(connection, this.Config.UsableMasterConnectionString, interceptionContext.DbContexts);
            //string ddd = string.Empty;
        }

        /// <summary>
        /// 在开启一个数据库事务动作执行前瞬间触发。当开始事务操作时将数据库连接字符串更新至 Master 数据库。
        /// </summary>
        public override void BeginningTransaction(DbConnection connection, BeginTransactionInterceptionContext interceptionContext)
        {
            UpdateConnectionStringIfNeed(connection, _masterConnectionString);
        }

        public override void EnlistingTransaction(DbConnection connection, EnlistTransactionInterceptionContext interceptionContext)
        {
            //base.EnlistingTransaction(connection, interceptionContext);
            UpdateConnectionStringIfNeed(connection, _masterConnectionString);
        }

        private bool IsSameConnection(string oldconnection, string newconnection)
        {
            if (newconnection.Contains(oldconnection))
                return true;

            return false;
        }

        private void UpdateConnectionStringIfNeed(DbConnection connection, string newconnectionstring)
        {
            if (string.IsNullOrWhiteSpace(newconnectionstring)) return;

            if (IsSameConnection(connection.ConnectionString, newconnectionstring))
                return;
            if (connection.State == ConnectionState.Open)
                connection.Close();

            connection.ConnectionString = newconnectionstring;
            connection.Open();
        }

    }
}
