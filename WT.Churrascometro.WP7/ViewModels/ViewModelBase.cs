namespace WT.Churrascometro.WP7.ViewModels
{
    public class ItemMarcadoViewModelBase : NotifyPropertyChangedBase
    {
        private string _nome;

        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (value != _nome)
                {
                    _nome = value;
                    NotifyPropertyChanged("Nome");
                }
            }
        }

        private bool _marcado;

        public bool Marcado
        {
            get
            {
                return _marcado;
            }
            set
            {
                if (value != _marcado)
                {
                    _marcado = value;
                    NotifyPropertyChanged("Marcado");
                }
            }
        }
    }
}
