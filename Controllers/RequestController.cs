using Microsoft.AspNetCore.Mvc;
using RequestService.Polices;

namespace RequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ClientPolicy _clientPolicy;

        public RequestController(ClientPolicy clientPolicy)
        {
            _clientPolicy = clientPolicy;
        }

        public async Task<ActionResult> MakeRequest()
        {
            var client = new HttpClient();
            var response = await _clientPolicy.LinearHttpRetry.ExecuteAsync(()
                => client.GetAsync("http://localhost:5168/api/response/25"));

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> ResponseService returned a Success");
                return Ok();
            }
            else
            {
                Console.WriteLine("--> ResponseService returned a FAILURE");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
