using API.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace API.Services
{
    public class PostService
    {
        private readonly DBContext _dbContext;
        private readonly UploadService _uploadService;
        private readonly ImagesService _imagesService;

        public PostService(DBContext dBContext, UploadService uploadService, ImagesService imagesService)
        {
            _dbContext = dBContext;
            _uploadService = uploadService;
            _imagesService = imagesService;
        }

        public List<Post> ListarPost()
        {
            return _dbContext.Post.Where(x => x.Estado == 1).ToList();
        }

        public Post GuardarPost(Post post)
        {

            // Leer los archivos de la carpeta temp

            string[] imagenes = _uploadService.MoverImagenes(post.ID_Usuario);

            post.Estado = 1;
            _dbContext.Post.Add(post);
            _dbContext.SaveChanges();

            // Guardar el nombre de las imagenes en BD

            foreach (var item in imagenes)
            {
                _imagesService.GuardarImagen(Path.GetFileName(item), post.ID);
            }

            return post;

        }


    }
}
