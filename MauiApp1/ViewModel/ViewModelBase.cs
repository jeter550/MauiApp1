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
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged<T>(Expression<Func<T>> f)
        {
            string name = ((MemberExpression)f.Body).Member.Name;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
