using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Model.EF;
namespace Model.Model
{
    public class NewsViewModel
    {
        public News news { get; set; }
        public string NameAdmin { get;  set; }
        public string NameType { get; set; }
    }
}