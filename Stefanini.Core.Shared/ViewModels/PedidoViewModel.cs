using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Core.Shared.ViewModels
{
    public class PedidoViewModel
    {
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public bool Pago { get; set; }

        public IList<ItemPedidoViewModel> ItensPedido { get; set; }
    }
}
