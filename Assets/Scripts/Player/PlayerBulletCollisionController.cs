using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollisionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            Debug.Log("Player hit by bullet");
        }
    }
}
