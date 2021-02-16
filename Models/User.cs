using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quiz.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nick { get; set; }
        public SexEnum Sex { get; set; }


        public enum SexEnum
        {
            Man = 0,
            Woman = 1 
        }
    }
}
