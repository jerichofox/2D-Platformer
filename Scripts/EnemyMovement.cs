using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public float detectionRadius = 5f; 
    public float enemySpeed = 2f;

    public Animator enemyAnimator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {        

        if (Vector2.Distance(transform.position, player.position) < detectionRadius)
        {
            enemyAnimator.SetBool("isChasing", true);
            if (transform.position.x > player.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;                
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);

        }
        else
        {            
            transform.rotation = Quaternion.identity;
        }
        if (Vector2.Distance(transform.position, player.position) > detectionRadius)
        {
            enemyAnimator.SetBool("isChasing", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

}

