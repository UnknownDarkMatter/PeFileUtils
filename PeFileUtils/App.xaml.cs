using Microsoft.Extensions.DependencyInjection;
using PeFileUtils.Business.Interfaces;
using PeFileUtils.Business.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PeFileUtils
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        public new static App Current => (App)Application.Current;

        public App()
        {
            Services = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IHexUtils, HexUtils>();
            services.AddSingleton<IUiService, UiService>();

            return services.BuildServiceProvider();
        }
    }
}
