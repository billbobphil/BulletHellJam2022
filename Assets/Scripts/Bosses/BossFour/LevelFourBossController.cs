using System;
using System.Collections;
using System.Collections.Generic;
using Bosses;
using UnityEngine;

public class LevelFourBossController : BossController
{
    public enum BossFourState {
        Passive
    }

    private BossFourState _bossState;
    private bool _hasStarted;
    
    protected override void AdditionalStartRoutineLogic()
    {
    }
    public override void CommenceBattleStart()
    {
        if (!_hasStarted)
        {
            _hasStarted = true;
            ChangeBossState(BossFourState.Passive);
        }
    }

    public override void BecomeInactive()
    {
        ChangeBossState(BossFourState.Passive);
        DisableAllGuns();
    }
    
    public void ChangeBossState(BossFourState newState)
    {
        _bossState = newState;

        if (newState == BossFourState.Passive)
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
            case BossFourState.Passive:
                DisableAllGuns();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
