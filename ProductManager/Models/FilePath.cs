using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
    public class FilePath
    {
        [Key]
        public int FilePathId { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }
        public FileType FileType { get; set; }
        
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }
    }
}