using Homework_11.Infrastructure.Commands;
using Homework_11.Models;
using Homework_11.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Fields and properties

        #region ClientsData
        private RepositoryOfClients _clientsData;

        /// <summary>
        /// База данных работников
        /// </summary>
        public RepositoryOfClients ClientsData
        {
            get => _clientsData;
            set => Set(ref _clientsData, value);
        }

        #endregion

        #region SelectedWorker
        private string _selectedWorker = "Консультант";

        /// <summary>
        /// Выбранный работник. В виде текста textblock
        /// </summary>
        public string SelectedWorker
        {
            get => _selectedWorker;
            set => Set(ref _selectedWorker, value);
        }

        #endregion

        #region SelectedPageIndex
        private int _selectedPageIndex = 1;

        /// <summary>
        /// Индекс выбранной вкладки
        /// </summary>
        public int SelectedPageIndex
        {
            get => _selectedPageIndex;
            set => Set(ref _selectedPageIndex, value);
        }

        #endregion

        #region MainWindowTitle
        private string _mainWindowTitle = "Авторизация";

        /// <summary>
        /// Индекс выбранной вкладки
        /// </summary>
        public string MainWindowTitle
        {
            get => _mainWindowTitle;
            set => Set(ref _mainWindowTitle, value);
        }

        #endregion

        #endregion

        #region AuthorizationCommand

        public ICommand AuthorizationCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnAuthorizationCommandExecuted(object p) //логика команды
        {
            SelectedPageIndex = 1;
            MainWindowTitle = "База клиентов";
        }

        private bool CanAuthorizationCommandExecute(object p) => _selectedPageIndex >= 0; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #region GoToAuthorizationPageCommand

        public ICommand GoToAuthorizationPageCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnGoToAuthorizationPageCommandExecuted(object p) //логика команды
        {
            SelectedPageIndex = 0;
            MainWindowTitle = "Авторизация";
        }

        private bool CanGoToAuthorizationPageCommandExecute(object p) => _selectedPageIndex >= 0; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #region AddCommand

        public ICommand AddCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnAddCommandExecuted(object p) //логика команды
        {
            
        }

        private bool CanAddCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion


        /// <summary>
        /// Конструктор класса (описываются команды)
        /// </summary>
        public MainWindowViewModel()
        {
            #region Commands
            AddCommand = new LambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);
            AuthorizationCommand = new LambdaCommand(OnAuthorizationCommandExecuted, CanAuthorizationCommandExecute);
            GoToAuthorizationPageCommand = new LambdaCommand(OnGoToAuthorizationPageCommandExecuted, CanGoToAuthorizationPageCommandExecute);

            #endregion

            _clientsData = new RepositoryOfClients("clients.json");
        }
    }
}
