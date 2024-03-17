using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWalk : MonoBehaviour
{
    Rigidbody2D rb2D;
    SpriteRenderer spR;
    Animator animator;
    public float timeWalking = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
        StartCoroutine(shadowStep());
    }

    private IEnumerator shadowStep()
    {
        rb2D.velocity = new Vector2(1.1f, rb2D.velocity.y);
        spR.flipX = false;
        yield return new WaitForSeconds(timeWalking);
        rb2D.velocity = new Vector2(-1.1f, rb2D.velocity.y);
        spR.flipX = true;
        yield return new WaitForSeconds(timeWalking);
        StartCoroutine(shadowStep());
    }
}
