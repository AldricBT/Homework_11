using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {  
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Вызов события. Если явно не указывается название свойства, 
        /// то используется имя свойства, в котором происходит вызов
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>
        /// Метод для сеттера свойств
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">Поле во VM</param>
        /// <param name="value">Значение, записываемое в поле</param>
        /// <param name="PropertyName">Название обновляемого свойства 
        /// (если вызывается в самом свойстве, то можно не указывать)</param>
        /// <returns>Вызывает событие для изменения интерфейса</returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
