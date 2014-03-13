using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WT.Churrascometro.WP7.ViewModels
{
    public class CarneViewModel : ItemMarcadoViewModelBase
    {
        public decimal Peso { get; set; }

        public CarneViewModel()
        {
            PropertyChanged += CarneViewModelPropertyChanged;
        }

        //public string QuantidadeCalculada { get; set; }

        void CarneViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Marcado")
            {
                //QuantidadeCalculada = 100.ToString();
            }
        }
    }
}
