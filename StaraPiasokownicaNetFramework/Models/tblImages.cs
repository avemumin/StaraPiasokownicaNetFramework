using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StaraPiasokownicaNetFramework.Models
{
    [Table("dbo.tblImages")]
    public class tblImages
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public byte[] ImageDate { get; set; }
    
       
    }
}