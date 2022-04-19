using Bullets;
using UnityEngine;

namespace Guns
{
    public class BigBallExplosionController : GunController
    {
        public int numberOfGroups;
        private float _angleGap;
        
        
        private void Start()
        {
            if (numberOfGroups % 2 == 0)
            {
                _angleGap = - -1 * ((90 / numberOfGroups));
            }
            else
            {
                // _angleGap = - -1 * ((90 / (numberOfGroups - 1)) - 90);
                _angleGap = - -1 * ((90 / (numberOfGroups - 1)));
            }
        }

        protected override void CreateBullets()
        {
            if (numberOfGroups % 2 == 0)
            {
                float currentAngleGap = _angleGap;
                
                for (int i = 1; i <= numberOfGroups; i++)
                {
                    int multiplier = i % 2 == 0 ? 1 : -1;
                    
                    GenerateBulletGroup(Quaternion.Euler(0,  0, currentAngleGap * multiplier));

                    if (i % 2 == 0)
                    {
                        currentAngleGap *= 2;
                    }
                }
            }
            else
            {
                float currentAngleGap = _angleGap;
                
                for (int i = 1; i <= numberOfGroups; i++)
                {
                    if (i == 1)
                    {
                        GenerateBulletGroup(Quaternion.Euler(0,  0, 0));
                    }
                    else
                    {
                        int multiplier = i % 2 == 0 ? 1 : -1;
                        GenerateBulletGroup(Quaternion.Euler(0,  0, currentAngleGap * multiplier));
                        
                        if (i % 2 != 0)
                        {
                            currentAngleGap *= 2;
                        }
                    }
                }
            }
        }

        private void GenerateBulletGroup(Quaternion angle)
        {
            //top
            GameObject tempbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 1.5f, 0), angle);
            tempbullet.gameObject.GetComponent<TrajectoryChangeBulletController>().PostChangeTrajectory = new Vector3(0, -.25f, 0);
            tempbullet.GetComponent<BulletController>().myGunController = this;

            //bottom
            tempbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - .5f, 0), angle);
            tempbullet.gameObject.GetComponent<TrajectoryChangeBulletController>().PostChangeTrajectory = new Vector3(0, .25f, 0);
            tempbullet.GetComponent<BulletController>().myGunController = this;

            //left
            tempbullet = Instantiate(bullet, new Vector3(transform.position.x + .5f, transform.position.y -1f, 0), angle);
            tempbullet.gameObject.GetComponent<TrajectoryChangeBulletController>().PostChangeTrajectory = new Vector3(-.25f, -.25f, 0);
            tempbullet.GetComponent<BulletController>().myGunController = this;

            //right
            tempbullet = Instantiate(bullet, new Vector3(transform.position.x - .5f, transform.position.y -1f, 0), angle);
            tempbullet.gameObject.GetComponent<TrajectoryChangeBulletController>().PostChangeTrajectory = new Vector3(.25f, -.25f, 0);
            tempbullet.GetComponent<BulletController>().myGunController = this;

            //mid-right
            tempbullet = Instantiate(bullet, new Vector3(transform.position.x + .3f, transform.position.y - .75f, 0), angle);
            tempbullet.gameObject.GetComponent<TrajectoryChangeBulletController>().PostChangeTrajectory = new Vector3(-.125f, -.25f, 0);
            tempbullet.GetComponent<BulletController>().myGunController = this;

            //mid-left
            tempbullet = Instantiate(bullet, new Vector3(transform.position.x - .3f, transform.position.y - .75f, 0), angle);
            tempbullet.gameObject.GetComponent<TrajectoryChangeBulletController>().PostChangeTrajectory = new Vector3(.125f, -.25f, 0);
            tempbullet.GetComponent<BulletController>().myGunController = this;
        }
    }
}