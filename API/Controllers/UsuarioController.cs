using API.Helpers;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
           
        }

        [HttpPost]
        public IActionResult GuardarUsuario([FromBody] Usuario u)
        {
            
            ResponseModel res = _usuarioService.GuardarUsuario(u);
            return Ok(res);
            
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Login u)
        {

            ResponseModel res = _usuarioService.Login(u);
            return Ok(res.Data);

        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            return Ok(_usuarioService.ListarUsuario());
        }
    }
}
