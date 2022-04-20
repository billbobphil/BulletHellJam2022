using System;
using System.Collections;
using System.Collections.Generic;
using Bosses;
using Guns;
using UnityEngine;

public class BossThreeController : BossController
{
        internal enum BossThreeState
        {
            Passive,
            PhaseOne,
            PhaseTwo,
            PhaseThree
        }

        private BossThreeState _bossState;
        private bool _hasStarted;
        
        protected override void AdditionalStartRoutineLogic()
        {
            ChangeBossState(BossThreeState.PhaseOne);
        }
        
        public override void CommenceBattleStart()
        {
            if (!_hasStarted)
            {
                _hasStarted = true;
                ChangeBossState(BossThreeState.PhaseTwo);
            }
        }

        public override void BecomeInactive()
        {
            ChangeBossState(BossThreeState.Passive);
            DisableAllGuns();
        }

        internal void ChangeBossState(BossThreeState newState)
        {

            if (newState == BossThreeState.Passive)
            {
                BackgroundMusicController.SwitchToPassiveTrack();
            }
            else if (_bossState != BossThreeState.Passive)
            {
                BackgroundMusicController.SwitchToActionTrack();
            }
            
            _bossState = newState;

            Act();
        }

        private void Act()
        {
            switch (_bossState)
            {
                case BossThreeState.Passive:
                    DisableAllGuns();
                    break;
                case BossThreeState.PhaseOne:
                    DisableAllGuns();
                    guns[0].GetComponent<GunController>().TurnOn();
                    break;
                case BossThreeState.PhaseTwo:
                    DisableAllGuns();
                    break;
                case BossThreeState.PhaseThree:
                    DisableAllGuns();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
}
