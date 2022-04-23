using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Overseer;
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
        private SwordPositionController _swordPositionController;

        private void Awake()
        {
            _myAudioSources = gameObject.GetComponents<AudioSource>().ToList();
        }
        
        private void Start()
        {
            _collider = gameObject.GetComponent<Collider2D>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _swordPositionController = GetComponentInParent<SwordPositionController>();
            DisableSword();
        }

        public void DisableSword()
        {
            _swordAvailable = true;
            MakeSwordInactive();
            MakeSwordInvisible();
        }

        private void MakeSwordInactive()
        {
            _collider.enabled = false;
        }

        private void MakeSwordInvisible()
        {
            _spriteRenderer.enabled = false;
        }

        private void MakeSwordAvailable()
        {
            _swordAvailable = true;
            _swordPositionController.SetSwordIsActive(false);
        }

        public void SwingSword()
        {
            if (_swordAvailable)
            {
                _swordPositionController.SetSwordIsActive(true);
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
            yield return new WaitForSecondsRealtime(0.1f);
            MakeSwordInactive();
            yield return new WaitForSecondsRealtime(0.2f);
            MakeSwordInvisible();
            yield return new WaitForSecondsRealtime(.15f);
            MakeSwordAvailable();
            _hitSomethingRelevant = false;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            _hitSomethingRelevant = true;
            if (col.CompareTag("Weakspot"))
            {
                _myAudioSources[0].Play();
                GameObject.FindWithTag("Overseer").GetComponent<VictoryController>().VictoryAchieved();
            }

            if (col.CompareTag("PlatformControlNode"))
            {
                _myAudioSources[0].Play();
                col.gameObject.GetComponent<PlatformDirectionNodeController>().HitBySword();
            }
        }
    }
}
