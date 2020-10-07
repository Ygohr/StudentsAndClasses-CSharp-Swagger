using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnicoMarlin.Model
{
    public class TurmaAluno
    {
        [Key, Column(Order = 0)]
        public int idTurma { get; set; }
        [Key, Column(Order = 1)]
        public int idAluno { get; set; }
    }
}
