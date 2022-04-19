using System.Collections;
using System.Collections.Generic;
using Bullets;
using Guns;
using UnityEngine;

public class HorizontalLineGunController : GunController
{
    public int numberOfBulletsPerLine;
    public int bulletGap;
    private float _offsetFromZero = 0;
    private int _cycleCount = 0;

    protected override void CreateBullets()
    {
        int currentBulletGap = bulletGap;
        
        for (int i = 0; i < numberOfBulletsPerLine; i++)
        {
            
            if (i == 0)
            {
                
                GameObject tempbullet = Instantiate(bullet, new Vector3(transform.position.x + _offsetFromZero, transform.position.y - 1, 0), new Quaternion());
                tempbullet.GetComponent<BulletController>().myGunController = this;
            }
            else if (i % 2 == 0)
            {
                GameObject tempbullet = Instantiate(bullet, new Vector3(transform.position.x + currentBulletGap + _offsetFromZero, transform.position.y - 1, 0), new Quaternion());
                tempbullet.GetComponent<BulletController>().myGunController = this;
                currentBulletGap += bulletGap;
            }
            else
            {
                GameObject tempbullet = Instantiate(bullet, new Vector3(transform.position.x - currentBulletGap + _offsetFromZero, transform.position.y - 1, 0), new Quaternion());
                tempbullet.GetComponent<BulletController>().myGunController = this;
            }
        }

        if (_cycleCount == 3)
        {
            _cycleCount = 0;
        }
        else
        {
            _cycleCount++;
        }

        _offsetFromZero = _cycleCount * 1.5f;

        if (_cycleCount % 2 != 0)
        {
            _offsetFromZero *= -1;
        }
    }
}
