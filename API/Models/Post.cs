using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Titulo Requeridos")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Descripcion Requeridos")]
        public string Descripcion { get; set; }
        [Range(0, 9999999999999999.99)]
        public decimal Precio { get; set; }
        public int ID_Usuario { get; set; }
        public int ID_Categoria { get; set; }
        public int Estado { get; set; }

        public class MapeoDB
        {
            public MapeoDB(EntityTypeBuilder<Post> builder)
            {
                builder.HasKey(x => x.ID);

            }
        }

    }
}
