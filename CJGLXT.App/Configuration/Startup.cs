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
        private static bool _isConfigured = false;

        public static Task ConfigureAsync()
        {
            if(!_isConfigured)
            {
                ServiceLocator.Configure(_serviceCollection);
                _isConfigured = true;
            }

            return Task.CompletedTask;
        }
    }
}
