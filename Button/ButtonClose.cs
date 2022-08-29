using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClose : MyButton
{
    public override void OnClickButton()
    {
        transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
