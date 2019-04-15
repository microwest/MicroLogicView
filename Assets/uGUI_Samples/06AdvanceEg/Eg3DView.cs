using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using microwest.LogicView;

public class Eg3DView : BaseMonoView
{
    AdvanceEgLogic logic;

    Dictionary<Transform, GameObject> obj_HeaderDic = new Dictionary<Transform, GameObject>();
    public GameObject headerPrefab;
    public Transform Canvas3D;
    Image lastSelectedImage;
    Image SelectedImage;
    Text SelectedText;

    protected override void BindingStart()
    {
        logic = AdvanceEgLogic.Instance;

        logic.View_RegisterSpawned += RegisterSpawned;
        logic.View_SelectionChanged += SelectionChanged;
    }

    protected override void BindingDispose()
    {
        logic.View_RegisterSpawned -= RegisterSpawned;
        logic.View_SelectionChanged -= SelectionChanged;

        logic = null;
    }

    void RegisterSpawned(List<GameObject> goList)
    {
        foreach (var item in obj_HeaderDic)
            Destroy(item.Value);
        obj_HeaderDic.Clear();


        foreach (GameObject go in goList)
        {
            GameObject header = Instantiate(headerPrefab);
            header.name = go.name;
            header.transform.SetParent(Canvas3D);
            header.GetComponentInChildren<Text>().text = go.name;
            obj_HeaderDic.Add(go.transform, header);
        }
        Debug.Log(obj_HeaderDic.Count);
    }
    void SelectionChanged(GameObject go)
    {
        lastSelectedImage = SelectedImage;
        if (lastSelectedImage != null)
        {
            lastSelectedImage.color = Color.white;
            SelectedText.color = Color.black;
        }

        if (go == null)
            SelectedImage = null;
        else
        {
            SelectedImage = obj_HeaderDic[go.transform].GetComponentInChildren<Image>();
            SelectedText = SelectedImage.GetComponentInChildren<Text>();
            if (lastSelectedImage == null)
            {
                tmpColor = Color.white;
                RSpeed = Random.Range(0.5f, 1f);
                GSpeed = Random.Range(0f, 1f);
                BSpeed = Random.Range(0f, 1f);
            }
        }

    }

    private void Update()
    {
        SelectionChangingHeader();
        HeaderTrackingObj();
        SetHeaderRenderOrder();
    }


    Color tmpColor, invertColor;
    float RSpeed, GSpeed, BSpeed;
    /// <summary>
    /// 选中改变图标颜色
    /// </summary>
    void SelectionChangingHeader()
    {
        if (SelectedImage != null)
        {
            tmpColor.r = (tmpColor.r + RSpeed * Time.deltaTime);
            tmpColor.g = (tmpColor.g + GSpeed * Time.deltaTime);
            tmpColor.b = (tmpColor.b + BSpeed * Time.deltaTime);
            RSpeed = tmpColor.r < 1 && tmpColor.r > 0 ? RSpeed : -RSpeed;
            GSpeed = tmpColor.g < 1 && tmpColor.g > 0 ? GSpeed : -GSpeed;
            BSpeed = tmpColor.b < 1 && tmpColor.b > 0 ? BSpeed : -BSpeed;
            SelectedImage.color = tmpColor;
            invertColor = Color.white - tmpColor;
            invertColor.a = 1;
            SelectedText.color = invertColor;
        }
    }

    /// <summary>
    /// 图标跟踪球体，如血条
    /// </summary>
    void HeaderTrackingObj()
    {
        if (obj_HeaderDic.Count > 0)
        {
            foreach (var item in obj_HeaderDic)
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(item.Key.position);
                pos.y += 20;
                item.Value.transform.position = pos;
            }
        }
    }

    SortedDictionary<float, GameObject> renderOrder = new SortedDictionary<float, GameObject>();
    /// <summary>
    /// 根据相机远近，改变图标渲染次序
    /// </summary>
    void SetHeaderRenderOrder()
    {
        renderOrder.Clear();


        foreach (var item in obj_HeaderDic)
        {
            float distance = (Camera.main.transform.position - item.Key.position).sqrMagnitude;
            renderOrder.Add(distance, item.Value);
        }
        int index = 100;
        foreach (var item in renderOrder)
        {
            //item.Value.transform.SetSiblingIndex(index);
            //index--;
            item.Value.transform.SetAsFirstSibling();
        }
    }
}
