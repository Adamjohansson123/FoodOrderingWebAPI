using System;
using System.Collections.Generic;
using System.Text;

namespace FlickerAPIClient.JSON
{
    public class Photo
    {
        public string id { get; set; }
        public string owner { get; set; }
        public string secret { get; set; }
        public string server { get; set; }
        public int farm { get; set; }
        public string title { get; set; }
        public int ispublic { get; set; }
        public int isfriend { get; set; }
        public int isfamily { get; set; }

        public string getLink()
        {
            //https://farm{farm-id}.staticflickr.com/{server-id}/{id}_{secret}.jpg
            string link = "https://farm"+this.farm+".staticflickr.com/"+this.server+"/"+this.id+"_"+this.secret+".jpg";
            return link;
        }
    }
}
