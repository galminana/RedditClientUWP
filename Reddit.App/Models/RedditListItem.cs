using Humanizer;
using Reddit.App.Helpers;
using Reddit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.App.Models
{
    public class RedditListItem
    {
        public Post Value { get; set; }
        public bool Viewed { get; set; }
        public string created_redeable
        {
            get
            {
                return new DateTime(1970, 1, 1).AddSeconds(Convert.ToInt64(Value.created)).Humanize();
            }
        }
        public RelayCommand DismissCommand { get; private set; }
        public event Action<RedditListItem> DismissItem;
        public RedditListItem()
        {
            DismissCommand = new RelayCommand(new Action(Dismiss));
        }

        private void Dismiss()
        {
            if (DismissItem != null)
            {
                DismissItem.Invoke(this);
            }
        }
    }
}
