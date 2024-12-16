using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    public Animator playerAnimator;
    public AudioSource runSound;

    public float levelBorderLeft = -80f;
    public float levelBorderRight = 80f;

    void LevelBorderCheck()
    {
        BackgroundHousesMovement bhm = FindObjectOfType<BackgroundHousesMovement>();

        if (transform.position.x < levelBorderLeft)
        {
            transform.position = new Vector2(levelBorderLeft, transform.position.y);              
        }
        if (transform.position.x > levelBorderRight)
        {
            transform.position = new Vector2(levelBorderRight, transform.position.y);            
        }
        
        if ((transform.position.x <  levelBorderLeft + 1) && (transform.position.x > levelBorderLeft - 1) || ((transform.position.x < levelBorderRight + 1) && (transform.position.x > levelBorderRight - 1)))
        {
            bhm.backSpeed = 0;
        }
        else
        {
            bhm.backSpeed = 0.5f;
        }



    }

    void Update()
    {
        LevelBorderCheck();

        float horizontalMove = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        Vector2 movement = new Vector2(horizontalMove, 0.0f);
        transform.Translate(movement);

        if (horizontalMove != 0)
        {
            playerAnimator.SetBool("isRunning", true);            
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }

        if (horizontalMove < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (horizontalMove > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Mathf.Abs(horizontalMove) > 0.015f)
        {
            if (!runSound.isPlaying)
            {
                runSound.Play();
            }
        }

    }      
}
