using System;
using System.ComponentModel.DataAnnotations;

namespace project.Models
{
	public class projects
	{
        [Key]
        [Required]
        public int p_id { get; set; }
        [Required]
        public string project_name { get; set; }
       
        public string link { get; set; }
        [Required]
        public string tech_stack { get; set; }
        [Required]
        public string description { get; set; }

        public int user_id { get; set; }
    }

}

