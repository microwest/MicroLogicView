using System;
using microwest.LogicView;

public class SimpleLogic : BaseLogic<SimpleLogic>
{
    public Action<string> View_UpdateTime;

    public void NewTimeNow()
    {
        string s = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");

        #region You don't need to know which gui will show this, just Invoke it. Put cursor on the function, you'll see more info.

        InvokeView(View_UpdateTime, s);

        #endregion
    }
}
