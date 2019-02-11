using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int firstLevel = 1;
    bool Looped;
    bool reloaded;
    public int levelIndex = 0;
    void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextLevel(float time)
    {
        reloaded = false;
        levelIndex += 1;
        LoadLevel(levelIndex, time);
    }
    public void LoadFirstLevel(float time)
    {
        reloaded = false;
        LoadLevel(firstLevel, time);
    }
    public void LoadLevel(int i, float time)
    {
        levelIndex = i;
        StartCoroutine(LoadLevelCoroutine(i, time));
    }
    IEnumerator LoadLevelCoroutine(int i, float f)
    {
        yield return new WaitForSeconds(f);
        SceneManager.LoadScene(i);
    }
    public void LoopLevels(float time)
    {
        if (!Looped)
        {
            Looped =true;
            LoadFirstLevel(time);
        }
    }
    public void ReloadLevel(float time)
    {
        reloaded = true;
        LoadLevel(levelIndex,time);
    }
    public bool HasReloaded()
    {
        return reloaded;
    }
    public bool HasLooped()
    {
        return Looped;
    }
}
