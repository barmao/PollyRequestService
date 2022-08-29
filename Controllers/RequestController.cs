using Microsoft.AspNetCore.Mvc;

namespace RequestService.Controllers
{
    public class RequestController : ControllerBase
    {
        public async Task<ActionResult> MakeRequest()
        {
            return Ok();
        }
    }
}
