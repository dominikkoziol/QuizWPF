using Microsoft.EntityFrameworkCore;
using PropertyChanged;
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
    public class MainWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<User> Users { get; set; }
        public User User;

        /// <summary>
        /// Download data from db
        /// </summary>
        public async Task InitAsync()
        {
            using (var context = new DefaultContext())
            {
                this.Users = new ObservableCollection<User>(await context.Users.ToListAsync());
            }
        }
        /// <summary>
        /// Remove user from db and locally
        /// </summary>
        public async Task RemoveUser(int id)
        {
            using (var context = new DefaultContext())
            {
                var userToRemove = await context.Users.Where(q => q.Id == id).FirstOrDefaultAsync();
                if (userToRemove != null)
                {
                    //Remove from db
                    context.Users.Remove(userToRemove);
                    await context.SaveChangesAsync();
                    //Remove from local list
                    var local = Users.Where(q => q.Id == id).FirstOrDefault();
                    Users.Remove(local);
                }

            }
        }


    }
}
