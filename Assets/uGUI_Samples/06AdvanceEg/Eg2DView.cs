using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using microwest.LogicView;

public class Eg2DView : BaseMonoView
{
    AdvanceEgLogic logic;

    public Button SpawnBtn;
    public Text selectName;
    protected override void BindingStart()
    {
        logic = AdvanceEgLogic.Instance;

        SpawnBtn.onClick.AddListener(logic.RandomSpawn);
        logic.View_SelectionChanged += SelectionChanged;
    }

    protected override void BindingDispose()
    {
        SpawnBtn.onClick.RemoveListener(logic.RandomSpawn);
        logic.View_SelectionChanged -= SelectionChanged;

        logic = null;
    }

    void SelectionChanged(GameObject go)
    {
        if (go != null)
            selectName.text = go.name;
        else
            selectName.text = "";
    }
}
