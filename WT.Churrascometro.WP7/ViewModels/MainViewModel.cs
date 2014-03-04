using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Serialization;
using WT.Churrascometro.WP7.Model;

namespace WT.Churrascometro.WP7.ViewModels
{
    public class MainViewModel : NotifyPropertyChangedBase
    {
        public MainViewModel()
        {
            this.Bovinos = new ObservableCollection<CarneViewModel>();
            this.Suinos = new ObservableCollection<CarneViewModel>();
            this.Frangos = new ObservableCollection<CarneViewModel>();
            this.Pessoas = new ObservableCollection<PessoaViewModel>();
            this.Acompanhamentos = new ObservableCollection<AcompanhamentoViewModel>();
            this.Resultados = new ObservableCollection<ResultadoViewModel>();
        }

        private PessoaViewModel Homens
        {
            get { return Pessoas.FirstOrDefault(p => p.Nome == "Homens"); }
        }
        private PessoaViewModel Mulheres
        {
            get { return Pessoas.FirstOrDefault(p => p.Nome == "Mulheres"); }
        }
        private PessoaViewModel Criancas
        {
            get { return Pessoas.FirstOrDefault(p => p.Nome == "Crianças"); }
        }

        public ObservableCollection<PessoaViewModel> Pessoas { get; private set; }
        public ObservableCollection<CarneViewModel> Bovinos { get; private set; }
        public ObservableCollection<CarneViewModel> Suinos { get; private set; }
        public ObservableCollection<CarneViewModel> Frangos { get; private set; }
        public ObservableCollection<AcompanhamentoViewModel> Acompanhamentos { get; private set; }
        public ObservableCollection<ResultadoViewModel> Resultados { get; private set; }

        public void Calcular()
        {
            this.Resultados.Clear();

            if (Homens.Quantidade + Mulheres.Quantidade + Criancas.Quantidade <= 2)
            {
                this.Resultados.Add(new ResultadoViewModel() { Item = "arrumar + amigos!" });
                return;
            }
            if (!Bovinos.Any(b => b.Marcado) && !Suinos.Any(b => b.Marcado) && !Frangos.Any(b => b.Marcado) && !Acompanhamentos.Any(b => b.Marcado))
            {
                this.Resultados.Add(new ResultadoViewModel() { Item = "escolher algo!" });
                return;
            }

            decimal totalGrupos = 0;
            if (Bovinos.Any(b => b.Marcado))
                totalGrupos += .5m;
            if (Frangos.Any(b => b.Marcado))
                totalGrupos += .1m;
            if (Suinos.Where(s => !s.Nome.Contains("Linguiça")) .Any(b => b.Marcado))
                totalGrupos += .1m;
            if (Suinos.Where(s => s.Nome.Contains("Linguiça")).Any(b => b.Marcado))
                totalGrupos += .3m;

            foreach (var bovino in Bovinos.Where(b => b.Marcado))
            {
                decimal totalItens = Bovinos.Where(b => b.Marcado).Sum(b => b.Peso);
                decimal pesoGrupo = .5m / totalGrupos;
                decimal pesoItem = bovino.Peso;

                decimal quantidade = ((Homens.Quantidade*Homens.Peso + Mulheres.Quantidade*Mulheres.Peso +
                                       Criancas.Quantidade*Criancas.Peso))*
                                     pesoGrupo*(pesoItem/totalItens);
                quantidade = Math.Round(quantidade*100)/100;

                this.Resultados.Add(new ResultadoViewModel() { Item = bovino.Nome, Quantidade = string.Format("{0} kg", quantidade)});
            }

            foreach (var suino in Suinos.Where(b => b.Marcado))
            {
                decimal totalItens = Suinos.Where(b => b.Marcado).Sum(b => b.Peso);
                decimal pesoGrupo = .1m / totalGrupos;
                decimal pesoItem = suino.Peso;

                decimal quantidade = ((Homens.Quantidade * Homens.Peso + Mulheres.Quantidade * Mulheres.Peso +
                                       Criancas.Quantidade * Criancas.Peso)) *
                                     pesoGrupo * (pesoItem / totalItens);
                quantidade = Math.Round(quantidade * 100) / 100;

                this.Resultados.Add(new ResultadoViewModel() { Item = suino.Nome, Quantidade = string.Format("{0} kg", quantidade) });
            }

            foreach (var frango in Frangos.Where(b => b.Marcado))
            {
                decimal totalItens = Frangos.Where(b => b.Marcado).Sum(b => b.Peso);
                decimal pesoGrupo = .1m / totalGrupos;
                decimal pesoItem = frango.Peso;

                decimal quantidade = ((Homens.Quantidade * Homens.Peso + Mulheres.Quantidade * Mulheres.Peso +
                                       Criancas.Quantidade * Criancas.Peso)) *
                                     pesoGrupo * (pesoItem / totalItens);
                quantidade = Math.Round(quantidade * 100) / 100;

                this.Resultados.Add(new ResultadoViewModel() { Item = frango.Nome, Quantidade = string.Format("{0} kg", quantidade) });
            }

            foreach (var acompanhamento in Acompanhamentos.Where(b => b.Marcado))
            {
			    var divider = acompanhamento.PesoD;
			    var unidade = acompanhamento.Medida;

                var quantidade = Math.Ceiling(
                    (double)((Homens.Quantidade * acompanhamento.PesoA +
                     Mulheres.Quantidade*acompanhamento.PesoB +
                     Criancas.Quantidade*acompanhamento.PesoC)/divider));
			
                this.Resultados.Add(new ResultadoViewModel() { Item = acompanhamento.Nome, Quantidade = string.Format("{0} {1}{2}", quantidade, unidade, quantidade > 1 ? "s" : "") });
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        private T Deserialize<T>()
        {
            var serializer = new XmlSerializer(typeof(T));
            var reader = XmlReader.Create(string.Format("Data/{0}.xml", typeof(T).Name));
            return (T)serializer.Deserialize(reader);
        }
        
        public void LoadData()
        {
            #region Bovinos

            var bovinos = Deserialize<Bovinos>();
            foreach (var bovino in bovinos.Itens)
                this.Bovinos.Add(new CarneViewModel() {Nome = bovino.Nome, Peso = bovino.Peso });
            
            #endregion

            #region Suinos

            var suinos = Deserialize<Suinos>();
            foreach (var suino in suinos.Itens)
                this.Suinos.Add(new CarneViewModel() { Nome = suino.Nome, Peso = suino.Peso });

            #endregion

            #region Frangos

            var frangos = Deserialize<Frangos>();
            foreach (var frango in frangos.Itens)
                this.Frangos.Add(new CarneViewModel() { Nome = frango.Nome, Peso = frango.Peso });

            #endregion

            #region Acompanhamentos

            var acompanhamentos = Deserialize<Acompanhamentos>();
            foreach (var acompanhamento in acompanhamentos.Itens)
                this.Acompanhamentos.Add(new AcompanhamentoViewModel() { Nome = acompanhamento.Nome, 
                    PesoA = acompanhamento.PesoA, 
                    PesoB = acompanhamento.PesoB, 
                    PesoC = acompanhamento.PesoC, 
                    Medida = acompanhamento.Medida,
                    PesoD = acompanhamento.PesoD
                });

            #endregion

            #region Pessoas

            this.Pessoas.Add(new PessoaViewModel() { Nome = "Homens", Quantidade = 0, Peso = .5m });
            this.Pessoas.Add(new PessoaViewModel() { Nome = "Mulheres", Quantidade = 0, Peso = .3m });
            this.Pessoas.Add(new PessoaViewModel() { Nome = "Crianças", Quantidade = 0, Peso = .2m });

            #endregion

            this.IsDataLoaded = true;
        }
    }
}