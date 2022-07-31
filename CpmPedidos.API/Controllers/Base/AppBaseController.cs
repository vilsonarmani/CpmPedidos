
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers.Base;

public class AppBaseController : Controller
{
    protected IServiceProvider _serviceProvider;
    public AppBaseController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}
