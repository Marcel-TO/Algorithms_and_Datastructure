using MazeGenerator_ViewModel.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
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

namespace MazeGenerator_View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.PolygonLayout = new PointCollection();
            InitializeComponent();
        }

        public PointCollection PolygonLayout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the DataContext for this application.
        /// </summary>
        /// <value> The ViewModel of the chessboard as DataContext.</value>
        public MainViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainViewModel;
            }
        }

        private void OnGenerateButton(object sender, RoutedEventArgs e)
        {
        }
    }
}
