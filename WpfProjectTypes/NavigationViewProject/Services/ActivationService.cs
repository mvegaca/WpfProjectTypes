using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NavigationViewProject.Activation;

namespace NavigationViewProject.Services
{
    internal class ActivationService
    {
        private DefaultActivationHandler _defaultHandler;
        private ICollection<IActivationHandler> _activationHandlers = new List<IActivationHandler>();

        public ActivationService(DefaultActivationHandler defaultActivationHandler)
        {
            _defaultHandler = defaultActivationHandler;
        }

        public async Task ActivateAsync(object activationArgs)
        {
            // Initialize services that you need before app activation
            await InitializeAsync();

            var activationHandler = _activationHandlers.FirstOrDefault(h => h.CanHandle(activationArgs));

            if (activationHandler != null)
            {
                await activationHandler.HandleAsync(activationArgs);
            }

            if (_defaultHandler.CanHandle(activationArgs))
            {
                await _defaultHandler.HandleAsync(activationArgs);
            }

            // Tasks after activation
            await StartupAsync();
        }

        private async Task InitializeAsync()
        {
            await Task.CompletedTask;
            FilesService.Initialize();
            App.Current.RestoreProperties();
        }

        private async Task StartupAsync()
        {
            await Task.CompletedTask;
        }

        public async Task ExitAsync()
        {
            App.Current.SaveProperties();
        }
    }
}
