using System;
using System.Collections.Generic;
using UnityEngine;
using microwest.LogicView;

public class PickLogic : BaseLogic<PickLogic>
{
    public Action<string> View_MousePick;


    List<GameObject> GoList;

    GameObject lastSelection;
    GameObject _Seletion;
    /// <summary>
    /// 选中之后，改变颜色
    /// </summary>
    GameObject Seletion
    {
        set
        {
            lastSelection = _Seletion;
            _Seletion = value;
            if (lastSelection != Seletion)
            {
                if (lastSelection != null)
                    lastSelection.GetComponent<Renderer>().material.color = Color.white;
                Seletion.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        get { return _Seletion; }
    }


    public void Start()
    {
        GoList = new List<GameObject>();
        GoList.AddRange(GameObject.FindGameObjectsWithTag("chooseGo"));
    }
    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                Seletion = hit.collider.gameObject;
                InvokeView(View_MousePick, Seletion.name);
            }
        }
    }
    public void NextSelect()
    {
        int selectNo = GoList.IndexOf(Seletion) + 1;
        Seletion = GoList[selectNo % GoList.Count];
        Debug.Log(selectNo % GoList.Count);
        InvokeView(View_MousePick, Seletion.name);
    }
    public void PreviousSelect()
    {
        int selectNo = GoList.IndexOf(Seletion) - 1;
        if (selectNo < 0)
            selectNo += GoList.Count;
        Debug.Log(selectNo % GoList.Count);
        Seletion = GoList[selectNo % GoList.Count];

        InvokeView(View_MousePick, Seletion.name);
    }
}
