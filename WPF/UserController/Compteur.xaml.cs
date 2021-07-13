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
using WPF.ViewModel;

namespace WPF.UserController
{
    /// <summary>
    /// Logique d'interaction pour Compteur.xaml
    /// </summary>
    /*
     * Faire un compteur : une page qui affiche un chiffre et 3 boutons (augmenter, descendre, réinitialiser) et un ViewModel qui contient un entier, 
     * le compteur, et 3 commandes pour les 3 actions (ou une commande avec le paramètre)
     */
    public partial class Compteur : UserControl
    {
        public Compteur()
        {
            InitializeComponent();
            DataContext = new CompteurViewModel();
            /*StackPanel stackPanel = new StackPanel();

            TextBlock textBlock = new TextBlock();
            textBlock.Name = "tbCount";
            
            textBlock.Width = 20;
            textBlock.Height = 20;
            stackPanel.Children.Add(textBlock);

            Button buttonUp = new Button();
            buttonUp.Name = "bUp";
            buttonUp.Content = "Up";
            stackPanel.Children.Add(buttonUp);

            Button buttonDown = new Button();
            buttonDown.Name = "bDown";
            buttonDown.Content = "Down";
            stackPanel.Children.Add(buttonDown);

            Button buttonReset = new Button();
            buttonReset.Name = "bReset";
            buttonReset.Content = "Reset";
            stackPanel.Children.Add(buttonReset);

            main.Children.Add(stackPanel);*/
        }
    }
}
