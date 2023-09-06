using System;
using System.ComponentModel.DataAnnotations;
namespace project.Models
{
	public class certificates
	{

        [Key]
        [Required]
        public int certif_id { get; set; }
        [Required]
        public string title{ get; set; }
        [Required]
        public string issued_name { get; set; }
        [Required]
        public string link { get; set; }
        [Required]
        public DateTime issued_date { get; set; }

        public int user_id { get; set; }
    }
}

