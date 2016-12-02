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

        public void ForwardInput(Key k)
        {
            // todo: take/give focus n shit
            InputFocusStruct sF = focusList[0];
            foreach(MethodInfo inf in sF.methodCallbacks)
            {
                inf.Invoke(sF.Sender, new object[] { k });
            }
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
