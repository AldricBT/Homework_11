using Homework_11.Data.WorkerData;
using Homework_11.Infrastructure.Commands;
using Homework_11.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    
    internal class AuthorizationWindowViewModel : ViewModel
    {
        //private string _title = "Заголовок";

        //public string Title
        //{
        //    get => _title;
        //    set => Set(ref _title, value);
        //}

        #region Fields and properties

        #region SelectedWorker
        private string _selectedWorker;

        /// <summary>
        /// Выбранный работник. В виде текста textblock
        /// </summary>
        public string SelectedWorker
        {
            get => _selectedWorker;
            set => Set(ref _selectedWorker, value);            
        }

        #endregion

        #endregion

        #region Commands

        #region testAddCommand

        //public ICommand AddCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        //private void OnAddCommandExecuted(object p) //логика команды
        //{
        //    _title = "БлаБлаБла";
        //    OnPropertyChanged("Title");
        //}

        //private bool CanAddCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #endregion

        /// <summary>
        /// Конструктор класса (описываются команды)
        /// </summary>
        public AuthorizationWindowViewModel()
        {
            #region Commands
            //AddCommand = new LambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);
            #endregion
        }
    }
}
