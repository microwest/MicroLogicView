using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using microwest.LogicView;



public class PickView : BaseMonoView
{
    PickLogic logic;


    public Text selectionGoName;
    public Button BtnNext;
    public Button BtnPrevious;

    protected override void BindingStart()
    {
        logic = PickLogic.Instance;
        logic.View_MousePick = View_MousePick;

        BtnNext.onClick.AddListener(logic.NextSelect);
        BtnPrevious.onClick.AddListener(logic.PreviousSelect);
    }
    protected override void BindingDispose()
    {
        logic.View_MousePick -= View_MousePick;

        BtnNext.onClick.RemoveListener(logic.NextSelect);
        BtnPrevious.onClick.RemoveListener(logic.PreviousSelect);

        logic = null;
    }

    /// <summary>
    /// 逻辑通知视图
    /// </summary>
    /// <param name="name"></param>
    public void View_MousePick(string name)
    {
        selectionGoName.text = name;
    }
}
