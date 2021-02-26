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
        private int CurrentQuestionIndex = 1;
        public string CurrentQuestionIndexText = "1";

        public async Task InitAsync(int categoryId)
        {
            using(var context = new DefaultContext())
            {
                this.Questions = await context.Questions.Where(q => q.CategoryId == categoryId).OrderBy(q => new Guid()).Take(5).ToListAsync();
            }
           
        }

        public bool NextQuestion()
        {
            CurrentIndex++;
            CurrentQuestionIndex++;
            CurrentQuestionIndexText = CurrentQuestionIndex.ToString();
            if (CurrentIndex == 5) return true;
            else
            {
                this.CurrentQuestion = Questions[CurrentIndex];
                return false;
            }
        }

        public void SetAnswer()
        {
            //this.CurrentQuestion.Answer = 
        }
    }
}
