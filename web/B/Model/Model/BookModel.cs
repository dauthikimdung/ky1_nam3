using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
   public class BookModel
    {
        public Book Book { get; set; }
        public string NameAuthor { get; set; }
       
        public string NameReleased { get; set; }
        public string NamePublisher { get; set; }
        public string NameType { get; set; }
    }
}
