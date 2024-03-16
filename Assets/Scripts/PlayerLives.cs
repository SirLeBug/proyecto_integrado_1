using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{

    //public Animator animator;

    public float spawnProtectionTimer;
    public int numberOfFlashes;
    public float iFrameTime;
    private bool collisionEnabled = true;
    private int lives = 3;
    private SpriteRenderer spriteRend;
    Animator animator;

    public Image RightHeart;
    public Image MiddleHeart;
    public Image LeftHeart;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

            calculateHealth();

            if(lives > 0)
            {
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

    public void calculateHealth()
    {
        switch (lives)
        {
            case 0:
                RightHeart.color = new Color(1, 0, 0, 0.5f);
                MiddleHeart.color = new Color(1, 0, 0, 0.5f);
                LeftHeart.color = new Color(1, 0, 0, 0.5f);
                StartCoroutine(playerDeath());
                Debug.Log("You died");
                break;

            case 1:
                Debug.Log("Current lives: " + lives);
                RightHeart.color = new Color(1, 0, 0, 0.5f);
                MiddleHeart.color = new Color(1, 0, 0, 0.5f);
                LeftHeart.color = Color.white;
                break;

            case 2:
                Debug.Log("Current lives: " + lives);
                RightHeart.color = new Color(1, 0, 0, 0.5f);
                MiddleHeart.color = Color.white;
                LeftHeart.color = Color.white;
                break;

            case 3:
                Debug.Log("Current lives: " + lives);
                RightHeart.color = Color.white;
                MiddleHeart.color = Color.white;
                LeftHeart.color = Color.white;
                break;
        }
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

    private IEnumerator playerDeath()
    {
        GetComponent<PlayerMove>().canMove = false;
        animator.Play("death");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
