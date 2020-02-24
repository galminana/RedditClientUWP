using Reddit.App.Helpers;
using Reddit.App.Models;
using Reddit.Core.Models;
using Reddit.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.App.ViewModels
{
    public class TopPostViewModel: BaseViewModel
    {
        public RedditDTO RedditData { get; set; }
        public ObservableCollection<RedditListItem> Posts { get; private set; } = new ObservableCollection<RedditListItem>();
        public Post _selected = new Post {  url="na"};
        public Post Selected {
            get { return _selected; }
            set {Set(ref _selected, value);}
        }
        public RelayCommand DismissCommand { get; private set; }
        public RelayCommand DismissAllCommand { get; private set; }
        public TopPostViewModel()
        {
            //DismissCommand = new RelayCommand(new Action(Dismiss));
            DismissAllCommand = new RelayCommand(new Action(DismissAll));
        }

        private void Dismiss(RedditListItem value)
        {
            Posts.Remove(value);
        }

        private void DismissAll()
        {
            Posts.Clear();
        }

        internal async Task LoadDataAsync()
        {
            RedditData =  await RedditService.GetTopPost();
            Posts.Clear();
            RedditListItem value;
            foreach (var item in RedditData.data.children)
            {
                value = new RedditListItem { Value = item.data };
                value.DismissItem += Dismiss;
                Posts.Add(value);
            }
        }

        public void Select( RedditListItem item)
        {
            //Posts.Where(i => i.Value.id == item.Value.id).First().Viewed = true;
            item.Viewed = true;
            OnPropertyChanged("Posts");
            Selected = item.Value;
        }
    }
}
