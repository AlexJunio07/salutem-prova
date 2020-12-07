using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salutem.Model
{
    class Cliente
    {
        public long cod_cliente { get; set; }
        public string cnpj { get; set; }
        public string razao_social { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

    }
}
