using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class SwordAttackController : MonoBehaviour
    {
        private bool _swordAvailable = false;
        private Collider2D _collider;
        private SpriteRenderer _spriteRenderer;
        private List<AudioSource> _myAudioSources;
        private bool _hitSomethingRelevant = false;

        private void Awake()
        {
            _myAudioSources = gameObject.GetComponents<AudioSource>().ToList();
        }
        
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
                if (!_hitSomethingRelevant)
                {
                    _myAudioSources[1].Play();
                }
            }
        }
    
        private IEnumerator CancelSwordHitbox()
        {
            yield return new WaitForSecondsRealtime(0.3f);
            MakeSwordInactive();
            yield return new WaitForSecondsRealtime(.3f);
            MakeSwordAvailable();
            _hitSomethingRelevant = false;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            _hitSomethingRelevant = true;
            if (col.CompareTag("Weakspot"))
            {
                _myAudioSources[0].Play();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (col.CompareTag("PlatformControlNode"))
            {
                _myAudioSources[0].Play();
                col.gameObject.GetComponent<PlatformDirectionNodeController>().HitBySword();
            }
        }
    }
}
