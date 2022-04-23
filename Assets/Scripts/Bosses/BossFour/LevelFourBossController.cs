using System;
using System.Collections;
using System.Collections.Generic;
using Bosses;
using Guns;
using UnityEngine;

public class LevelFourBossController : BossController
{
    public enum BossFourState {
        Passive,
        PhaseOne,
        PhaseTwo,
        PhaseThree,
        PhaseFour,
        PhaseFive
    }

    public BossFourState bossState;
    private bool _hasStarted;
    
    protected override void AdditionalStartRoutineLogic()
    {
    }
    public override void CommenceBattleStart()
    {
        if (!_hasStarted)
        {
            _hasStarted = true;
            ChangeBossState(BossFourState.PhaseOne);
        }
    }

    public override void BecomeInactive()
    {
        ChangeBossState(BossFourState.Passive);
        DisableAllGuns();
    }
    
    public void ChangeBossState(BossFourState newState)
    {
        bossState = newState;

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
        switch (bossState)
        {
            case BossFourState.Passive:
                DisableAllGuns();
                break;
            case BossFourState.PhaseOne:
                DisableAllGuns();
                guns[0].transform.position = new Vector3(guns[0].transform.position.x + 10, guns[0].transform.position.y, 0);
                guns.Add(Instantiate(gunPrefabs[0], new Vector3(guns[0].transform.position.x - 20, guns[0].transform.position.y, 0), new Quaternion()));
                guns[0].GetComponent<GunController>().TurnOn();
                guns[^1].GetComponent<GunController>().TurnOn();
                break;
            case BossFourState.PhaseTwo:
                //Do nothing
                break;
            case BossFourState.PhaseThree:
                guns[1].GetComponent<GunController>().TurnOn();
                break;
            case BossFourState.PhaseFour:
                guns.RemoveAt(2);
                guns.Add(Instantiate(gunPrefabs[2], new Vector3(guns[0].transform.position.x - 70, guns[0].transform.position.y - 30, 0), Quaternion.Euler(0,  0, 90)));
                guns[^1].GetComponent<GunController>().TurnOn();
                break;
            case BossFourState.PhaseFive:
                //DO nothing
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
