using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace Tappit.WebApi.Controllers
{
    [ApiController]
    public class BaseController: ControllerBase
    {
        private ISender _sender;
        protected ISender Sender => _sender = HttpContext.RequestServices.GetService<ISender>();

    }
}
