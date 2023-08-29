using Homework_11.Data;
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
        private Worker _worker;
        private string _pathToClientData = "clients.json";

        #region Fields and properties

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
        private int _selectedPageIndex = 0;

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

        #region PublicData
        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => Set(ref _clients, value);
        }
        #endregion

        #region SelectedItem
        private Client _selectedItem;
        public Client SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }
        #endregion

        #endregion


        #region Commands

        #region AuthorizationCommand

        public ICommand AuthorizationCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnAuthorizationCommandExecuted(object p) //логика команды
        {
            SelectedPageIndex = 1;
            MainWindowTitle = "База клиентов";
            
            switch (_selectedWorker)
            {
                case "Консультант":
                    _worker = new Consultant(_pathToClientData);
                    break;

                case "Менеджер":
                    _worker = new Manager(_pathToClientData);
                    break;
            }
            _clients = _worker.PublicClients;
            OnPropertyChanged("Clients");
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

        #region SaveChangesCommand. Сохранение изменений клиента в базе. Происходит во время изменений в DataGrid

        public ICommand SaveChangesCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnSaveChangesCommandExecuted(object p) //логика команды
        {
            Worker.Edit(_selectedItem.Id, _clients.Where(c => c.Id == _selectedItem.Id).First());
            Worker.Save();
        }

        private bool CanSaveChangesCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

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
            SaveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted, CanSaveChangesCommandExecute);

            #endregion
        }
    }
}
