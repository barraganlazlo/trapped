using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnClickLoadLevel : MonoBehaviour
{
    public int levelIndex = 0;
    public bool loadNextLevel;
    public float time = 0;
    private void OnMouseDown()
    {
        if (loadNextLevel)
        {
            LevelManager.instance.LoadNextLevel(time);

        }
        else
        {
            LevelManager.instance.LoadLevel(levelIndex, time);
        }
    }
}
