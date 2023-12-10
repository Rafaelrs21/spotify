using Microsoft.AspNetCore.Mvc;
using Spotify.Streaming.Application.Streamimg.Service;

namespace Spotify.Streaming.API.Controllers
{
    public class PlanoController : Controller
    {
        private PlanoService service { get; set; }

        public PlanoController()
        {
            this.service = new PlanoService();
        }

        [HttpGet("{id}")]
        public IActionResult GetPlano(Guid id)
        {
            var result = this.service.ObterPlano(id);

            if (result == null)
                return NotFound();

            return Ok(result);

        }
    }
}
