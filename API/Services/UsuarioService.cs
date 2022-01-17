using API.Helpers;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class UsuarioService
    {
        private readonly DBContext _dbContext;
        private readonly Security _security;
        public UsuarioService(DBContext dBContext, Security security)
        {
            _dbContext = dBContext;
            _security = security;
        }

        public List<Usuario> ListarUsuario()
        {
            return  _dbContext.Usuario.ToList();
        }

        public ResponseModel GuardarUsuario(Usuario u)
        {
           
            try
            {

                var usuarioDB = _dbContext.Usuario.Where(x=> x.Email.Equals(u.Email)).FirstOrDefault();

                if (usuarioDB != null)
                {
                    return new ResponseModel(400, "El email: " + u.Email + " ya existe!");
                }

                u.Password = _security.Encriptar(u.Password);
                u.Estado = 1;
                _dbContext.Usuario.Add(u);
                _dbContext.SaveChanges();
                return new ResponseModel(200, u);
            }
            catch (Exception ex)
            {
                return new ResponseModel(400, ex.Message);
            }
        }

        public ResponseModel Login(Login u)
        {
            try
            {
                var usuarioDB = _dbContext.Usuario.Where(x => x.Email.Equals(u.Email)).FirstOrDefault();

                if (usuarioDB == null)
                {
                    return new ResponseModel(400, " Usuario/Contraseña Incorrectos");
                }

                string des = _security.Desencriptar(usuarioDB.Password);
                if (usuarioDB.Password.Equals( _security.Encriptar(u.Pass)))
                {
                    return new ResponseModel(20, usuarioDB);
                }
                else
                {
                    return new ResponseModel(400, " Usuario/Contraseña Incorrectos");
                }

               
            }
            catch (Exception ex)
            {
                return new ResponseModel(400, ex.Message);
                
            }
        }
    }
}
