using System;
using System.ComponentModel.DataAnnotations;

namespace project.Models
{
	public class skills
	{
        [Key]
        [Required]
        public int ski_id { get; set; }
       
        [Required]
        public string skill_name { get; set; }

        public int user_id { get; set; }


    }
}

