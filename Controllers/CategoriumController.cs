using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba_tecnica_Atlantic.Models;




namespace prueba_tecnica_Atlantic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriumController : ControllerBase
    {
        private readonly CastilloContext _dbcontext;

        public CategoriumController(CastilloContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Categorium> lista = _dbcontext.Categoria.OrderByDescending(t => t.Nomcat).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }
    }
}