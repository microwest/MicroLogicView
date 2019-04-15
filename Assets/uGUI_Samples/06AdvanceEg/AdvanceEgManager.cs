using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceEgManager : MonoBehaviour
{    
    void Start()
    {
        AdvanceEgLogic.Instance.Start();
    }
    
    void Update()
    {
        AdvanceEgLogic.Instance.Update();
    }
}
