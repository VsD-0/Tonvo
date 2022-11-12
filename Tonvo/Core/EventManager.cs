using System;
using System.Collections.Generic;
using System.Text;

namespace Tonvo.Core
{
    internal class EventManager
    {
        // TODO: Возможно удалить
        public static event Action Validated;

        public static void OnValidated()
        {
            Validated?.Invoke();
        }
    }
}
