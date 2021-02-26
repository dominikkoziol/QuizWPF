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
