using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{

    public float spawnProtectionTimer;
    public int numberOfFlashes;
    public float iFrameTime;
    private bool collisionEnabled = true;
    private int lives = 3;
    private SpriteRenderer spriteRend;
    Animator animator;

    public float oriSpeed;
    public float oriJump;
    public float buffSpeed = 2.2f;
    public float buffJump = 4f;
    public bool canBuff = true;

    public Image RightHeart;
    public Image MiddleHeart;
    public Image LeftHeart;
    public Image MushroomBuff;

    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        oriSpeed = GameObject.Find("Player").GetComponent<PlayerMove>().runSpeed;
        oriJump = GameObject.Find("Player").GetComponent<PlayerMove>().jumpSpeed;
        canBuff = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") && collisionEnabled)
        {

            lives--;

            calculateHealth();

            if(lives > 0)
            {
                StartCoroutine(collideProtection());
            }

            

        }

        if (other.gameObject.CompareTag("Coin"))
        {
            //Unused
        }

        if (other.gameObject.CompareTag("Powerup"))
        {
            if(canBuff)
            {
                StartCoroutine(playerBuff());
                StartCoroutine(buffBlink());    
            }
        }
    }

    public bool canHeal()
    {
        return lives < 3;
    }

    public void healPlayer()
    {
        if(lives < 3)
        {
            lives++;
            calculateHealth();
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

    public IEnumerator playerBuff()
    {
        canBuff = false;
        GameObject.Find("Player").GetComponent<PlayerMove>().runSpeed = buffSpeed;
        GameObject.Find("Player").GetComponent<PlayerMove>().jumpSpeed = buffJump;
        yield return new WaitForSeconds(5);
        GameObject.Find("Player").GetComponent<PlayerMove>().runSpeed = oriSpeed;
        GameObject.Find("Player").GetComponent<PlayerMove>().jumpSpeed = oriJump;
        canBuff = true;
    }

    private IEnumerator buffBlink()
    {
        for (int i = 0; i < 5; i++)
        {
            MushroomBuff.color = new Color(1, 0.9309688f, 0, 1);
            yield return new WaitForSeconds(0.5f);
            MushroomBuff.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
        MushroomBuff.color = new Color(1, 1, 1, 0);
    }
}
