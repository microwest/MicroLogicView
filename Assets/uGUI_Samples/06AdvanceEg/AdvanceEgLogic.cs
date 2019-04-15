using System;
using System.Collections.Generic;
using UnityEngine;
using microwest.LogicView;
using Random = UnityEngine.Random;

public class AdvanceEgLogic : BaseLogic<AdvanceEgLogic>
{
    public Action<List<GameObject>> View_RegisterSpawned;
    public Action<GameObject> View_SelectionChanged;

    GameObject SpherePrefab;
    List<GameObject> GoList = new List<GameObject>();
    GameObject lastSelection;
    GameObject _Selection;
    /// <summary>
    /// 选中之后，改变颜色
    /// </summary>
    GameObject Selection
    {
        set
        {
            lastSelection = _Selection;
            _Selection = value;
            if (lastSelection != value)
            {
                if (lastSelection != null)
                    lastSelection.GetComponent<Renderer>().material.color = Color.white;
                if (value != null)
                    value.GetComponent<Renderer>().material.color = Color.red;
            }
            InvokeView(View_SelectionChanged, value);
        }
        get { return _Selection; }
    }

    public void Start()
    {
        SpherePrefab = Resources.Load<GameObject>("SpherePrefab");
    }

    public void Update()
    {
        RotateCamera();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int mask = 1 << (LayerMask.NameToLayer("chooseGo"));
            if (Physics.Raycast(ray, out RaycastHit hit, 100, mask))
            {
                Selection = hit.collider.gameObject;
                //InvokeView(View_MousePick, Seletion.name);
            }
        }
        else if (Input.GetMouseButtonUp(0))
            Selection = null;
    }

    public void RandomSpawn()
    {
        GameObject tmp;
        int count = Random.Range(10, 20);
        foreach (GameObject i in GoList)
            GameObject.Destroy(i);
        GoList.Clear();
        for (int i = 0; i < count; i++)
        {
            tmp = GameObject.Instantiate(SpherePrefab);
            tmp.name = "Sphere" + i.ToString();
            tmp.transform.position = Random.insideUnitSphere * 10;
            GoList.Add(tmp);
        }
        InvokeView(View_RegisterSpawned, GoList);
    }

    void RotateCamera()
    {
        Camera.main.transform.RotateAround(Vector3.zero, Vector3.up, 10 * Time.deltaTime);
    }
}
