using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CJGLXT.App
{
    public interface IDbService
    {
        String Test();
    }

    public class DbService : IDbService
    {
        public String Test()
        {
            return "DbService works!";
        }
    }
    public class DefaultViewModel
    {
        private readonly IDbService _dbService;

        public DefaultViewModel(IDbService dbService)
        {
            _dbService = dbService;
        }

        public String Test()
        {
            return "DefaultViewModel works!" + _dbService.Test();
        }
    }

    //public class ServiceLocator:IDisposable
    //{
    //    private static readonly ConcurrentDictionary<int, ServiceLocator> _serviceLocators = new ConcurrentDictionary<int, ServiceLocator>();

    //    private static ServiceProvider _rootServiceProvider = null;

    //    public static void Configure(IServiceCollection serviceCollection)
    //    {
    //        serviceCollection.AddSingleton<IDbService, DbService>();
    //        serviceCollection.AddTransient<DefaultViewModel>();

    //        _rootServiceProvider = serviceCollection.BuildServiceProvider();
    //    }

    //    public static ServiceLocator GetInstance(int id=0)
    //    {
    //        return _serviceLocators.GetOrAdd(id, key => new ServiceLocator());
    //    }

    //    public static void DisposeInstance(int id=0)
    //    {
    //        if (_serviceLocators.TryRemove(id, out ServiceLocator current))
    //        {
    //            current.Dispose();
    //        }
    //    }

    //    private IServiceScope _serviceScope = null;

    //    private ServiceLocator()
    //    {
    //        _serviceScope = _rootServiceProvider.CreateScope();
    //    }

    //    public T GetService<T>()
    //    {
    //        return GetService<T>(true);
    //    }

    //    public T GetService<T>(bool isRequired)
    //    {
    //        if (isRequired)
    //        {
    //            return _serviceScope.ServiceProvider.GetRequiredService<T>();
    //        }
    //        return _serviceScope.ServiceProvider.GetService<T>();
    //    }

    //    #region Dispose
    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            _serviceScope?.Dispose();
    //        }
    //    }
    //    #endregion
    //}
}
