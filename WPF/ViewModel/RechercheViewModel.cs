using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.Models;

namespace WPF.ViewModel
{
    class RechercheViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        public ObservableCollection<string> ChainsList { get; set; } = new ObservableCollection<string>() { "Item1", "Item2", "Item3", "Value1", "Value2", "Value3", "Test0", "Test1", "Test2", "Test3" };
        private ObservableCollection<string> _occurencesList = new ObservableCollection<string>();

        private string _sSearchChain;

        public string SearchChain
        {
            get { return _sSearchChain; }
            set 
            {
                _sSearchChain = value;
                OnPropertyChanged(nameof(SearchChain));
                filterResult(SearchChain);
            }
        }
        public ObservableCollection<string> OccurencesList {
            get { return _occurencesList; }
            set { _occurencesList = ChainsList; }
        }

        private void filterResult(string textSearch)
        {
            foreach (var s in ChainsList.Where(s => s?.ToLower().Contains(textSearch?.ToLower()) ?? false))
            {
                OccurencesList.Add(s);
            }
        }

    }
}
