using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameObject.Find("Player").GetComponent<PlayerLives>().canHeal())
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GameObject.Find("Player").GetComponent<PlayerLives>().healPlayer();
            Destroy(gameObject, 0.5f);
        }
    }
}
