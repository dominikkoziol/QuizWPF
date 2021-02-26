using Microsoft.EntityFrameworkCore;
using Quiz.Context;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.ViewModels
{
    public class StartQuizViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// List of user
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// List of categories
        /// </summary>
        public List<Category> Categories { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Download data from db
        /// </summary>
        public async Task InitAsync(int id)
        {
            using(var context = new DefaultContext())
            {
                this.User = await context.Users.Where(q => q.Id == id).Include(q => q.Quizzes.Where(qu => qu.Status == Models.Quiz.StatusEnum.Finished)).ThenInclude(q => q.Category).FirstOrDefaultAsync();
                this.Categories = await context.Categories.ToListAsync();
            }
        }

    }
}
