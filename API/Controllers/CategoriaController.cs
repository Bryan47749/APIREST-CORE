using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;
        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult ListarCategorias()
        {
            return Ok(_categoriaService.ObtenerCategorias());
        }

        [HttpPost]
        public IActionResult GuardarCategoria([FromBody] Categoria categoria)
        {
            return Ok(_categoriaService.GuardarCategoria(categoria));
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCategoria(int id)
        {
            bool resul = _categoriaService.EliminarCategoria(id);
            if (resul)
            {
                //return BadRequest("No se pudo eliminar");
                return Ok();
            }
            else
            {
                return BadRequest("No se pudo eliminar");
            }
        }
    }
}
