using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quiz.Models
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public ICollection<Question> Questions { get; set; }
  
        
        public enum StatusEnum
        {
            /// <summary>
            /// Only use if, there is some error and you resume quiz
            /// </summary>
            Error = -1,
            /// <summary>
            /// User choosed category, but didn't start a quiz
            /// </summary>
            Created = 0,
            /// <summary>
            /// User started a quiz
            /// </summary>
            InProgress = 1,
            /// <summary>
            /// User finished a quiz
            /// </summary>
            Finished = 2
        }
    }
}
