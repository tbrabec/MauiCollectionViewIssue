using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp9.ViewModels
{
    public class Item
    {
        public string Name { get; set; }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            LoadMoreItems();
        }
        private const int LoadItemCount = 20;
        public int RemainingItemsTreshold 
        {
            get { return LoadItemCount; } 
        }

        private Command _loadMoreItemsCommand;
        public Command LoadMoreItemsCommand { get { return _loadMoreItemsCommand ?? (_loadMoreItemsCommand = new Command(() => LoadMoreItems())); } }

        private int _itemCounter = 1;
        private void LoadMoreItems()
        {
            for (int i = _itemCounter; i < _itemCounter + LoadItemCount; i++)
            {
                var item = new Item { Name = $"Item {i}" };
                Items.Add(item);
            }
            _itemCounter = _itemCounter + LoadItemCount;
        }

        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get { return _items; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
