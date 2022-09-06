using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMyRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveByPoints moveByPoints = NNRaycast.Instance.GetComponentByRatcastAtMousePosition<MoveByPoints>();
        if (moveByPoints != null)
        {
            Debug.Log("Tìm thấy rồi");
        }
    }
}
