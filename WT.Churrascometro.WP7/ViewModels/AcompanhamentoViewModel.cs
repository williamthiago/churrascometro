using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WT.Churrascometro.WP7.ViewModels
{
    public class AcompanhamentoViewModel : ItemMarcadoViewModelBase
    {
        public decimal PesoA { get; set; }
        public decimal PesoB { get; set; }
        public decimal PesoC { get; set; }
        public decimal PesoD { get; set; }
        public string Medida { get; set; }

        
    }
}
