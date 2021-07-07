// ---------------------------
// Copyright (c) 2021 Koninklijke Philips N.V.
// All rights are reserved. Reproduction or dissemination
// in whole or in part is prohibited without the prior written
// consent of the copyright holder.
// ---------------------------

using System;
using System.Windows.Input;

namespace PhotoSearchProject
{

    /// <summary>
    /// ICommand implementation for all ViewModel Commands 
    /// </summary>
    public class Command : ICommand
    {
        #region Private Fields

        /// <summary>
        /// 
        /// </summary>
        private bool _canExecute = true;

        /// <summary>
        /// 
        /// </summary>
        private readonly Action<object> _parametrizedAction;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Command()
        {
        }

        /// <summary>
        /// Parametrized Constructor
        /// </summary>
        /// <param name="parametrizedAction">
        /// Parametrized Action to perform upon execution. This type of actions can take in parameters while executing.
        /// </param>
        /// <param name="canExecute">
        /// Indicates if Action can be executed
        /// </param>
        public Command(Action<object> parametrizedAction, bool canExecute)
        {
            //  Set the action.
            _parametrizedAction = parametrizedAction;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parametrizedAction">
        /// Parametrized Action to perform upon execution. This type of actions can take in parameters while executing.
        /// </param>
        public Command(Action<object> parametrizedAction)
        {
            //  Set the action.
            this._parametrizedAction = parametrizedAction;
            // default is true
            this._canExecute = true;
        }

        #endregion

        #region Public/Protected Methods

        /// <summary>
        /// Indicates if the Action can be executed when the command is invoked.
        /// </summary>
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        /// <summary>
        /// Executes the commad
        /// </summary>
        /// <param name="parameter">
        /// parameter to pass to command action
        /// </param>
        public void Execute(object parameter)
        {
            this.DoExecute(parameter);
        }

        /// <summary>
        /// Occurs when can execute is changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Invoke the Parametrized Action
        /// </summary>
        /// <param name="param">
        /// parameter to pass
        /// </param>
        public void DoExecute(object param)
        {
            InvokeAction(param);
        }

        /// <summary>
        /// Returns if the Command can be executed
        /// </summary>
        /// <param name="parameter">
        /// parameter (if required)
        /// </param>
        /// <returns>
        /// bool value indicating if the Command can be executed
        /// </returns>
        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute;
        }

        /// <summary>
        /// Invoke the Parametrized Action
        /// </summary>
        /// <param name="param">
        /// parameter to pass
        /// </param>
        protected void InvokeAction(object param)
        {
            var theParametrizedAction = _parametrizedAction;
            theParametrizedAction?.Invoke(param);
        }

        #endregion

    }
}