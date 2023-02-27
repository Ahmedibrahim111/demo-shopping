using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Models
{
    public class ItemMangement
    {
      
            [Key]
            public int Id { get; set; }

            [Column(TypeName = "nvarchar(100)")]
            public string Name { get; set; }
            public decimal Price { get; set; }
            [Column(TypeName = "nvarchar(5)")]
            public int Size { get; set; }
            [Column(TypeName = "nvarchar(150)")]
           public string Attachement { get; set; }


    }
}
