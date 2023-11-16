using System.Collections.Generic;

namespace FlaUI.WebDriver
{
    public class InputState
    {
        public List<Action> InputCancelList = new List<Action>();

        public void Reset()
        {
            InputCancelList.Clear();
        }
    }
}
