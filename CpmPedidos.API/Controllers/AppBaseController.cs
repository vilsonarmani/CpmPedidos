using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers;

public class AppBaseController : Controller
{
    protected IServiceProvider _serviceProvider;
    public AppBaseController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}
