using System;
using Guns;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bullets
{
    public abstract class BulletController : MonoBehaviour
    {
        private Color _myColor;
        [NonSerialized]
        public Vector3 BulletSpeed;

        [NonSerialized] public GunController myGunController;
        
    
        protected void Start()
        {
            _myColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            GetComponent<SpriteRenderer>().color = _myColor;
            GetComponent<TrailRenderer>().startColor = _myColor;
            StartLogicHook();
        }
        
        protected void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
        
        protected abstract void StartLogicHook();
    }
}