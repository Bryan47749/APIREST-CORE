using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Images
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Imagen Requerida")]
        public string Img { get; set; }
        public int ID_POST { get; set; }
        public int Estado { get; set; }

        public class MapeoDB
        {
            public MapeoDB(EntityTypeBuilder<Images> builder)
            {
                builder.HasKey(x => x.ID);

            }
        }
    }
}
