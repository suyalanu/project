using System.ComponentModel.DataAnnotations;

namespace project.Models
{
	public class infos
	{
        [Key]
        [Required]
        public int user_id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string password { get; set; }
        [Required]
        public string summary { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phone_no { get; set; }
        [Required]
        public string linkedin { get; set; }
    }
}

