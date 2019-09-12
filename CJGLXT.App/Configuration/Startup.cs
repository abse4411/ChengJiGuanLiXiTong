using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace CJGLXT.App.Configuration
{
    public static class Startup
    {
        private static readonly ServiceCollection _serviceCollection = new ServiceCollection();

        public static Task ConfigureAsync()
        {
            ServiceLocator.Configure(_serviceCollection);

            return Task.CompletedTask;
        }
    }
}
