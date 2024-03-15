using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    public float spawnProtectionTimer;
    private bool collisionEnabled = true;
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") && collisionEnabled)
        {
            //death++;

            //SetCountText();
            lives--;
            StartCoroutine(collideProtection());
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            //count++;

            //SetCountText();
        }
    }

    IEnumerator collideProtection()
    {
        collisionEnabled = false;
        yield return new WaitForSeconds(spawnProtectionTimer);
        collisionEnabled = true;
    }
}
