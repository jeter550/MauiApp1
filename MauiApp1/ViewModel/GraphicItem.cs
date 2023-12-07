using MauiApp1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{    public class GraphicItem : ViewModelBase
    {
        public GraphicItem(double valor_)
        {
            this.Valor = valor_;
        }
        private double _valor;

        public double Valor
        {
            get
            {
                return _valor;
            }
            set
            {
                _valor = value;
                OnPropertyChanged(() => Valor);
            }
        }
    }
}
