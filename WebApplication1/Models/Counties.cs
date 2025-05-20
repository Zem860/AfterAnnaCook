using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Counties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="縣市編號")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "縣市名稱")]
        [Column(TypeName ="nvarchar")]
        [MaxLength(20)]
        public string CountyName { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Districts> Districts { get; set; }

    }
}