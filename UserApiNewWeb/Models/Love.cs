using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserApiNewWeb.Models
{
    public class Love
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoveId { get; set; }
       
        public string UserId { get; set; }
        public int  StoryId { get; set; }

        [ForeignKey("UserId")]
        public  ApplicationUser  ApplicationUser { get; set; } 


    }
}
