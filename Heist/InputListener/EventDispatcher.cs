using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InputListener
{

    public class EventDispatcher
    {
        Dictionary<InputType, int> inputMap;

        InputInterpreter input;
        Dictionary<EventListener, int> listeners;

        public EventDispatcher()
        {
            inputMap = new Dictionary<InputType, int>();

            input = new InputInterpreter();
            listeners = new Dictionary<EventListener, int>();
        }

        public void AddListener(EventListener l, int e)
        {
            listeners.Add(l, e);
        }

        public void RemoveListener(EventListener l)
        {
            listeners.Remove(l);
        }

        public void MapInput(InputType i, int e)
        {
            inputMap.Add(i, e);
        }

        public void Process()
        {
            List<InputType> list = input.Process();
            foreach (InputType i in list)
            {
                int e = 0;
                inputMap.TryGetValue(i, out e);

                if (e != 0)
                {
                    foreach (KeyValuePair<EventListener, int> l in listeners)
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
