using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollected : MonoBehaviour
{

    //public AudioSource sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //sound.Play();
            GameObject.Find("ControlCenter").GetComponent<SceneController>().coinsRemaining--;
            GameObject.Find("ControlCenter").GetComponent<SceneController>().checkCoinsRemaining();
            Destroy(gameObject, 0.5f);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
