using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIstema_Venda_SI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DefaultController : Controller
    {
        
    }
}
