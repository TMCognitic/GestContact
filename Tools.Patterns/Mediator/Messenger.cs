using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Patterns.Mediator
{
    public sealed class Messenger<TMessage>
        where TMessage : class
    {
        private static Messenger<TMessage> _instance;

        public static Messenger<TMessage> Instance
        {
            get
            {
                return _instance ?? (_instance = new Messenger<TMessage>());
            }
        }

        private Action<TMessage> _notify;

        private Messenger()
        {
        }

        public void Register(Action<TMessage> method)
        {
            _notify += method;
        }

        public void Send(TMessage message)
        {
            _notify?.Invoke(message);
        }
    }
}
