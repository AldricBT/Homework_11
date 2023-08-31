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

        #region Add new client Properties
        #region Lastname
        private string _lastname = default!;
        public string Lastname
        {
            get => _lastname;
            set => Set(ref _lastname, value);
        }
        #endregion

        #region Name
        private string _name = default!;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        #endregion

        #region Patronymic
        private string _patronymic = default!;
        public string Patronymic
        {
            get => _patronymic;
            set => Set(ref _patronymic, value);
        }
        #endregion

        #region Phone
        private string _phone = default!;
        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }
        #endregion

        #region Passport
        private string _passport = default!;
        public string Passport
        {
            get => _passport;
            set => Set(ref _passport, value);
        }
        #endregion
        #endregion

        #region Selected client edit properties

        #region EditWho
        private string _editWho = default!;
        public string EditWho
        {
            get => _editWho;
            set => Set(ref _editWho, value);
        }
        #endregion

        #region EditData
        private string _editData = default!;
        public string EditData
        {
            get => _editData;
            set => Set(ref _editData, value);
        }
        #endregion

        #region EditType
        private string _editType = default!;
        public string EditType
        {
            get => _editType;
            set => Set(ref _editType, value);
        }
        #endregion

        #region EditTime
        private string _editTime = default!;
        public string EditTime
        {
            get => _editTime;
            set => Set(ref _editTime, value);
        }
        #endregion

        #endregion


        #endregion


        #region Commands  

        #region AuthorizationCommand
        //Выполняется при авторизации: происходит отображение публичных данных в зависимости от выбранного воркера

        public ICommand AuthorizationCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        public void OnAuthorizationCommandExecuted(object p) //логика команды
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
            Clients = _worker.PublicClients;
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

        #region GoToAddPage

        public ICommand GoToAddPage { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnGoToAddPageExecuted(object p) //логика команды
        {
            SelectedPageIndex = 2;
            MainWindowTitle = "Добавление работника";
        }

        private bool CanGoToAddPageExecute(object p)
        {
            if (_selectedWorker == "Консультант")
                return false;
            return true;
        }
        #endregion

        #region AddCommand
        public ICommand AddCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnAddCommandExecuted(object p) //логика команды
        {
            Worker.Clients.Add(new Client(
                Worker.GetNextID(),
                _lastname,
                _name,
                _patronymic,
                _phone,
                _passport));
            Worker.Save();

            Lastname = string.Empty;            
            Name = string.Empty;
            Patronymic = string.Empty;
            Phone = string.Empty;
            Passport = string.Empty;

            OnAuthorizationCommandExecuted(null!);
        }

        private bool CanAddCommandExecute(object p)
        {
            if ((string.IsNullOrEmpty(_lastname)) || (string.IsNullOrEmpty(_name)) ||
                (string.IsNullOrEmpty(_patronymic)) || (string.IsNullOrEmpty(_phone)) ||
                (string.IsNullOrEmpty(_passport)))
                return false;
            return true;
        }       
        #endregion

        #region RemoveClientCommand
        public ICommand RemoveClientCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnRemoveClientCommandExecuted(object p) //логика команды
        {  
            Worker.Remove(_selectedItem.Id);
            Worker.Save();
            OnAuthorizationCommandExecuted(null!);
        }
        private bool CanRemoveClientCommandExecute(object p)
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
            if (_selectedItem.Equals(_rememberClient))
                return;
            //валидность ввода. пустое поле недопустимо
            if ((string.IsNullOrEmpty(_selectedItem.Lastname)) || (string.IsNullOrEmpty(_selectedItem.Name)) ||
                (string.IsNullOrEmpty(_selectedItem.Patronymic)) || (string.IsNullOrEmpty(_selectedItem.Phone)) ||
                (string.IsNullOrEmpty(_selectedItem.Passport)))
            {
                Clients[Clients.IndexOf(Clients.Where(c => c.Id == _rememberClient.Id).First())] = _rememberClient;                    
                return;
            }                
            _worker.ChangedClientData(_selectedItem, _rememberClient);

            EditWho = _selectedItem.EditWho;
            EditData = _selectedItem.EditData;
            EditTime = _selectedItem.EditTime.ToString("dd.MM.yyyy HH:mm");
            EditType = _selectedItem.EditType;
            Clients = _worker.PublicClients;
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

        #region GetEditCommand. Обновление информации об изменениях клиента при его выборе
        public ICommand GetEditCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnGetEditCommandExecuted(object p) //логика команды
        {
            if (_selectedItem == null)
                return;
            EditWho = _selectedItem.EditWho;
            EditData = _selectedItem.EditData;
            EditTime = _selectedItem.EditTime.ToString("dd.MM.yyyy HH:mm");
            EditType = _selectedItem.EditType;
        }

        private bool CanGetEditCommandExecute(object p) => _selectedPageIndex >= 0; //если команда должна быть доступна всегда, то просто возвращаем true
        #endregion 
        

        #endregion

        /// <summary>
        /// Конструктор класса (описываются команды)
        /// </summary>
        public MainWindowViewModel()
        {

            #region Commands 
            GoToAddPage = new LambdaCommand(OnGoToAddPageExecuted, CanGoToAddPageExecute);
            AuthorizationCommand = new LambdaCommand(OnAuthorizationCommandExecuted, CanAuthorizationCommandExecute);
            GoToAuthorizationPageCommand = new LambdaCommand(OnGoToAuthorizationPageCommandExecuted, CanGoToAuthorizationPageCommandExecute);
            SaveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted, CanSaveChangesCommandExecute);
            RememberClientCommand = new LambdaCommand(OnRememberClientCommandExecuted, CanRememberClientCommandExecute);
            AddCommand = new LambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);
            RemoveClientCommand = new LambdaCommand(OnRemoveClientCommandExecuted, CanRemoveClientCommandExecute);
            GetEditCommand = new LambdaCommand(OnGetEditCommandExecuted, CanGetEditCommandExecute);

            #endregion
        }
    }
}
