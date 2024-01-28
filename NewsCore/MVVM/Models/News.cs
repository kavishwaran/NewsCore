using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCore.MVVM.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Description { get; set; } 
        public DateTime? PublishedAt { get; set; }
        public Source Source { get; set; }
        public string Title { get; set; }
        public string Url { get; set; } 


   
   
    }
}
