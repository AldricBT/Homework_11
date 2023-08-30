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
using System.Windows.Controls;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private Worker _worker = default!;
        private readonly string _pathToClientData = "clients.json";

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
        private ObservableCollection<Client> _clients = default!;
        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => Set(ref _clients, value);
        }
        #endregion

        #region SelectedItem
        private Client _selectedItem = default!;
        public Client SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }
        #endregion

        #region RememberClient. Неизмененные данные клиента. Сравнивая их с измененными сохранятся только измененные данные в основной БД
        private Client _rememberClient = default!;
        public Client RememberClient
        {
            get => _rememberClient;
            set => Set(ref _rememberClient, value);
        }
        #endregion

        #region Свойства для доступа к изменению столбцов DataGrid

        #region IsFIOReadOnly. ФИО
        private bool _isFIOReadOnly = true;
       public bool IsFIOReadOnly
       {
           get => _isFIOReadOnly;
           set => Set(ref _isFIOReadOnly, value);
       }
        #endregion

        #region IsPhoneReadOnly. Телефон
        private bool _isPhoneReadOnly = true;
        public bool IsPhoneReadOnly
        {
            get => _isPhoneReadOnly;
            set => Set(ref _isPhoneReadOnly, value);
        }
        #endregion

        #region IsPassportReadOnly. Паспорт
        private bool _isPassportReadOnly = true;
        public bool IsPassportReadOnly
        {
            get => _isPassportReadOnly;
            set => Set(ref _isPassportReadOnly, value);
        }
        #endregion

        #endregion

        #endregion

        
        #region Commands

        #region AuthorizationCommand
        //Выполняется при авторизации: происходит отображение публичных данных в зависимости от выбранного воркера

        public ICommand AuthorizationCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnAuthorizationCommandExecuted(object p) //логика команды
        {
            //Смена "страницы"
            SelectedPageIndex = 1;
            MainWindowTitle = "База клиентов";
            
            //подгрузка публичных данных в зависимости от работника
            switch (_selectedWorker)
            {
                case "Консультант":
                    _worker = new Consultant(_pathToClientData);
                    _isFIOReadOnly = true;
                    OnPropertyChanged("IsFIOReadOnly");
                    _isPhoneReadOnly = false;
                    OnPropertyChanged("IsPhoneReadOnly");
                    _isPassportReadOnly = true;
                    OnPropertyChanged(nameof(IsPassportReadOnly));
                    break;

                case "Менеджер":
                    _worker = new Manager(_pathToClientData);
                    _isFIOReadOnly = false;
                    OnPropertyChanged(nameof(IsFIOReadOnly));
                    _isPhoneReadOnly = false;
                    OnPropertyChanged(nameof(IsPhoneReadOnly));
                    _isPassportReadOnly = false;
                    OnPropertyChanged(nameof(IsPassportReadOnly));
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

        private bool CanAddCommandExecute(object p)   //если команда должна быть доступна всегда, то просто возвращаем true
        {
            if (_selectedWorker == "Консультант")
                return false;
            return true;
        }
        

        #endregion

        #region SaveChangesCommand. Сохранение изменений клиента в базе. Происходит во время изменений в DataGrid

        public ICommand SaveChangesCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnSaveChangesCommandExecuted(object p) //логика команды
        {
            if (!_selectedItem.Equals(_rememberClient))
                _worker.ChangedClientData(_selectedItem, _rememberClient);
        }

        private bool CanSaveChangesCommandExecute(object p) => true; //если команда должна быть доступна всегда, то просто возвращаем true

        #endregion

        #region RememberClientCommand. Запоминание клиента, который выбран для изменения

        public ICommand RememberClientCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnRememberClientCommandExecuted(object p) //логика команды
        {
            OnPropertyChanged(nameof(SelectedItem));
            _rememberClient = (Client)_selectedItem.Clone();
        }

        private bool CanRememberClientCommandExecute(object p) => _selectedPageIndex >= 0; //если команда должна быть доступна всегда, то просто возвращаем true

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
            RememberClientCommand = new LambdaCommand(OnRememberClientCommandExecuted, CanRememberClientCommandExecute);
            
            #endregion
        }
    }
}
