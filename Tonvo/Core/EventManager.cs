using System;
using System.Collections.Generic;
using System.Text;

namespace Tonvo.Core
{
    public class EventManager
    {
        public static event Action Validated;

        public static void OnValidated()
        {
            Validated?.Invoke();
        }
    }
}
