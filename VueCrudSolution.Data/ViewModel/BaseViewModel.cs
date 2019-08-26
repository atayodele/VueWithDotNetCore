using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace VueCrudSolution.Data.ViewModel
{
    public abstract class BaseViewModel<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual T Id { get; set; }
        public virtual Boolean HasError
        {
            get
            {
                if (this.ErrorList.Any())
                    return true;

                return false;
            }
        }
        public virtual List<String> ErrorList { get; set; } = new List<String>();
    }

    public abstract class BaseViewModel : BaseViewModel<Guid>
    {
    }
}
