using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.Models
{
    /// <summary>
    /// Класс клиента для хранения его данных
    /// </summary>
    /// 
    // По идее должен реализовывать ViewModel! или INotifyPropertyChanged
    internal class Client : ICloneable, INotifyPropertyChanged
    {
        private int _id;
        private string _lastname;
        private string _name;
        private string _patronymic;
        private string _phone;
        private string _passport;
        private DateTime _editTime;
        private string _editData;
        private string _editType;    //добавил или изменил
        private string _editWho;

        public int Id
        {
            get => _id;
        }
        public string Lastname
        {
            get => _lastname; 
            set => Set(ref _lastname, value);
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Patronymic
        {
            get => _patronymic;
            set => Set(ref _patronymic, value);
        }

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        public string Passport
        {
            get => _passport;
            set => Set(ref _passport, value);
        }

        public DateTime EditTime
        {
            get => _editTime;
            set => Set(ref _editTime, value);
        }

        public string EditData
        {
            get => _editData;
            set => Set(ref _editData, value);
        }

        public string EditType
        {
            get => _editType;
            set => Set(ref _editType, value);
        }

        public string EditWho
        {
            get => _editWho;
            set => Set(ref _editWho, value);
        }

        public Client(int id, string lastname, string name, string patronymic, string phone, string passport)
        {
            _id = id;
            _lastname = lastname;
            _name = name;
            _patronymic = patronymic;
            _phone = phone;
            _passport = passport;
            _editTime = DateTime.Now;
            _editWho = "Мененджер";
            _editType = "Добавление";
            _editData = "Новый клиент";
        }

        private Client(int id, string lastname, string name, string patronymic, string phone, string passport, 
            DateTime editTime, string editWho, string editType, string editData)
        {
            _id = id;
            _lastname = lastname;
            _name = name;
            _patronymic = patronymic;
            _phone = phone;
            _passport = passport;
            _editTime = editTime;
            _editWho = editWho;
            _editType = editType;
            _editData = editData;
        }

        public object Clone()
        {
            return new Client(_id, _lastname, _name, _patronymic, _phone, _passport, 
                _editTime, _editWho, _editType, _editData);
        }


        #region Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Вызов события. Если явно не указывается название свойства, 
        /// то используется имя свойства, в котором происходит вызов
        /// </summary>
        /// <param _name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>
        /// Метод для сеттера свойств
        /// </summary>
        /// <typeparam _name="T"></typeparam>
        /// <param _name="field">Поле во VM</param>
        /// <param _name="value">Значение, записываемое в поле</param>
        /// <param _name="PropertyName">Название обновляемого свойства 
        /// (если вызывается в самом свойстве, то можно не указывать)</param>
        /// <returns>Вызывает событие для изменения интерфейса</returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
        #endregion

    }
}
