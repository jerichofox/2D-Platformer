using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHousesMovement : MonoBehaviour
{
    public float backSpeed = 0.5f;

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * backSpeed * Time.deltaTime;

        Vector2 movement = new Vector2(-horizontalMove, 0.0f);
        transform.Translate(movement);
    }
}
