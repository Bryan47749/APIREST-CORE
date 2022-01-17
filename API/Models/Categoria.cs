using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Categoria
    {
        [JsonIgnore]
        public int ID { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        public string Nombre { get; set; }
        public int Estado { get; set; }

        public class MapeoDB
        {
            public MapeoDB(EntityTypeBuilder<Categoria> builder)
            {
                builder.HasKey(x => x.ID);

            }
        }
    }
}
