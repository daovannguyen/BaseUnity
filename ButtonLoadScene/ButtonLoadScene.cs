using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonLoadScene : MonoBehaviour
{
    public List<SceneName> scenesName;
    // khi index level bằng 0, tức là load sang level tiếp theo
    public int indexLevel;
    private Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClickButon);
    }
    public List<string> GetScenesName()
    {
        List<string> scenesNameString = new List<string>();
        foreach (var i in scenesName)
        {
            if (i == SceneName.Level)
            {
                if (indexLevel == 0)
                {
                    scenesNameString.Add(SceneName.Level.ToString() + (MyScene.GetCurrentLevel() + 1).ToString());   
                }
                else
                {
                    scenesNameString.Add(SceneName.Level.ToString() + indexLevel.ToString()); 
                }
            }
            else
            {
                scenesNameString.Add(i.ToString());
            }
        }
        return scenesNameString;
    }
    private void OnClickButon()
    {
        MyScene.LoadMutilScene(GetScenesName());
    }
}
