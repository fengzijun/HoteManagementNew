using Autofac;
using Autofac.Builder;
using Autofac.Core;
using HoteManagement;
using HoteManagement.Configuration;
using HoteManagement.Fakes;
using HoteManagement.Infrastructure;
using HoteManagement.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac.Integration.Mvc;
using HoteManagement.Data;
using HoteManagement.Caching;
using HoteManagement.Service.Logging;
using HoteManagement.Service.Events;

using HoteManagement.Infrastructure.UnitOfWork;

using Autofac.Extras.DynamicProxy;

using HoteManagement.Service.Core;
using System.Data;
using System.Data.SqlClient;
using HoteManagement.Data.Dapper;
using HoteManagement.Data.Dapper.UnitOfWork;
using HoteManagement.Data.Dapper.Filters.Query;

namespace EM.Article.Api.Framework
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, ArticleConfig config)
        {
            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

            //web helper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();
            //user agent helper

            //controllers
            // builder.Register(c => new CacheIInterceptor());
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            //data layer

            //builder.Register(x => new EfDataProviderManager(config)).As<BaseDataProviderManager>().InstancePerDependency();
            builder.Register(x => x.Resolve<BaseDataProviderManager>().LoadDataProvider()).As<IDataProvider>().InstancePerDependency();

            //var efDataProviderManager = new EfDataProviderManager(config);
            //var dataProvider = efDataProviderManager.LoadDataProvider();

            //dataProvider.InitDatabase(config.DatabaseInstallModel);

            builder.Register<IDbConnection>(c => new SqlConnection(config.MsSqlConnectionString)).InstancePerLifetimeScope();
            //builder.Register<IWriteDbContext>(c => new WriteObjectContext(config.MsSqlWriteConnectionString)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(DapperRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
         
            //cache managers
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().SingleInstance();
           
            //services

            //use static cache (between HTTP requests)
            builder.RegisterType<DefaultLogger>().As<ILogger>().InstancePerLifetimeScope();
            builder.RegisterType<DapperQueryFilterExecuter>().As<IDapperQueryFilterExecuter>().InstancePerLifetimeScope();
            //builder.RegisterType<DbContextFactory>().As<IDbContextFactory>().InstancePerLifetimeScope();
            //builder.RegisterType<SingleStrategy>().As<IReadDbStrategy>().InstancePerLifetimeScope();
            //use static cache (between HTTP requests)

            bool databaseInstalled = DataSettingsHelper.DatabaseIsInstalled(config);
            if (!databaseInstalled)
            {
                //builder.RegisterType<CodeFirstInstallationService>().As<IInstallationService>().InstancePerLifetimeScope();
                //installation service
                //if (config.UseFastInstallationService)
                //{
                //    builder.RegisterType<SqlFileInstallationService>().As<IInstallationService>().InstancePerLifetimeScope();
                //}
                //else
                //{
                //    builder.RegisterType<CodeFirstInstallationService>().As<IInstallationService>().InstancePerLifetimeScope();
                //}
            }

            //Register event consumers
            var consumers = typeFinder.FindClassesOfType(typeof(IConsumer<>)).ToList();
            foreach (var consumer in consumers)
            {
                builder.RegisterType(consumer)
                    .As(consumer.FindInterfaces((type, criteria) =>
                    {
                        var isMatch = type.IsGenericType && ((Type)criteria).IsAssignableFrom(type.GetGenericTypeDefinition());
                        return isMatch;
                    }, typeof(IConsumer<>)))
                    .InstancePerLifetimeScope();
            }
            builder.RegisterType<EventPublisher>().As<IEventPublisher>().InstancePerLifetimeScope();
            builder.RegisterType<SubscriptionService>().As<ISubscriptionService>().InstancePerLifetimeScope();

            //unit of work
            builder.RegisterType<UnitOfWorkDbConnectionProvider>().As<IDbConnectionProvider>().InstancePerLifetimeScope();
            builder.RegisterType<CallContextCurrentUnitOfWorkProvider>().As<IUnitOfWorkProvider>().InstancePerLifetimeScope();
            builder.RegisterType<DapperUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWorkManager>().As<IUnitOfWorkManager>().InstancePerLifetimeScope();
            builder.RegisterType<DbContextDapperTransactionStrategy>().As<IDapperTransactionStrategy>().InstancePerLifetimeScope();
            //builder.RegisterType<CallContextAmbientDataContext>().As<IAmbientDataContext>().SingleInstance();
            //builder.RegisterGeneric(typeof(DataContextAmbientScopeProvider<>)).As(typeof(IAmbientScopeProvider<>)).InstancePerLifetimeScope();
            
            //serivce

            builder.RegisterType<GenerateService>().As<IGenerateService>().InstancePerLifetimeScope().EnableClassInterceptors();

            builder.RegisterType<RedisCacheManager>().As<IRedis>().InstancePerLifetimeScope();

      
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }

    //public class DbContextDependencyRegistrar: IDependencyRegistrar
    //{
    //    /// <summary>
    //    /// Register services and interfaces
    //    /// </summary>
    //    /// <param name="builder">Container builder</param>
    //    /// <param name="typeFinder">Type finder</param>
    //    /// <param name="config">Config</param>
    //    public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, ArticleConfig config)
    //    {
    //        builder.Register<IDbContext>(c => new BaseObjectContext(config.MsSqlConnectionString)).InstancePerLifetimeScope();
    //    }

    //    /// <summary>
    //    /// Order of this dependency registrar implementation
    //    /// </summary>
    //    public int Order
    //    {
    //        get { return 99; }
    //    }
    //}

    //public class SettingsSource : IRegistrationSource
    //{
    //    static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
    //        "BuildRegistration",
    //        BindingFlags.Static | BindingFlags.NonPublic);

    //    public IEnumerable<IComponentRegistration> RegistrationsFor(
    //            Service service,
    //            Func<Service, IEnumerable<IComponentRegistration>> registrations)
    //    {
    //        var ts = service as TypedService;
    //        if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
    //        {
    //            var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
    //            yield return (IComponentRegistration)buildMethod.Invoke(null, null);
    //        }
    //    }

    //    static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
    //    {
    //        return RegistrationBuilder
    //            .ForDelegate((c, p) =>
    //            {
    //                var currentStoreId = c.Resolve<IStoreContext>().CurrentStore.Id;
    //                //uncomment the code below if you want load settings per store only when you have two stores installed.
    //                //var currentStoreId = c.Resolve<IStoreService>().GetAllStores().Count > 1
    //                //    c.Resolve<IStoreContext>().CurrentStore.Id : 0;

    //                //although it's better to connect to your database and execute the following SQL:
    //                //DELETE FROM [Setting] WHERE [StoreId] > 0
    //                return c.Resolve<ISettingService>().LoadSetting<TSettings>(currentStoreId);
    //            })
    //            .InstancePerLifetimeScope()
    //            .CreateRegistration();
    //    }

    //    public bool IsAdapterForIndividualComponents { get { return false; } }
    //}
}