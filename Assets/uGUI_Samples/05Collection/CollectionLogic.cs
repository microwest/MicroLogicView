using System;
using System.Collections.Generic;
using UnityEngine;
using microwest.LogicView;
using Random = UnityEngine.Random;

public class CollectionLogic : BaseLogic<CollectionLogic>
{
    GameObject _SpherePrefab;
    GameObject SpherePrefab
    {
        get
        {
            if (_SpherePrefab == null)
            {
                _SpherePrefab = GameObject.Find("SpherePrefab");
            }
            return _SpherePrefab;
        }
    }
    List<GameObject> GoList = new List<GameObject>();
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

    public Action<List<GameObject>> View_ResetDropDown;

    public void RandomSpawn()
    {        
        GameObject tmp;
        int count = Random.Range(2, 10);
        foreach (GameObject i in GoList)
            GameObject.Destroy(i);
        GoList.Clear();
        for (int i = 0; i < count; i++)
        {
            tmp = GameObject.Instantiate(SpherePrefab);
            tmp.name = "Sphere"+i.ToString();
            tmp.transform.position = Random.insideUnitSphere * 10;
            GoList.Add(tmp);
        }
        InvokeView(View_ResetDropDown, GoList);
    }

    public void ChooseOne(int index)
    {
        Seletion = GoList[index];
    }
}
