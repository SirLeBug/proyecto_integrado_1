using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollected : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GameObject.Find("ControlCenter").GetComponent<SceneController>().coinsRemaining--;
            GameObject.Find("ControlCenter").GetComponent<SceneController>().checkCoinsRemaining();
            Destroy(gameObject, 0.5f);
        }

    }
}
