using System;
using System.ComponentModel.DataAnnotations;

namespace project.Models
{
	public class experiences
	{
        [Key]
        [Required]
        public int exp_id { get; set; }
        [Required]
        public string institution_name { get; set; }
        [Required]
        public DateTime started_date { get; set; }
     
        public DateTime? ended_date { get; set; }
        [Required]
        public string position { get; set; }
        [Required]
        public string tech_used { get; set; }

        public int user_id { get; set; }

    }
}

