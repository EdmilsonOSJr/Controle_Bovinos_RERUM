using com.rerum.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ControleBovinos_Web.Models
{
    public class BovinoModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string cod_objeto { get; set; }
        public string nome { get; set; }
        public string brinco { get; set; }
        public string brincoPai { get; set; }
        public string brincoMae { get; set; }
        public string sexo { get; set; }
        public string situacao { get; set; }
        public string raca { get; set; }
        public DateTime dataNascimento { get; set; }
        public DateTime dataPrenches { get; set; }
        public DateTime dataUltimoParto { get; set; }

    }
}