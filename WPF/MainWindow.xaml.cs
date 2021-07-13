using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.UserController;
using WPF.ViewModel;

namespace WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
    /*- Faire une propriété et l’afficher en binding dans l’interface
      - Faire un champs texte qui modifie cette valeur
      - Faire un bouton avec une Command qui modifie la valeur de la propriété */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            Compteur.Content = new Compteur();
            Recherche.Content = new Recherche();

            

        }
    }
}
