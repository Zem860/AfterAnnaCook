using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Others
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "編號")]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(20)]
        [Display(Name = "其他")]
        public string Other { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "建立時間")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<FormData> FormDatas { get; set; } = new List<FormData>();
    }
}