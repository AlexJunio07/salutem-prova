using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salutem.Model
{
    class Cliente : Vendedor
    {
        public long cod_cliente { get; set; }
        public long cod_vendedor_fk { get; set; }
        public string distancia { get; set; }
        public string cnpj { get; set; }
        public string razao_social { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
