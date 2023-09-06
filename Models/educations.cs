using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class educations
    {
        [Key]
        [Required]
        public int edu_id { get; set; }

        [Required]
        public string college_name { get; set; }

        [Required]
        public DateTime start_date { get; set; }

      
        public DateTime? end_date { get; set; }

        [Required]
        public string board { get; set; }

        [Required]
        public string degree { get; set; }

         
        public int user_id { get; set; }
    }
}