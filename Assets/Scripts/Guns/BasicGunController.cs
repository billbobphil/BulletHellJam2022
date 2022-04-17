using System.Collections;
using System.Collections.Generic;
using Guns;
using UnityEngine;

public class BasicGunController : GunController
{
    protected override void CreateBullets()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 1, 0), new Quaternion());
    }
}
