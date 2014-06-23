using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heist.Screens
{
    public interface IScreenMaster
    {
        C Load<C>(string name);
        void Change<S>(object[] data) where S : Screen;
    }
}
