using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class productSize
    {
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string idSize { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string sizeName { get; set; }
        public virtual ICollection<products> Products { get; set; }
        public string LanguageId { set; get; }

        public Language Language { get; set; }
    }
}
