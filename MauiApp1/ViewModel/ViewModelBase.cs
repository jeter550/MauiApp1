using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged<T>(Expression<Func<T>> expressao)
        {
            string name = ((MemberExpression)expressao.Body).Member.Name;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Page _pageContainer;
        public Page PageContainer
        {
            get
            {
                return _pageContainer;
            }
            set
            {
                _pageContainer = value;
                OnPropertyChanged(() => PageContainer);
            }
        }
    }
}
