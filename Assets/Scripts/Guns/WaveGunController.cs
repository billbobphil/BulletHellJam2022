using System.Collections;
using System.Collections.Generic;
using Bullets;
using Guns;
using UnityEngine;

public class WaveGunController : GunController
{
    public int numberOfBulletsPerLine;
    public int bulletGap;
    public float bulletSpeedIncrement;
    private float _originalBulletSpeed;
    private bool _isRotated;

    private void Start()
    {
        _originalBulletSpeed = bulletSpeed.y;
        _isRotated = transform.rotation == Quaternion.Euler(0, 0, 90);
    }
    
    protected override void CreateBullets()
    {
        int currentBulletGap = bulletGap;
        
        for (int i = 0; i < numberOfBulletsPerLine; i++)
        {
            
            if (i == 0)
            {
                GameObject tempbullet;
                if (_isRotated)
                {
                    tempbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                }
                else
                {
                    tempbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 2f, 0), transform.rotation);
                }
                
                tempbullet.GetComponent<BulletController>().BulletSpeed = bulletSpeed;
            }
            else if (i % 2 == 0)
            {
                GameObject tempbullet;
                if (_isRotated)
                {
                    tempbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + currentBulletGap, 0), transform.rotation);
                }
                else
                {
                    tempbullet = Instantiate(bullet, new Vector3(transform.position.x + currentBulletGap, transform.position.y + 2f, 0), transform.rotation);
                }
               
                tempbullet.GetComponent<BulletController>().BulletSpeed = bulletSpeed;
                currentBulletGap += bulletGap;
            }
            else
            {
                GameObject tempbullet;
                if (_isRotated)
                {
                    tempbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - currentBulletGap, 0), transform.rotation);
                }
                else
                {
                    tempbullet = Instantiate(bullet, new Vector3(transform.position.x - currentBulletGap, transform.position.y + 2f, 0), transform.rotation);
                }
                tempbullet.GetComponent<BulletController>().BulletSpeed = bulletSpeed;
            }
            
            if (i % 2 == 0)
            {
                bulletSpeed.y += bulletSpeedIncrement;
            }
        }

        bulletSpeed.y = _originalBulletSpeed;
    }
}
