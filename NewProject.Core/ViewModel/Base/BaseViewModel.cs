using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Core
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender , e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command helpers

        /// <summary>
        /// runs a command if the updating flag is not set .
        /// if the flag is true(indicating the function is already running ) then the action is not run.
        /// if the flag is false(indicating no running function) then the action is run
        /// once the action is finished if it was run,then the flag is reset to false.
        /// </summary>
        /// <param name="updatingFlag">the boolean property flag defining if the command is already running</param>
        /// <param name="action">the action to run if the command is not already running</param>
        /// <returns></returns>
        protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            //check if the flag property is true
            if (updatingFlag.GetPropertyValue()) return;

            //set the property flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                //run the passed in action
                await action();
            }
            finally
            {
                //set the property flag to false
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}
