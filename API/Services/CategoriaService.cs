using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class CategoriaService
    {
        private readonly DBContext _dbContext;

        public CategoriaService(DBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _dbContext.Categoria.Where(x=> x.Estado ==1).ToList();
        }

        public Categoria GuardarCategoria(Categoria categoria)
        {
            categoria.Estado = 1;
            _dbContext.Categoria.Add(categoria);
            _dbContext.SaveChanges();
            return categoria;
        }

        internal bool EliminarCategoria(int id)
        {
            var categoriaDB = _dbContext.Categoria.Find(id);
            if (categoriaDB != null)
            {
                categoriaDB.Estado= 0;
                _dbContext.Categoria.Update(categoriaDB);
                _dbContext.SaveChanges();
                return true;
            } 
            return false;
        }
    }
}
