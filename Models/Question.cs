using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Quiz.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string QuestionDescription { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public int QuestionLevel { get; set; }
        public AnswerEnum CorrectAnswer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public AnswerEnum Answer { get; set; }

        public enum AnswerEnum
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4
        }
    }
}
