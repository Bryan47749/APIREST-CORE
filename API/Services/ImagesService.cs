using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class ImagesService
    {
        private readonly DBContext _dbContext;

        public ImagesService(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public List<Images> ObtenerImagenes(int IDPost)
        {
            return _dbContext.Images.Where(x=> x.ID_POST == IDPost ).ToList();
        }

        public void GuardarImagen(string nombre, int IDPost)
        {
            Images images = new Images();
            images.Img = nombre;
            images.ID_POST = IDPost;
            images.Estado = 1;
            _dbContext.Images.Add(images);
            _dbContext.SaveChanges();
        }

        
    }
}
