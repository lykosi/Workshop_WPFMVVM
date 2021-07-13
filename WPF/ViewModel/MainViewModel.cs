using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPF.Models;

namespace WPF.ViewModel
{

    /*  - Faire une propriété et l’afficher en binding dans l’interface
        - Faire un champs texte qui modifie cette valeur
        - Faire un bouton avec une Command qui modifie la valeur de la propriété
        - Faire une liste de String et l’afficher en binding dans une listebox
        - Faire 3 boutons avec des commandes : Ajouter élément / Modifier le premier élément / supprimer le premier élément. 
        L’interface doit se mettre à jour automatiquement. Le bouton supprimer ne doit pas être accessible s’il n’y a plus d’élément dans la liste. 
        - Faire un bouton supprimer l’élément sélectionné sur la liste de message (s’aider de la propriété SelectedIndex de la listbox)
        - Faire un champ qui affiche un nombre du viewmodel, ce nombre est mis à jour par une commande et il est généré de façon aléatoire. 
        Si le nombre est < à 10 il doit s’afficher en rouge, s’il est > 10 il doit s’afficher en vert
    */

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }

        private string _propertyString = "Hello";
        private int _propertyInt = new Random().Next(0, 20);

        private ObservableCollection<string> _propertyList = new ObservableCollection<string>() { "Hello", "World", "!" };
        private int _propertyListIndex = -1;

        private ObservableCollection<Message> _MessageList = new ObservableCollection<Message>() {
        new Message("C" + new Random().Next(0, 30), "E" + new Random().Next(0, 30), new DateTime(new Random().Next(1950, 2021), new Random().Next(1, 12), new Random().Next(1, 31))),
        new Message("C" + new Random().Next(0, 30), "E" + new Random().Next(0, 30), new DateTime(new Random().Next(1950, 2021), new Random().Next(1, 12), new Random().Next(1, 31))),
        new Message("C" + new Random().Next(0, 30), "E" + new Random().Next(0, 30), new DateTime(new Random().Next(1950, 2021), new Random().Next(1, 12), new Random().Next(1, 31)))
        };
        private int _messageIndex = -1;

        private List<Images> _lImg = new List<Images>() {
        new Images(@"Images/Paladin.png"),
        new Images(@"Images/Monk.png"),
        new Images(@"Images/Chaman.png")
        };
       
        public List<Images> ImageList
        {
            get { return _lImg; }
            set { _lImg = value; }
        }

        public ObservableCollection<Message> MessageList
        {
            get { return _MessageList; }
            set { _MessageList = value; }
        }

        public int MessageIndex
        {
            get { return _messageIndex; }
            set { _messageIndex = value; }
        }

        public ICommand Delete
        {
            get
            {
                return new RelayCommand(param => { MessageList.Remove((Message)param); });
            }
        }

        public ICommand DeleteMessage
        {
            get
            {
                return new RelayCommand(param => { MessageList.RemoveAt(MessageIndex); }, param => MessageIndex > -1);
            }
        }

        public ICommand AddMessage
        {
            get
            {
                return new RelayCommand(param => { MessageList.Add(new Message("C" + new Random().Next(0, 30), "E" + new Random().Next(0, 30), new DateTime(new Random().Next(1950, 2021), new Random().Next(1, 12), new Random().Next(1, 31)))); });
            }
        }

        public int PropertyListIndex
        {
            get { return _propertyListIndex; }
            set { _propertyListIndex = value; }
        }

        public int PropertyInt
        {
            get { return _propertyInt; }
            set
            {
                _propertyInt = value;
                OnPropertyChanged(nameof(PropertyInt)); //nameof() C#6.0
            }
        }

        public ICommand MajProperty
        {
            get
            {
                return new RelayCommand(param =>
                {
                    PropertyInt = new Random().Next(0, 20);
                });
            }
        }

        public string PropertyString
        {
            get { return _propertyString; }
            set {
                _propertyString = value;
                OnPropertyChanged(nameof(PropertyString)); //nameof() C#6.0
            }
        }

        public ICommand EditProperty
        {
            get
            {
                return new RelayCommand(param =>
                {
                    PropertyString = "ChangedValue";
                });
            }
        }

        public ObservableCollection<string> PropertyList
        {
            get { return _propertyList; }
            set { _propertyList = value; }
        }

        public ICommand EditFirstList
        {
            get
            {
                return new RelayCommand(param => { PropertyList[0] = "Edited"; }, param => PropertyList.Count > 0);
            }
        }
        public ICommand DeleteFirstList
        {
            get
            {
                return new RelayCommand(param => { PropertyList.RemoveAt(0); }, param => PropertyList.Count > 0);             
            }
        }

        public ICommand DeleteList
        {
            get
            {
                return new RelayCommand(param => { PropertyList.RemoveAt(PropertyListIndex); }, param => PropertyListIndex > -1);
            }
        }

        public ICommand AddList
        {
            get
            {
                return new RelayCommand(param => { PropertyList.Add("New person n°10" + new Random().Next(0, 100)); });
            }
        }
    }
}



