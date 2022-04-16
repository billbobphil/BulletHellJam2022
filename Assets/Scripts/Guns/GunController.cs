using System.Collections;
using UnityEngine;

namespace Guns
{
    public abstract class GunController : MonoBehaviour
    {
        public GameObject bullet;
        public float fireRate;
        protected bool _isGunOn = false;
        private IEnumerator _fireCoroutine;

        public void TurnOn()
        {
            _isGunOn = true;
            if (_fireCoroutine == null)
            {
                _fireCoroutine = Fire();
                StartCoroutine(_fireCoroutine);    
            }
        }

        public void TurnOff()
        {
            _isGunOn = false;
            if (_fireCoroutine != null)
            {
                StopCoroutine(_fireCoroutine);
                _fireCoroutine = null;
            }
        }

        protected IEnumerator Fire()
        {
            while (_isGunOn)
            {
                yield return new WaitForSecondsRealtime(fireRate);
                CreateBullets();
            }
        }
        
        protected abstract void CreateBullets();
    }
}