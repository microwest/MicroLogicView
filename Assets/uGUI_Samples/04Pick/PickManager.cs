using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickManager : MonoBehaviour
{
    void Start()
    {
        PickLogic.Instance.Start();
    }

    void Update()
    {
        PickLogic.Instance.Update();
    }
}
