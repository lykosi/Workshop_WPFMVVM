using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    public class Message : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(_id)); //nameof() C#6.0
            }
        }
        public string Contenu { get; set; }
        public string Emetteur { get; set; }
        public DateTime Date { get; set; }
        public Message(string sContenu, string sEmetteur, DateTime dtDate) => (Contenu, Emetteur, Date) = (sContenu, sEmetteur, dtDate);

        public override string ToString() => $"{Contenu}, {Emetteur}, {Date.ToString("dd/MM/yyyy")}";
    }
}
