using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using TheReel.WebService;

namespace TheReel
{
    public class TopicsViewModel
    {
        public ObservableCollection<Topic> Topics { get; set; }

        public string TopicOneName
        {
            get
            {
                if (Topics.Count >= 1)
                {
                    return Topics[0].name;
                }
                return null;
            }
        }

        public string TopicTwoName
        {
            get
            {
                if (Topics.Count >= 2)
                {
                    return Topics[1].name;
                }
                return null;
            }
        }

        public string TopicThreeName
        {
            get
            {
                if (Topics.Count >= 3)
                {
                    return Topics[2].name;
                }
                return null;
            }
        }

        //grabs 3 most recent topics and lazy loads them
        public TopicsViewModel()
        {
            Topics = new ObservableCollection<Topic>();
            TopicsDAO topicsWeb = new TopicsDAO();
            foreach(var topic in topicsWeb.getActiveTopics())
            {
                Topics.Add(topic);
            }
        }
    }
}
