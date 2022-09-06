using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NNRaycast : Singleton<NNRaycast>
{
    public T GetComponentByRatcastFromOnScreen<T>(Vector3 posOnScreen)
    {
        Ray ray = Camera.main.ScreenPointToRay(posOnScreen);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var item = hit.transform.GetComponent<T>();
            return item;
        }
        return (T) Convert.ChangeType(null, typeof(T));
    }

    public T GetComponentByRatcastAtMousePosition<T>()
    {
        return GetComponentByRatcastFromOnScreen<T>(Input.mousePosition);
    }
}
