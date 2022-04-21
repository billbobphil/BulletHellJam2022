using System;
using System.Collections;
using System.Collections.Generic;
using Bullets;
using Guns;
using UnityEngine;

public class OscillationGunController : GunController
{
    public float rotationIncrement;
    public float maximumAngle;
    

    private void FixedUpdate()
    {
        if (transform.rotation == Quaternion.Euler(0, 0, maximumAngle))
        {
            maximumAngle *= -1;
        }
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, maximumAngle), rotationIncrement);
    }

    protected override void CreateBullets()
    {
        GameObject temp = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 1, 0), transform.rotation);
        temp.GetComponent<BulletController>().myGunController = this;
    }
}
