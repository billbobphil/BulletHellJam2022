using System;
using System.Collections;
using Guns;
using Overseer;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bullets
{
    public abstract class BulletController : MonoBehaviour
    {
        private Color _myColor;
        [NonSerialized]
        public Vector3 BulletSpeed;

        private bool shouldDestroyOnTimeInsteadOfVisibility;

        private bool _canBeDestroyed;

        [NonSerialized] public GunController myGunController;
        
    
        protected void Start()
        {
            _myColor = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
            GetComponent<SpriteRenderer>().color = _myColor;
            GetComponent<TrailRenderer>().startColor = _myColor;
            StartLogicHook();
            shouldDestroyOnTimeInsteadOfVisibility = GameObject.FindWithTag("Overseer").GetComponent<BattleStartController>().currentLevel == 5;
            if (shouldDestroyOnTimeInsteadOfVisibility)
            {
                StartCoroutine(DestroyOnTime());
            }
        }

        protected void OnBecameInvisible()
        {
            if (!shouldDestroyOnTimeInsteadOfVisibility)
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator DestroyOnTime()
        {
            yield return new WaitForSecondsRealtime(23);
            Destroy(gameObject);
        }
        
        protected abstract void StartLogicHook();
    }
}