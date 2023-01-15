using Microsoft.AspNetCore.Http;
using MyBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Entity
{
    public class Blog:BaseEntity
    {
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogWriterName { get; set; }
        
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }


    }
}
