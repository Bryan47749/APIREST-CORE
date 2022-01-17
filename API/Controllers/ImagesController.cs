using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ImagesService _imagesService;
        private readonly UploadService _uploadService;
        public ImagesController(ImagesService imagesService, UploadService uploadService)
        {
            _imagesService = imagesService;
            _uploadService = uploadService;
        }

        [HttpGet("{IDPost}")]
        public IActionResult ObtenerImagenes(int IDPost)
        {
            return Ok(_imagesService.ObtenerImagenes(IDPost));
        }

        [HttpGet("{UserID}/{nombreArchivo}")]
        public IActionResult MostrarImage(int UserID, string nombreArchivo)
        {
            string ruta = _uploadService.MostrarImagen(UserID, nombreArchivo);
            
            var image = System.IO.File.OpenRead(ruta);
            string contentType = "";
            new FileExtensionContentTypeProvider().TryGetContentType( Path.GetFileName(ruta), out contentType);
            
            return File(image, contentType);

        }

    }
}
