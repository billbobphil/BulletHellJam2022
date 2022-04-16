using System.Collections;
using System.Collections.Generic;
using Guns;
using Unity.Mathematics;
using UnityEngine;

public class SpreadGunController : GunController
{
    protected override void CreateBullets()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0,0,0));
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0,0,30));
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0,0,-30));
    }
}
