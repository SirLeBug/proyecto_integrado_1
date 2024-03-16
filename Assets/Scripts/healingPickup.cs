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
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //sound.Play();
            GameObject.Find("Player").GetComponent<PlayerLives>().healPlayer();
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
