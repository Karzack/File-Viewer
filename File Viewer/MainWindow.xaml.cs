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
using FileViewer.Model;
using FileViewer.UI.ViewModel;

namespace FileViewer.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members
        
        private FileViewerViewModel _viewModel;
        #endregion

        #region ctor
        
        public MainWindow(FileViewerViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = viewModel;
            Loaded += MainWindow_Loaded;
        }
        #endregion

        #region Private methods
        
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
            UpdateTree();
            
        }

        private void UpdateTree()
        {
            trvFileViewer = _viewModel.InitializeTree(trvFileViewer);
        }


        /// <summary>
        /// Lägger till en ny nod antingen på markerad nod eller
        /// i roten. Om ingen titel anges visas felmeddelande.
        /// Efter att noden skapats så nollställs titelfältet och
        /// griden stänger sig igen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(AddItemTitle.Text))
            {
                _viewModel.addNewItem(AddItemTitle.Text);
                AddItemTitle.Text = "";
                AddItemGrid.Visibility = Visibility.Collapsed;
                AddButtonOpener.Content = "Lägg till";
            }
            else
            {
                MessageBox.Show("No title is set for the new node.", "Error!");
            }
        }

        private void ButtonRemove_OnClick(object sender, RoutedEventArgs e)
        {
            if (trvFileViewer.SelectedItem != null)
                _viewModel.RemoveItem();
        }
        
        private void TrvFileViewer_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            _viewModel.SelectedItem = (TreeListItem)trvFileViewer.SelectedItem;
        }

        //öppna "Lägg till" griden
        private void ButtonOpenAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (AddItemGrid.Visibility == Visibility.Collapsed)
            {
                AddItemGrid.Visibility = Visibility.Visible;
                AddButtonOpener.Content = "Stäng";
            }
            else
            {
                AddItemGrid.Visibility = Visibility.Collapsed;
                AddButtonOpener.Content = "Lägg till";
            }
        }

        private void ButtonDemo_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.FillDemoTree();
            DemoButton.Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}
