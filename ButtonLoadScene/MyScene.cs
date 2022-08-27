using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MyScene
{   
    public static int GetCurrentLevel()
    {
        List<string> scensName = GetAllSceneNameActive();
        for (int i = 0; i < scensName.Count; i++)
        {
            if (scensName[i].Contains(SceneName.Level.ToString()))
            {
                return SceneManager.GetSceneAt(i).buildIndex;
            }
        }

        return 0;
    } 
    public static List<string> GetAllSceneNameActive()
    {
        List<string> sceneNames = new List<string>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            sceneNames.Add((SceneManager.GetSceneAt(i).name));
        }
        return sceneNames;
    }
    public static void ReloadAllScene()
    {
        LoadMutilScene(GetAllSceneNameActive());
        
    }
    public static void LoadMutilScene(List<string> scenesName)
    {
        for (int i = 0; i < scenesName.Count; i++)
        {
            if (i == 0)
            {
                SceneManager.LoadScene(scenesName[i]);   
                continue;
            }
            SceneManager.LoadScene(scenesName[i], LoadSceneMode.Additive);
        }
    }
    
    public static void LoadMutilScene(List<SceneName> scenesName)
    {
        for (int i = 0; i < scenesName.Count; i++)
        {
            if (i == 0)
            {
                SceneManager.LoadScene(scenesName[i].ToString());   
                continue;
            }
            SceneManager.LoadScene(scenesName[i].ToString(), LoadSceneMode.Additive);
        }
    }
    public static List<string> GetAllSceneNameNextLevel()
    {
        List<string> sceneNames = new List<string>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name.Contains(SceneName.Level.ToString()))
            {
                sceneNames.Add(SceneName.Level + (SceneManager.GetSceneAt(i).buildIndex + 1).ToString());
            }
            else
            {
                sceneNames.Add((SceneManager.GetSceneAt(i).name));
            }
        }
        return sceneNames;
    }

    public static void LoadNextLevel()
    {
        LoadMutilScene(GetAllSceneNameNextLevel());
    }
}
