using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 100;
    public Slider slider;

    public GameObject ammoPrefab;

    public AudioClip enemyDeathSound;

    private void Start()
    {
        slider.maxValue = enemyHealth;
    }

    private void Update()
    {              
        if (enemyHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
            AmmoDrop();
            Destroy(gameObject);           
        }
        else
        {
            slider.value = enemyHealth;
        }
    }   

    void AmmoDrop()
    {
        PlayerMovement plm = FindObjectOfType<PlayerMovement>();
        if (transform.position.x > plm.levelBorderLeft && transform.position.x < plm.levelBorderRight)
        {
            Instantiate(ammoPrefab, transform.position, Quaternion.identity);
        }
    }

}
