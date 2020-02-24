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
        public ObservableCollection<Post> Posts { get; private set; } = new ObservableCollection<Post>();
        public Post Selected { get; set; }
        public TopPostViewModel()
        {
        }
        internal async Task LoadDataAsync()
        {
            RedditData =  await RedditService.GetTopPost();
            Posts.Clear();
            foreach (var item in RedditData.data.children)
            {
                Posts.Add(item.data);
            }
        }
    }
}
