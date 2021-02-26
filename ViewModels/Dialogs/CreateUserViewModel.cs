using Quiz.Context;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using static Quiz.Models.User;

namespace Quiz.ViewModels.Dialogs
{
    public class CreateUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Create user and save data to db
        /// </summary>
        /// <param name="name">Name of user</param>
        /// <param name="sex">Sex of user</param>
        /// <returns>Return true if everything is success</returns>
        public async Task<bool> CreateUser(string name, SexEnum sex)
        {
            try
            {
                var user = new User()
                {
                    Nick = name,
                    Sex = sex
                };

                using (var context = new DefaultContext())
                {
                    context.Add(user);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }   
        }
    }
}
