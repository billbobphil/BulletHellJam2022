using System;
using System.Collections;
using System.Collections.Generic;
using Bosses;
using Guns;
using Tutorial;
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
    private bool _hasStarted;
    private IEnumerator _switchToSpreadGunRoutine;

    protected override void AdditionalStartRoutineLogic()
    {
        ChangeBossState(BossState.Passive);
    }
    
    public override void CommenceBattleStart()
    {
        if (!_hasStarted)
        {
            GameObject tutorialManager = GameObject.FindWithTag("TutorialManager");
            
            if (tutorialManager != null)
            {
                tutorialManager.GetComponent<TutorialManagerScript>().EndTutorial();    
            }
            
            _hasStarted = true;
            ChangeBossState(BossState.BasicGun);
            _switchToSpreadGunRoutine = SwitchToSpreadGun();
            StartCoroutine(_switchToSpreadGunRoutine);
        }
    }

    private void ChangeBossState(BossState newState)
    {
        _bossState = newState;

        if (newState == BossState.Passive)
        {
            BackgroundMusicController.SwitchToPassiveTrack();
        }
        else
        {
            BackgroundMusicController.SwitchToActionTrack();
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

    private IEnumerator SwitchToSpreadGun()
    {
        yield return new WaitForSecondsRealtime(10);
        ChangeBossState(BossState.SpreadGun);
    }
    
    public override void BecomeInactive()
    {
        StopCoroutine(_switchToSpreadGunRoutine);
        ChangeBossState(BossState.Passive);
        DisableAllGuns();
    }
}