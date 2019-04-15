using UnityEngine;
using UnityEngine.UI;
using microwest.LogicView;

using System.Reflection;

public class SimpleView : BaseMonoView
{
    SimpleLogic logic;

    protected override void BindingStart()
    {
        logic = SimpleLogic.Instance;

        logic.View_UpdateTime += View_UpdateTime;
        btn.onClick.AddListener(logic.NewTimeNow);
    }
    protected override void BindingDispose()
    {
        logic.View_UpdateTime -= View_UpdateTime;
        btn.onClick.RemoveListener(logic.NewTimeNow);
        logic = null;
    }


    public Button btn;
    public Text timeStr;
    public void View_UpdateTime(string time)
    {
        timeStr.text = time;
    }
}
