using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace FileViewer.Model
{
    public class TreeListItem
    {
        /// <summary>
        /// Vår modell som används i vår trädvisualiserare
        /// </summary>
        /// <param name="title"></param>
        /// <param name="parent"></param>
        public TreeListItem(string title, TreeListItem parent)
        {
            Title = title;
            Items = new ObservableCollection<TreeListItem>();
            Parent = parent;
        }

        /// <summary>
        /// Nodens förälder i trädet. Används för att lätt kunna navigera uppåt i trädet från en markering,
        /// specifikt användbart vid borttagning.
        /// </summary>
        public TreeListItem Parent { get; set; }

        /// <summary>
        /// Om noden har några barn så läggs de till i denna listan.
        /// </summary>
        public ObservableCollection<TreeListItem> Items { get; set; }

        /// <summary>
        /// Visningsnamnet på noden.
        /// </summary>
        public string Title { get; set; }
    }
}
