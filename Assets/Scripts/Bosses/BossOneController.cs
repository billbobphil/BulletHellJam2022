using System;
using System.Collections;
using System.Collections.Generic;
using Bosses;
using UnityEngine;
using Object = System.Object;

public class BossOneController : MonoBehaviour, IBossController
{
    private BossOneState _bossState = BossOneState.Passive;
    public List<GameObject> bulletTypes;
    private IEnumerator _spawningCoroutine;
    private bool _hasStarted = false;

    public void CommenceBattleStart()
    {
        if (!_hasStarted)
        {
            Debug.Log("Boss received battle start command");
            _hasStarted = true;
            _bossState = BossOneState.Aggressive;
        }
    }

    private void FixedUpdate()
    {
        Act();
    }

    private void Act()
    {
        switch (_bossState)
        {
            case BossOneState.Passive:
                if (_spawningCoroutine != null)
                {
                    StopCoroutine(_spawningCoroutine);
                }
                break;
            case BossOneState.Aggressive:
                if (_spawningCoroutine == null)
                {
                    _spawningCoroutine = SpawnBullets();
                    StartCoroutine(_spawningCoroutine);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private IEnumerator SpawnBullets()
    {
        for (;;)
        {
            yield return new WaitForSecondsRealtime(1f);
            Instantiate(bulletTypes[0], new Vector3(transform.position.x, transform.position.y, 0), new Quaternion());
        }
    }
}