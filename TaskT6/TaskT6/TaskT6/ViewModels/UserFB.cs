using System;
using System.Collections.Generic;
using System.Text;

namespace TaskT6.ViewModels
{
    public class UserFB
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public Picture Picture { get; set; }

    }
    public class Data
    {
        public string Url;
        public bool IsSilhouette { get; set; }

    }
    public class Picture
    {
        public Data Data { get; set; }
    }
    
}
