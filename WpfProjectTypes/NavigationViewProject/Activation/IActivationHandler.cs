using System.Threading.Tasks;

namespace NavigationViewProject.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
