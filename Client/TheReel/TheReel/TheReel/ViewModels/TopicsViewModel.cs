using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace TheReel
{
    public class TopicsViewModel
    {
        public ObservableCollection<Topic> Topics { get; set; }

        public Topic TopicOne
        {
            get
            {
                if (Topics.Count >= 1)
                {
                    return Topics[0];
                }
                return null;
            }
        }

        public Topic TopicTwo
        {
            get
            {
                if (Topics.Count >= 2)
                {
                    return Topics[1];
                }
                return null;
            }
        }

        public Topic TopicThree
        {
            get
            {
                if (Topics.Count >= 3)
                {
                    return Topics[2];
                }
                return null;
            }
        }

        public TopicsViewModel()
        {
            // get topics here
        }
    }
}
