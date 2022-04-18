using System;
using Guns;

namespace Bosses.BossOne
{
    public class BossOneController : BossController
    {
        internal enum BossOneState
        {
            Passive,
            ExplosionGun,
            NextGunState
        }

        private BossOneState _bossOneState = BossOneState.Passive;
        private bool _hasStarted;

        protected override void AdditionalStartRoutineLogic()
        {
            ChangeBossState(BossOneState.Passive);
        }
        
        public override void CommenceBattleStart()
        {
            if (!_hasStarted)
            {
                _hasStarted = true;
                ChangeBossState(BossOneState.ExplosionGun);
            }
        }

        public override void BecomeInactive()
        {
            ChangeBossState(BossOneState.Passive);
            DisableAllGuns();
        }
        
        private void Act()
        {
            switch (_bossOneState)
            {
                case BossOneState.Passive:
                    guns[0].GetComponent<GunController>().TurnOff();
                    break;
                case BossOneState.ExplosionGun:
                    DisableAllGuns();
                    guns[0].GetComponent<GunController>().TurnOn();
                    break;
                case BossOneState.NextGunState:
                    DisableAllGuns();
                    guns[1].GetComponent<GunController>().TurnOn();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        internal void ChangeBossState(BossOneState newOneState)
        {
            _bossOneState = newOneState;

            if (newOneState == BossOneState.Passive)
            {
                BackgroundMusicController.SwitchToPassiveTrack();
            }
            else
            {
                BackgroundMusicController.SwitchToActionTrack();
            }
        
            Act();
        }
        
        
    }
}