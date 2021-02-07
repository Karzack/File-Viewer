using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using FileViewer.Model;
using Newtonsoft.Json;

namespace FileViewer.UI.ViewModel
{
    public class FileViewerViewModel : ViewModelBase
    {
        #region Private Members
        private TreeListItem _root;
        private TreeListItem _selectedItem;

       #endregion

        #region Initialize

        /// <summary>
        /// Uppstarten av vymodellen. Här defineras 
        /// </summary>
        public void Load()
        {
            Root = new TreeListItem("Root", null);
            SelectedItem = Root;
        }

        /// <summary>
        /// Skapar trädet och ställer in rootnoden
        /// </summary>
        /// <param name="trvFileViewer"></param>
        /// <returns></returns>
        public TreeView InitializeTree(TreeView trvFileViewer)
        {
            trvFileViewer.Items.Add(_root);
            return trvFileViewer;
        }

        #endregion

        #region Properties
        
        /// <summary>
        /// Den markerade noden i trädet
        /// </summary>
        public TreeListItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = (TreeListItem)value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Rotnoden i trädet
        /// </summary>
        public TreeListItem Root
        {
            get { return _root; }
            set
            {
                _root = value;
                OnPropertyChanged();
            }}
        #endregion

        #region Public methods
        

        /// <summary>
        /// Denna metoden är tillagd specifikt för att fylla JSON-objektet från instruktionerna snabbt
        /// </summary>
        public void FillDemoTree()
        {
            var demoString = "[" +
                             "\"marvel/black_widow/bw.png\"," +
                             "\"marvel/drdoom/the-doctor.png\"," +
                             "\"fact_marvel_beats_dc.txt\"," +
                             "\"dc/aquaman/mmmmmomoa.png\"," +
                             "\"marvel/black_widow/why-the-widow-is-awesome.txt\"," +
                             "\"dc/aquaman/movie-review-collection.txt\"," +
                             "\"marvel/marvel_logo.png\"," +
                             "\"dc/character_list.txt\"" +
                             "]";
            var reader = new JsonTextReader(new StringReader(demoString));
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    AddNewElementFromStringToTree(reader.Value.ToString());
                }
            }
        }

        /// <summary>
        /// Lägger till en ny nod från en textsträng ifrån parametern och
        /// mappar upp noderna i ordning från rootnoden.
        /// Om noden redan existerar så läggs nästa nod som barn till den matchande
        /// noden istället för att skapa en ny.
        /// </summary>
        /// <param name="inputString"></param>
        private void AddNewElementFromStringToTree( string inputString)
        {
            var splitter = inputString.Split('/'); 
            var currentTreeNode = Root; 

            foreach (string item in splitter)
            {
                var newTreeNode = new TreeListItem(item, currentTreeNode);
                if (currentTreeNode.Items.All(x => x.Title != newTreeNode.Title))  
                {
                    currentTreeNode.Items.Add(newTreeNode);
                    currentTreeNode = newTreeNode;
                }
                else
                {
                    currentTreeNode = currentTreeNode.Items.First(x => x.Title == newTreeNode.Title);
                }
                
            }
        }

        /// <summary>
        /// Lägger till en ny nod på den markerade noden (eller root om ingen är markerad)
        /// </summary>
        /// <param name="title"></param>
        public void addNewItem(string title)
        {
                SelectedItem.Items.Add(new TreeListItem(title, SelectedItem));
        }

        /// <summary>
        /// Tar bort den markerade noden. Om noden har undernoder så kommer dessa också rensas,
        /// precis på samma sätt som om man tar bort en mapp i Windows.
        /// </summary>
        /// <param name="selectedItem"></param>
        public void RemoveItem()
        {
            if (SelectedItem.Parent != null && SelectedItem != null) //Root får inte tas bort.
                SelectedItem.Parent.Items.Remove(SelectedItem);
            else
                MessageBox.Show("The root folder is not allowed to be removed.", "Illegal removal!");
        }   
        #endregion

    }
}
