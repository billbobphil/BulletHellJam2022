using System.Collections;
using System.Collections.Generic;
using Bullets;
using Guns;
using Unity.Mathematics;
using UnityEngine;

public class SpreadGunController : GunController
{
    protected override void CreateBullets()
    {
        GameObject tempbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.Euler(0,0,0));
        tempbullet.GetComponent<BulletController>().myGunController = this;
        
        tempbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.Euler(0,0,30));
        tempbullet.GetComponent<BulletController>().myGunController = this;
        
        tempbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.Euler(0,0,-30));
        tempbullet.GetComponent<BulletController>().myGunController = this;
    }
}
