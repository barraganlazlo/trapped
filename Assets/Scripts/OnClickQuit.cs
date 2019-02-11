using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnClickQuit : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void OnMouseDown()
    {
        Application.Quit();
    }
}
