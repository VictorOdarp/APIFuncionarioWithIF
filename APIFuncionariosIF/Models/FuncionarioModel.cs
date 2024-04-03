using APIFuncionariosIF.Enums;
using System.ComponentModel.DataAnnotations;

namespace APIFuncionariosIF.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DepartamentEnum Departament { get; set; }
        public bool Active { get; set; }
        public TurnoEnum Bout { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ChangeDate { get; set; } = DateTime.Now;

    }
}
