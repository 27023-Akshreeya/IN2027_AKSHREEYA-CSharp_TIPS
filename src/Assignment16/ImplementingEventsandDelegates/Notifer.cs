using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingEventsandDelegates
{
    public delegate void Notify(string message);
    public class Notifer
    {
        public event Notify OnAction;

        public void DisplayOnAction(string message) => OnAction?.Invoke(message);
    }
}
