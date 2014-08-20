using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model
{
    class IdManager
    {
        Queue<int> q;
        int max;

        public IdManager()
        {
            q = new Queue<int>();
            max = 0;
        }

        public int New()
        {
            if (q.Count == 0)
            {
                return ++max;
            }

            return q.Dequeue();
        }

        public void Free(int freed)
        {
            q.Enqueue(freed);
        }
    }
}
