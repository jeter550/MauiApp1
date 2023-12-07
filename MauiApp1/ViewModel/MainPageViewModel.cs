using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        #region [ contructors ]
        public MainPageViewModel()
        {
            this.GerarSimuacaoCommand = new Command(GearNovaSimulacaoButtonClick);
        }
        #endregion

        #region [ properties ]
        private double _procofinal;
        /// <summary>
        /// Preço inicial
        /// </summary>
        public double PrecoInicial
        {
            get
            {
                return this._procofinal;
            }
            set
            {
                this._procofinal = value;
                this.OnPropertyChanged(() => PrecoInicial);
            }
        }

        private double _valotilidade;
        /// <summary>
        /// Mean
        /// </summary>
        public double Valotilidade
        {
            get
            {
                return this._valotilidade;
            }
            set
            {
                this._valotilidade = value;
                this.OnPropertyChanged(() => Valotilidade);
            }
        }

        private double _retorno;
        /// <summary>
        /// Sigma
        /// </summary>
        public double Retorno
        {
            get
            {
                return this._retorno;
            }
            set
            {
                this._retorno = value;
                this.OnPropertyChanged(() => Retorno);
            }
        }

        private int _tempoDias;
        /// <summary>
        /// Número de dias
        /// </summary>
        public int TempoDias
        {
            get
            {
                return this._tempoDias;
            }
            set
            {
                this._tempoDias = value;
                this.OnPropertyChanged(() => TempoDias);
            }
        }

        List<GraphicItem> _fonteDeDados;
        public List<GraphicItem> FonteDeDados
        {

            get
            {
                return _fonteDeDados;
            }
            set
            {
                _fonteDeDados = value;
                OnPropertyChanged(() => FonteDeDados);
            }
        }
        #endregion

        #region [ methods ]
        private async void GearNovaSimulacaoButtonClick(object obj)
        {
            try
            {
                double[] valoresSomulacao = Util.Statics.GenerateBrownianMotion(
                    sigma: this.Retorno,
                    mean: this.Valotilidade,
                    initialPrice: this.PrecoInicial,
                    numDays: this.TempoDias
                );

                List<GraphicItem> fonteDeDados = new List<GraphicItem>(valoresSomulacao.Length);
                foreach (var item in valoresSomulacao)
                {
                    fonteDeDados.Add(new GraphicItem(item));
                }

                this.FonteDeDados = fonteDeDados;

            }
            catch (Exception ex)
            {
                await PageContainer.DisplayAlert("Erro", $"Verifique os valores inseridos e tente novamente. Descrição do erro: { ex.Message }", "Fechar");
            }

            

        }
        #endregion

        #region [ commands ]

        private ICommand _gerarSimuacaoCommand;

        public ICommand GerarSimuacaoCommand
        {
            get
            {
                return _gerarSimuacaoCommand;
            }
            set
            {
                _gerarSimuacaoCommand = value;
                OnPropertyChanged(() => GerarSimuacaoCommand);
            }
        }

        #endregion
    }
}
