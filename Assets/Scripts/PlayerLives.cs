using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    public float spawnProtectionTimer;
    private bool collisionEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        ColliderChecker(other);
    }

    public void ColliderChecker(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            //count++;

            //SetCountText();
        }
        if (other.gameObject.CompareTag("Obstacle") && collisionEnabled)
        {
            //death++;

            //SetCountText();
            StartCoroutine(collideProtection());
        }
    }

    IEnumerator collideProtection()
    {
        collisionEnabled = false;
        yield return new WaitForSeconds(spawnProtectionTimer);
        collisionEnabled = true;
    }
}
