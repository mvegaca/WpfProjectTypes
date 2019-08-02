using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.DependencyInjection;
using RibbonProject.Activation;
using RibbonProject.Services;
using RibbonProject.ViewModels;
using RibbonProject.Views;

namespace RibbonProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ActivationService _activationService;

        public App()
        {
            var serviceProvider = ConfigureServices().BuildServiceProvider();
            _activationService = serviceProvider.GetService<ActivationService>();
            DispatcherUnhandledException += OnDispatcherUnhandledException;
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ActivationService>();
            services.AddSingleton<NavigationService>();

            // Handlers
            services.AddTransient<DefaultActivationHandler>();

            // Views
            services.AddSingleton<ShellWindow>();
            services.AddSingleton<ShelWindowViewModel>();

            services.AddTransient<MainPage>();
            services.AddTransient<MainViewModel>();

            services.AddTransient<SecondaryPage>();
            services.AddTransient<SecondaryViewModel>();

            return services;
        }

        private async void OnStartup(object sender, StartupEventArgs e)
            => await _activationService.ActivateAsync(e);

        private async void OnExit(object sender, ExitEventArgs e)
            => await _activationService.ExitAsync();

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
        }
    }
}
