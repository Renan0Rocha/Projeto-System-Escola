using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEscola.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string NomeCurso { get; set; }
        public string CargaHoraria { get; set; }
        public string Turno { get; set; }
        public string Descricao { get; set; }
        public Escola Escola { get; set; }
    }
}
