using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class SwordAttackController : MonoBehaviour
    {
        private bool _swordAvailable = false;
        private Collider2D _collider;
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _collider = gameObject.GetComponent<Collider2D>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void DisableSword()
        {
            _swordAvailable = true;
            MakeSwordInactive();
        }

        private void MakeSwordInactive()
        {
            _collider.enabled = false;
            _spriteRenderer.enabled = false;
        }

        private void MakeSwordAvailable()
        {
            _swordAvailable = true;
        }

        public void SwingSword()
        {
            if (_swordAvailable)
            {
                _swordAvailable = false;
                _collider.enabled = true;
                _spriteRenderer.enabled = true;
                StartCoroutine(CancelSwordHitbox());
            }
        }
    
        private IEnumerator CancelSwordHitbox()
        {
            yield return new WaitForSecondsRealtime(0.3f);
            MakeSwordInactive();
            yield return new WaitForSecondsRealtime(.3f);
            MakeSwordAvailable();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Weakspot"))
            {
                Debug.Log("BOSS KILL");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
