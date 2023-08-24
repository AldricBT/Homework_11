using Homework_11.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Заголовок";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }


        /// <summary>
        /// Конструктор класса (описываются команды)
        /// </summary>
        public MainWindowViewModel()
        {
            #region Commands
            //AddCommand = new LambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);
            #endregion
        }
    }
}
