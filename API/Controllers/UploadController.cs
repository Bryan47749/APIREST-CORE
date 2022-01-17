using API.Models;
using API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly UploadService _uploadService;
        
        public UploadController(UploadService uploadService)
        {
            _uploadService = uploadService;
            
        }

        [HttpPost("{id}")]
        public IActionResult CargarImagen(int id)
        {
            ResponseModel res = new ResponseModel();
            if (Request.Form.Files.Count <= 0)
            {
                res.Status = 400;
                res.Error = "No subio ningun archivo";
                return BadRequest(res);
            }


            IFormFile file = Request.Form.Files[0];
            
            string extension = Path.GetExtension(file.FileName);

            if (extension != ".jpg" && extension != ".png" && extension != ".jpeg" && extension != ".gif")
            {
                res.Status = 400;
                res.Error = "Extension no valida";
                return BadRequest(res);
            }

            res = _uploadService.CargarImagenTemp(file,id );
            
            return Ok(res);
        }
    }
}
