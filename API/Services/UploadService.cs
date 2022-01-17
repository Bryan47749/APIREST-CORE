using API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace API.Services
{
    public class UploadService
    {
        private readonly DBContext _dbContext;
        private readonly IWebHostEnvironment _env;
        

        public UploadService(DBContext dBContext, IWebHostEnvironment env)
        {
            _dbContext = dBContext;
            _env = env;
        }

        public ResponseModel CargarImagenTemp(IFormFile file, int idUser)
        {
            string ruta = CrearCarpetaUsuario(idUser);
            string nombreUnico = GenerarNombreUnico(file.FileName);

            string fullpath = Path.Combine(ruta, nombreUnico);
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                
                file.CopyTo(stream);
            }

            ResponseModel responseModel = new ResponseModel();
            responseModel.Status = 200;
            responseModel.Data = nombreUnico;
            return responseModel;
        }

        internal string[] MoverImagenes(int iD_Usuario)
        {
            string rutaTemp = Path.Combine(_env.ContentRootPath, "Uploads", iD_Usuario.ToString(), "Temp");
            string ruta = Path.Combine(_env.ContentRootPath, "Uploads", iD_Usuario.ToString(), "Imagenes");
            string[] archivos = Directory.GetFiles(rutaTemp);

            if (archivos.Length <=0)
            {
                return archivos;
            }


            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            foreach (var item in archivos)
            {
                string nombre = Path.GetFileName(item);
                File.Move(item, Path.Combine(ruta, nombre));
            }

            //Directory.Move(rutaTemp, ruta);
            
                
            return archivos;
        }

        private string GenerarNombreUnico(string fileName)
        {
            string[] arr = fileName.Split('.');
            string extension = arr[arr.Length - 1];
            string unico = Guid.NewGuid().ToString();

            return unico +"."+ extension;

        }


        private string CrearCarpetaUsuario(int IDUsuario)
        {
            string ruta = _env.ContentRootPath;
            ruta = Path.Combine(ruta, "Uploads", IDUsuario.ToString());

            string rutaTemp = Path.Combine(ruta, "Temp");

            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
                

            }
            if (!Directory.Exists(rutaTemp))
            {
                Directory.CreateDirectory(rutaTemp);
            }
            
            return rutaTemp;
        }


        public string MostrarImagen(int IDUsuario, string nombreImg)
        {
            string rutaImage = Path.Combine(_env.ContentRootPath, "Uploads", IDUsuario.ToString(), "Imagenes", nombreImg);
            
            

            if (!File.Exists(rutaImage))
            {
                rutaImage = Path.Combine(_env.ContentRootPath, "assets", "notFound.jpg");
            }

            return rutaImage;
        }
    }
}
