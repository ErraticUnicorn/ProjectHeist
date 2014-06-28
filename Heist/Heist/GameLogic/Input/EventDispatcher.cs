using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.GameLogic.Input
{

    class EventDispatcher
    {
        Dictionary<InputType, EventType> inputMap;

        InputInterpreter input;
        Dictionary<EventListener, EventType> listeners;

        public EventDispatcher()
        {
            inputMap = new Dictionary<InputType, EventType>();

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

        public void MapInput(InputType i, EventType e)
        {
            inputMap.Add(i, e);
        }

        public void Process()
        {
            List<InputType> list = input.Process();
            foreach (InputType i in list)
            {
                EventType e = EventType.None;
                inputMap.TryGetValue(i, out e);

                Console.WriteLine((int)i + ": " + i);

                if (e != EventType.None)
                {
                    foreach (KeyValuePair<EventListener, EventType> l in listeners)
                    {
                        if ((l.Value & e) != 0)
                        {
                            l.Key.OnEvent(new Event(e, input.GetLocation(), input.GetScrollAmount()));
                        }
                    }
                }
            }

        }

    }
}
