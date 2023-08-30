using Homework_11.Infrastructure.Commands;
using Homework_11.Models;
using Homework_11.ViewModels.Base;
using Homework_11.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework_11.ViewModels
{
    internal class AddClientWindowViewModel : ViewModel
    {
        #region Fields and Properties

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


        #region AddCommand

        public ICommand AddCommand { get; } //здесь живет сама команда (это по сути обычное свойство, чтобы его можно было вызвать из хамл)

        private void OnAddCommandExecuted(object p) //логика команды
        {
            
        }

        private bool CanAddCommandExecute(object p)   //если команда должна быть доступна всегда, то просто возвращаем true
        {
            return true;
        }


        #endregion


        public AddClientWindowViewModel()
        {

            #region Commands
            AddCommand = new LambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);

            #endregion
        }

    }
}
