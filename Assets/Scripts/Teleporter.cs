using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Teleporter : MonoBehaviour
{
    public Transform transformToTeleport;
    public bool desactivateForPlayer1;
    public bool desactivateForPlayer2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !desactivateForPlayer1)
        {
            collision.gameObject.transform.position = transformToTeleport.position;
        }
        if (collision.CompareTag("Player2") && !desactivateForPlayer2)
        {
            collision.gameObject.transform.position = transformToTeleport.position;
        }
    }

}
