using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Data.Entities
{
    public class productBrand
    {
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string idBrand { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string brandName { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(200)")]
        public string brandDetail { get; set; }

        public virtual ICollection<products> Products { get; set; }
        public string LanguageId { set; get; }

        public Language Language { get; set; }


    }
}
