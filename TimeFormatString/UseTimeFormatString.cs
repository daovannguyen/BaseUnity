using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTimeFormatString : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log(new TimeFormatString(10000).GetFormatMMSS());
        Debug.Log(new TimeFormatString(10000).GetFormatHMMSS());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
