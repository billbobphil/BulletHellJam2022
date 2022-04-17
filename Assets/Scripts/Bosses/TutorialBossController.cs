using System;
using System.Collections;
using System.Collections.Generic;
using Bosses;
using Guns;
using UnityEngine;
using Object = System.Object;

public class TutorialBossController : BossController
{
    private enum BossState
    {
        Passive,
        BasicGun,
        SpreadGun
    }
    
    private BossState _bossState = BossState.Passive;
    private bool _hasStarted = false;
    private BackgroundMusicController _backgroundMusicController;

    private void Awake()
    {
        _backgroundMusicController = GameObject.FindWithTag("MainCamera").GetComponent<BackgroundMusicController>();
    }
    
    protected override void AdditionalStartRoutineLogic()
    {
        ChangeBossState(BossState.Passive);
    }
    
    public override void CommenceBattleStart()
    {
        if (!_hasStarted)
        {
            _hasStarted = true;
            ChangeBossState(BossState.BasicGun);
            StartCoroutine(SwitchToSpreadGun());
        }
    }

    private void ChangeBossState(BossState newState)
    {
        _bossState = newState;

        if (newState == BossState.Passive)
        {
            _backgroundMusicController.SwitchToPassiveTrack();
        }
        else
        {
            _backgroundMusicController.SwitchToActionTrack();
        }
        
        Act();
    }

    private void Act()
    {
        switch (_bossState)
        {
            case BossState.Passive:
                guns[0].GetComponent<GunController>().TurnOff();
                break;
            case BossState.BasicGun:
                DisableAllGuns();
                guns[0].GetComponent<GunController>().TurnOn();
                break;
            case BossState.SpreadGun:
                DisableAllGuns();
                guns[1].GetComponent<GunController>().TurnOn();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void DisableAllGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.GetComponent<GunController>().TurnOff();
        }
    }

    private IEnumerator SwitchToSpreadGun()
    {
        yield return new WaitForSecondsRealtime(8);
        ChangeBossState(BossState.SpreadGun);
    }
}