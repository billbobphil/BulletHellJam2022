using System.Collections;
using UnityEngine;

namespace Guns
{
    public abstract class GunController : MonoBehaviour
    {
        public GameObject bullet;
        public float fireRate;
        protected bool IsGunOn = false;
        private IEnumerator _fireCoroutine;
        private AudioSource _myAudioSource;

        private void Awake()
        {
            _myAudioSource = gameObject.GetComponent<AudioSource>();
        }
        
        public void TurnOn()
        {
            IsGunOn = true;
            if (_fireCoroutine == null)
            {
                _fireCoroutine = Fire();
                StartCoroutine(_fireCoroutine);    
            }
        }

        public void TurnOff()
        {
            IsGunOn = false;
            if (_fireCoroutine != null)
            {
                StopCoroutine(_fireCoroutine);
                _fireCoroutine = null;
            }
        }

        protected IEnumerator Fire()
        {
            while (IsGunOn)
            {
                yield return new WaitForSecondsRealtime(fireRate);
                _myAudioSource.Play();
                CreateBullets();
            }
        }
        
        protected abstract void CreateBullets();
    }
}