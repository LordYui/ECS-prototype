using ECS_Proto.Core;
using ECS_Proto.Core.Injector;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECS_Proto.Game.Input
{
    class FocusManager
    {
        FocusComparer comparer = new FocusComparer();
        List<InputFocusStruct> focusList = new List<InputFocusStruct>();
        GUIManager guiManager;

        public FocusManager()
        {
            this.Inject();
        }

        public void ForwardInput(Key k)
        {
            // todo: take/give focus n shit
            if (focusList.Count == 0)
                return;
            InputFocusStruct sF = focusList[0];
            // guiManager.isFocused
            foreach(MethodInfo inf in sF.methodCallbacks)
            {
                inf.Invoke(sF.Sender, new object[] { k });
            }
        }

        void OnInject(GUIManager mngr)
        {
            guiManager = mngr;
        }

        public void RegisterFocus(InputFocusStruct f)
        {
            focusList.Add(f);
            focusList.Sort(comparer);
        }
    }

    class FocusComparer : IComparer<InputFocusStruct>
    {
        public int Compare(InputFocusStruct x, InputFocusStruct y)
        {
            return (x.Priority < y.Priority) ? 0 : -1;
        }
    }
}
