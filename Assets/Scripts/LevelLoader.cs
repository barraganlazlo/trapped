using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LevelLoader : MonoBehaviour
{
    public bool loopLevel;
    public float time;
    public bool player2Needed;
    bool player2IsHere;
    bool player1IsHere;
    bool alreadyLoaded;
    private void Update()
    {
        if (alreadyLoaded || !player1IsHere)
        {
            return;
        }
        if (player2Needed && !player2IsHere)
        {
            return;
        }
        if (Input.GetButton("Interract"))
        {
            alreadyLoaded = true;
            if (loopLevel)
            {
                LevelManager.instance.LoopLevels(time);
            }
            else
            {
                LevelManager.instance.LoadNextLevel(time);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            player1IsHere = true;
        }
        if (collider.tag == "Player2")
        {
            player2IsHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            player1IsHere = false;
        }
        if (collider.tag == "Player2")
        {
            player2IsHere = false;
        }
    }
}