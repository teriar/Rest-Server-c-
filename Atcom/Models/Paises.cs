using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Atcom.Models
{
    public class Pais
    {
        [Key]
        public int Codigo { get; set; }

        public string Descripcion { get; set; }
    }
}
