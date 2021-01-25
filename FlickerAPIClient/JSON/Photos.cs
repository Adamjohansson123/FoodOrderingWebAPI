using System;
using System.Collections.Generic;
using System.Text;

namespace FlickerAPIClient.JSON
{
    public class Photos
    {
        public int page { get; set; }
        public int pages { get; set; }
        public int perpage { get; set; }
        public string total { get; set; }
        public List<Photo> photo { get; set; }
    }
}
