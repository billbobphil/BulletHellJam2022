using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
