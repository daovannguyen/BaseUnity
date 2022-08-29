using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MyButton : MonoBehaviour
{
    [HideInInspector] public Button btn;

    public virtual void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickButton);
    }

    public virtual void OnClickButton(){}
}
