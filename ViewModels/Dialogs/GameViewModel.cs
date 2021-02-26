using Microsoft.EntityFrameworkCore;
using Quiz.Context;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.ViewModels.Dialogs
{
    public class GameViewModel: INotifyPropertyChanged
    {
        public List<Question>Questions { get; set; }
        public Question CurrentQuestion { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public int CurrentIndex = 0;
        private Models.Quiz Quiz { get; set; }
         public int CurrentQuestionIndex { get; set; } = 1;

        public async Task InitAsync(int categoryId, int userId)
        {
            using(var context = new DefaultContext())
            {
                this.Questions = await context.Questions.Where(q => q.CategoryId == categoryId).OrderBy(q => new Guid()).Take(5).ToListAsync();
                this.CurrentQuestion = this.Questions[0];
                Quiz = new Models.Quiz()
                {
                    StartTime = DateTime.Now,
                    Status = Models.Quiz.StatusEnum.InProgress,
                    CategoryId = categoryId,
                    UserId = userId
                };
            }
           
        }

        public bool NextQuestion()
        {
            CurrentIndex++;
            CurrentQuestionIndex++;
            if (CurrentIndex == 5) return true;
            else
            {
                this.CurrentQuestion = Questions[CurrentIndex];
                return false;
            }
        }
        public async Task Finish()
        {
            int result = 0;
            Questions.ForEach(element => {
                if (element.CorrectAnswer == element.Answer)
                {
                    result += 1;
                }
            });

            Quiz.CollectedScores = result;
            Quiz.FinishTime = DateTime.Now;
            Quiz.Status = Models.Quiz.StatusEnum.Finished;

            using(var context = new DefaultContext())
            {
                context.Quizzes.Add(Quiz);
                await context.SaveChangesAsync();
            }
        }

        public void SetAnswer(string answer)
        {
            switch(answer) {
                case "answerA":
                    this.CurrentQuestion.Answer = Question.AnswerEnum.A; 
                    break;
                case "answerB":
                    this.CurrentQuestion.Answer = Question.AnswerEnum.B;
                    break;
                case "answerC":
                    this.CurrentQuestion.Answer = Question.AnswerEnum.C;
                    break;
                case "answerD":
                    this.CurrentQuestion.Answer = Question.AnswerEnum.D;
                    break;
            }
            //
        }
    }
}
