using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace TowerDefense
{
    public class TowerFollowEnemy : MonoBehaviour
    {
        public Tower tower;

        void Start()
        {
            tower = GetComponentInParent<Tower>();
        }

        // Update is called once per frame
        void Update()
        {
            if (tower.following == false) return;
                
            if (tower.following == true)
            {
                if (!tower.enemyTarget)
                {
                    tower.following = false;
                    return;
                }
                gameObject.transform.LookAt(tower.enemiesInRange[0].transform.position);
            }    
        }
    }
}

