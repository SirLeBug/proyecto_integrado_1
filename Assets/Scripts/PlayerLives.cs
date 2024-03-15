using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{

    //public Animator animator;

    public float spawnProtectionTimer;
    public int numberOfFlashes;
    public float iFrameTime;
    private bool collisionEnabled = true;
    private int lives = 3;
    private SpriteRenderer spriteRend;
    

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

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

            if(lives <= 0)
            {
                PlayerDeath();
                Debug.Log("You died");
            } else
            {
                PlayerDamaged();
                Debug.Log("Current lives: " + lives);
                StartCoroutine(collideProtection());
            }

        }

        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            //count++;

            //SetCountText();
        }
    }

    public void PlayerDamaged()
    {
        //animator.Play("hit");

    }

    public void PlayerDeath()
    {
        //animator.Play("death");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator collideProtection()
    {
        collisionEnabled = false;

        for (int i = 0; i < numberOfFlashes; i++) 
        {
            spriteRend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(iFrameTime / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameTime / (numberOfFlashes * 2));
        }
        
        collisionEnabled = true;
        
    }
}
