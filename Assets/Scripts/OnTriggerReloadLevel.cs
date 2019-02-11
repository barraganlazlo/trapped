using UnityEngine;

public class OnTriggerReloadLevel : MonoBehaviour
{
    public float time;
    public bool desactivateForPlayer1;
    public bool desactivateForPlayer2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !desactivateForPlayer1)
        {
            LevelManager.instance.ReloadLevel(time);
        }
        else if (collision.CompareTag("Player2") && !desactivateForPlayer2)
        {
            LevelManager.instance.ReloadLevel(time);
        }
    }
}
