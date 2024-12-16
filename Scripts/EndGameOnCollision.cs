using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameOnCollision : MonoBehaviour
{
    public GameObject EndGameScreen;
    public GameObject audioSources;
    public AudioSource ammoSound, playerDeathSound;    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerDeathSound.Play();
            GameOver();
        }

        if (collision.gameObject.CompareTag("Ammo"))
        {
            ammoSound.Play();
            GetComponent<PlayerShoot>().ammo += Random.Range(1, 25);
            Destroy(collision.gameObject);
        }
    }      

    public void GameOver()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerShoot>().enabled = false;     
        
        EnemyMovement[] enemyMovements = FindObjectsOfType<EnemyMovement>();
        foreach (EnemyMovement enemyMovement in enemyMovements)
        {
            enemyMovement.enabled = false;
        }        
        Animator[] animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators)
        {
            animator.enabled = false;
        }
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
        {
            spawner.enabled = false;
        }

        FindObjectOfType<BackgroundHousesMovement>().enabled = false;
        audioSources.SetActive(false);

        EndGameScreen.SetActive(true);
    }
}

