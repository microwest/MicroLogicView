using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using microwest.LogicView;

public class CollectionView : BaseMonoView
{
    CollectionLogic logic;

    public Button SpawnBtn;
    public Dropdown dropDown;
    public Text selectName;
    protected override void BindingStart()
    {
        logic = CollectionLogic.Instance;

        logic.View_ResetDropDown = View_ResetDropDown;

        SpawnBtn.onClick.AddListener(logic.RandomSpawn);
        dropDown.onValueChanged.AddListener(DropDownChoose);
    }
    protected override void BindingDispose()
    {
        logic.View_ResetDropDown -= View_ResetDropDown;

        SpawnBtn.onClick.RemoveListener(logic.RandomSpawn);
        dropDown.onValueChanged.RemoveListener(DropDownChoose);

        logic = null;
    }



    void View_ResetDropDown(List<GameObject> list)
    {
        dropDown.options.Clear();

        foreach (GameObject go in list)
        {
            Dropdown.OptionData item = new Dropdown.OptionData(go.name);
            dropDown.options.Add(item);
        }
        dropDown.captionText.text = "please choose one!";
    }

    void DropDownChoose(int i)
    {
        logic.ChooseOne(i);
        selectName.text = "Sphere" + i.ToString();
    }
}
