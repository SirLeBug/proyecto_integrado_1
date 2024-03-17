using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameObject.Find("Player").GetComponent<PlayerLives>().canBuff)
        {
            Debug.Log("Mushroom");
            StartCoroutine(respawnMushroom());
        }

    }

    private IEnumerator respawnMushroom()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(10);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
