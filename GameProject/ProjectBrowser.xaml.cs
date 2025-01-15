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
using System.Windows.Shapes;

namespace StrayEditor.GameProject
{
    /// <summary>
    /// Interaction logic for ProjectBrowser.xaml
    /// </summary>
    public partial class ProjectBrowser : Window
    {
        public ProjectBrowser()
        {
            InitializeComponent();
        }

        private void OnToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender == openProjectButton)
            {
                if (newProjectButton.IsChecked == true)
                {
                    newProjectButton.IsChecked = false;
                    browserContent.Margin = new Thickness(0);
                }
            }
            else
            {
                if(openProjectButton.IsChecked == true)
                {
                    openProjectButton.IsChecked = false;
                    browserContent.Margin = new Thickness(-800, 0, 0, 0);
                }
            }
        }
    }
}
