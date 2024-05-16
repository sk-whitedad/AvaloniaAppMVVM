using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaAppMVVM_1.ViewModels
{
    public abstract class PageViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Проверяет, может ли пользователь перейти на следующую страницу.
        /// </summary>
        public abstract bool CanNavigateNext { get; protected set; }

        /// <summary>
        /// Проверяет, может ли пользователь перейти на предыдущую страницу.
        /// </summary>
        public abstract bool CanNavigatePrevious { get; protected set; }
    }
}
