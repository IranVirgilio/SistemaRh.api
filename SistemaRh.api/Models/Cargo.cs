using System.ComponentModel.DataAnnotations;

namespace SistemaRh.api.Models
{
    public class Cargo
    {
        [Key] //para o Entity Framework reconhecer a chave primaria
        public int IdCargo { get; set; }
        public string Titulo { get; set; }
    }
}
