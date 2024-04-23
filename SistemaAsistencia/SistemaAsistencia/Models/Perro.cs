using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAsistencia.Models
{
    public class Perro
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public Perro(
            int id,
            string name,
            string description
            )
        {

            Id = id;
            Name = name;
            Description = description;
        }
    }
}
