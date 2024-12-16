using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public float bulletSpeed = 10f; 
    public Transform bulletSpawnPointRight;
    public Transform bulletSpawnPointLeft;

    public float fireRate = 0.5f;
    float nextFireTime = 0f;

    public int ammo =10;
    public TextMeshProUGUI ammoText;

    public Animator playerAnimator;

    public AudioSource shellSound , shotSound;   


    void Update()
    {
        ammoText.text = "" + ammo;
        if (Input.GetAxis("Fire1") > 0)
        {
            ShootBullet();
        }
        else
        {
            playerAnimator.SetBool("isShooting", false);
        }        
    }

    void ShootBullet()
    {
        if(Time.time > nextFireTime)
        {
            playerAnimator.SetBool("isShooting", true);
            shotSound.Play();
            shellSound.Play();

            if (GetComponent<SpriteRenderer>().flipX)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPointLeft.position, Quaternion.identity);
                bullet.GetComponent<SpriteRenderer>().flipX = true;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = -transform.right * bulletSpeed;
            }
            if (!GetComponent<SpriteRenderer>().flipX)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPointRight.position, Quaternion.identity);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = transform.right * bulletSpeed;
            }
            nextFireTime = Time.time + fireRate;            
            ammo -= 1;
            if (ammo <= 0)
            {
                ammoText.text = "0";
                GetComponent<EndGameOnCollision>().GameOver();
            }            

        }
        
    }
}
