using System;
using microwest.LogicView;

public class NoUILogic : BaseLogic<NoUILogic>
{
    /// <summary>
    /// View action to be call by this logic.
    /// </summary>
    public Action ViewAction;

    #region Logic informs View 逻辑通知视图
    void DoSomeLogicFun()
    {
        //Do Some Logic Function...
        InvokeView(ViewAction);
    }
    #endregion



    #region View informs Logic 视图通知逻辑
    void SomeBtnClick()
    {
        //when ui changed, something need to do with Logic code.
    }
    #endregion
}
