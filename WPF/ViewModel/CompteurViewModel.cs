using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Models;

namespace WPF.ViewModel
{
    class CompteurViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        private int _iCount = new Random().Next(0, 100);

        public int Count
        {
            get { return _iCount; }
            set
            {
                _iCount = value;
                OnPropertyChanged(nameof(Count)); //nameof() C#6.0
            }
        }

        public ICommand Up
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Count++;
                });
            }
        }
        public ICommand Down
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Count--;
                });
            }
        }
        public ICommand Reset
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Count = 0;
                });
            }
        }
    }
}
