using System;
using Guns;

namespace Bosses.BossTwo
{
    public class BossTwoController : BossController
    {
        internal enum BossTwoState
        {
            Passive,
            PhaseOne
        }

        private BossTwoState _bossState;
        private bool _hasStarted;
        
        protected override void AdditionalStartRoutineLogic()
        {
            ChangeBossState(BossTwoState.Passive);
        }
        
        public override void CommenceBattleStart()
        {
            if (!_hasStarted)
            {
                _hasStarted = true;
                ChangeBossState(BossTwoState.PhaseOne);
            }
        }

        public override void BecomeInactive()
        {
            ChangeBossState(BossTwoState.Passive);
            DisableAllGuns();
        }

        internal void ChangeBossState(BossTwoState newState)
        {
            _bossState = newState;

            if (newState == BossTwoState.Passive)
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
                case BossTwoState.Passive:
                    DisableAllGuns();
                    break;
                case BossTwoState.PhaseOne:
                    DisableAllGuns();
                    guns[0].GetComponent<GunController>().TurnOn();
                    guns[1].GetComponent<GunController>().TurnOn();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}