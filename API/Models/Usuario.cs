
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace API.Models
{
    [DataContract]
    public class Usuario
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Nombres Requeridos")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Email Requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

      
        [JsonIgnore]
        [MinLength(8, ErrorMessage = "Password debe contener caracteres")]
        public string Password { get; set; }
        public int Estado { get; set; }

        public class MapeoDB
        {
            public MapeoDB(EntityTypeBuilder<Usuario> builder)
            {
                builder.HasKey(x => x.ID);
                
            }
        }

    }
}
