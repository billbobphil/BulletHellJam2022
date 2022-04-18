using UnityEngine;

namespace Bullets
{
    public abstract class BulletController : MonoBehaviour
    {
        private Color _myColor;
    
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