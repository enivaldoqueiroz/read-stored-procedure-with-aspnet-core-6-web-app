using Microsoft.AspNetCore.Mvc;
using ReadStoredProcedure.Services;

namespace ReadStoredProcedure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeuController : ControllerBase
    {
        private readonly MeuContexto _contexto;

        public MeuController(MeuContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var resultado = _contexto.ExecutarMinhaStoredProcedure();
            return Ok(resultado);
        }

        [HttpPost]
        public IActionResult Post([FromBody] int id)
        {
            return Ok();
        }
    }
}
