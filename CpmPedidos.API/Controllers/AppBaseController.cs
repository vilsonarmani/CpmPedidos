using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers;

public class AppBaseController : Controller
{
    protected IServiceProvider _serviceProvider;
    protected T GetService<T>() => _serviceProvider.GetService<T>()!;
    public AppBaseController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}
