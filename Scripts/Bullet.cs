using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;
    public float bulletDestroyDelay = 5f;

    public AudioClip damageEnemySound;

    private void Start()
    {
        StartCoroutine(DestroyBulletAfterDelay());        
    }

    private IEnumerator DestroyBulletAfterDelay()
    {
        yield return new WaitForSeconds(bulletDestroyDelay);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {            
            AudioSource.PlayClipAtPoint(damageEnemySound, transform.position);            
            Destroy(gameObject);            
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
        }
    }
}
