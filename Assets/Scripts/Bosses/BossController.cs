using System.Collections.Generic;
using Guns;
using UnityEngine;

namespace Bosses
{
    public abstract class BossController : MonoBehaviour
    {
        public List<GameObject> gunPrefabs;
        protected List<GameObject> guns = new();
        protected BackgroundMusicController BackgroundMusicController;

        public void Awake()
        {
            BackgroundMusicController = GameObject.FindWithTag("MainCamera").GetComponent<BackgroundMusicController>();
        }
        
        public void Start()
        {
            foreach (GameObject gun in gunPrefabs)
            {
                guns.Add(Instantiate(gun, new Vector3(transform.position.x, transform.position.y, 0), new Quaternion()));
            }

            AdditionalStartRoutineLogic();
        }
        
        protected void DisableAllGuns()
        {
            foreach (GameObject gun in guns)
            {
                gun.GetComponent<GunController>().TurnOff();
            }
        }

        public abstract void CommenceBattleStart();
        public abstract void BecomeInactive();
        protected abstract void AdditionalStartRoutineLogic();
    }
}