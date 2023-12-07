using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    internal class MainPageViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private string _nome;
        public string Nome
        {
            get
            {
                return this._nome;
            }
            set
            {
                this._nome = value;
                this.OnPropertyChanged(() => Nome);
               
            }
        }
    }
}
