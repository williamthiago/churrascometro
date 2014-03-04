namespace WT.Churrascometro.WP7.ViewModels
{
    public class ItemSpinnerViewModelBase : NotifyPropertyChangedBase
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

        private int _quantidade;

        public int Quantidade
        {
            get
            {
                return _quantidade;
            }
            set
            {
                if (value != _quantidade)
                {
                    _quantidade = value;
                    NotifyPropertyChanged("Quantidade");
                }
            }
        }
    }
}