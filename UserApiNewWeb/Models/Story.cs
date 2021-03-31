using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserApiNewWeb.Models
{
    public class Story
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public string MyStory { get; set; }

        [StringLength(255)]
        public string FontAwesome { get; set; }

        [StringLength(100)]
        public string BackgroundColour { get; set; }

        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public int? GoogleFontsId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("GoogleFontsId")]
        public virtual GoogleFont GoogleFont { get; set; }

        [NotMapped]
        public virtual List<Love> Loves { get; set; }



    }
}
