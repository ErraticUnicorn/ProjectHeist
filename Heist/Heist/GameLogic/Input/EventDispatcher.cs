using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Input
{

    class EventDispatcher
    {
        InputInterpreter input;
        Dictionary<EventListener, EventType> listeners;

        public EventDispatcher()
        {
            input = new InputInterpreter();
            listeners = new Dictionary<EventListener, EventType>();
        }

        public void AddListener(EventListener l, EventType e)
        {
            listeners.Add(l, e);
        }

        public void RemoveListener(EventListener l)
        {
            listeners.Remove(l);
        }

        public void Process()
        {
            Event e = input.Process();

            if (e != null)
            {
                foreach (KeyValuePair<EventListener, EventType> l in listeners)
                {
                    if ((l.Value & e.Type) != 0)
                    {
                        l.Key.OnEvent(e);
                    }
                }
            }
        }

    }
}
