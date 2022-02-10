﻿using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Markdig.Syntax.Inlines;
using NewProject.Core;

namespace NewProject
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Protected Members

        /// <summary>
        /// A global lock for property checks so prevent locking on different instances of expressions.
        /// Considering how fast this check will always be it isn't an issue to globally lock all callers.
        /// </summary>
        protected object mPropertyValueCheckLock = new object();

        #endregion

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
            lock (mPropertyValueCheckLock)
            {
                //check if the flag property is true
                if (updatingFlag.GetPropertyValue()) return;

                //set the property flag to true to indicate we are running
                updatingFlag.SetPropertyValue(true);
            }
            
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

        /// <summary>
        /// Runs a command if the updating flag is not set.
        /// If the flag is true (indicating the function is already running) then the action is not run.
        /// If the flag is false (indicating no running function) then the action is run.
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
        /// <param name="action">The action to run if the command is not already running</param>
        /// <typeparam name="T">The type the action returns</typeparam>
        /// <returns></returns>
        protected async Task<T> RunCommandAsync<T>(Expression<Func<bool>> updatingFlag, Func<Task<T>> action, T defaultValue = default(T))
        {
            // Lock to ensure single access to check
            lock (mPropertyValueCheckLock)
            {
                // Check if the flag property is true (meaning the function is already running)
                if (updatingFlag.GetPropertyValue())
                    return defaultValue;

                // Set the property flag to true to indicate we are running
                updatingFlag.SetPropertyValue(true);
            }

            try
            {
                // Run the passed in action
                return await action();
            }
            finally
            {
                // Set the property flag back to false now it's finished
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}
