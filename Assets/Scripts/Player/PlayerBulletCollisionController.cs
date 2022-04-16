using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollisionController : MonoBehaviour
{
    private PlayerDeathController _playerDeathController;

    private void Awake()
    {
        _playerDeathController = GameObject.FindWithTag("Overseer").GetComponent<PlayerDeathController>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            _playerDeathController.KillPlayer();
        }
    }
}
