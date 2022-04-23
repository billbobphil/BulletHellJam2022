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
            ChangeBossState(BossThreeState.Passive);
        }
        
        public override void CommenceBattleStart()
        {
            if (!_hasStarted)
            {
                _hasStarted = true;
                ChangeBossState(BossThreeState.PhaseOne);
            }
        }

        public override void BecomeInactive()
        {
            ChangeBossState(BossThreeState.Passive);
            DisableAllGuns();
        }

        internal void ChangeBossState(BossThreeState newState)
        {
            _bossState = newState;
            
            if (newState == BossThreeState.Passive)
            {
                BackgroundMusicController.SwitchToPassiveTrack();
            }
            else if (_bossState != BossThreeState.Passive)
            {
                BackgroundMusicController.SwitchToActionTrack();
            }

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
                    // DisableAllGuns();
                    // Transform gunOneStartPosition = guns[1].transform;
                    // guns[1].transform.SetPositionAndRotation(new(13, gunOneStartPosition.position.y, 0), new Quaternion());
                    // guns.Add(Instantiate(gunPrefabs[1], new Vector3(-13, transform.position.y, 0), new Quaternion()));
                    // guns[^1].GetComponent<OscillationGunController>().maximumAngle *= -1;
                    // guns[1].GetComponent<GunController>().TurnOn();
                    // guns[^1].GetComponent<GunController>().TurnOn();
                    break;
                case BossThreeState.PhaseThree:
                    DisableAllGuns();                    
                    
                    Transform gunOneStartPosition = guns[1].transform;
                    guns[1].transform.SetPositionAndRotation(new(13, gunOneStartPosition.position.y, 0), new Quaternion());
                    guns.Add(Instantiate(gunPrefabs[1], new Vector3(-13, transform.position.y, 0), new Quaternion()));
                    guns[^1].GetComponent<OscillationGunController>().maximumAngle *= -1;
                    guns[1].GetComponent<GunController>().TurnOn();
                    guns[^1].GetComponent<GunController>().TurnOn();
                    
                    Transform gunTwoStartPosition = guns[2].transform;
                    guns[2].transform.SetPositionAndRotation(new(2, gunTwoStartPosition.position.y, 0), new Quaternion());
                    guns.Add(Instantiate(gunPrefabs[2], new Vector3(-2, gunTwoStartPosition.position.y,  0), new Quaternion()));
                    guns[2].GetComponent<GunController>().bulletSpeed = new Vector3(0, -0.25f, 0);
                    guns[^1].GetComponent<GunController>().bulletSpeed = new Vector3(0, -0.25f, 0);
                    guns[2].GetComponent<GunController>().TurnOn();
                    guns[^1].GetComponent<GunController>().TurnOn();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
}
