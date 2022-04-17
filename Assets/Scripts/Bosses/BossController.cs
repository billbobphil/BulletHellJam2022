using System.Collections.Generic;
using UnityEngine;

namespace Bosses
{
    public abstract class BossController : MonoBehaviour
    {
        public List<GameObject> gunPrefabs;
        protected List<GameObject> guns = new();
        
        public void Start()
        {
            foreach (GameObject gun in gunPrefabs)
            {
                guns.Add(Instantiate(gun, new Vector3(transform.position.x, transform.position.y, 0), new Quaternion()));
            }

            AdditionalStartRoutineLogic();
        }

        public abstract void CommenceBattleStart();
        public abstract void BecomeInactive();
        protected abstract void AdditionalStartRoutineLogic();
    }
}