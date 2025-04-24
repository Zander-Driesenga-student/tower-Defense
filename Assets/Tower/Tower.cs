using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(Animator))]
    public class Tower : MonoBehaviour
    {
        [SerializeField] public List<GameObject> enemiesInRange = new List<GameObject>();
        public Tower_SO towerType;
        public bool firing = false;
        public bool following = false;
        public GameObject enemyTarget;
        Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void DamageTarget()
        {
            if (!enemyTarget)
            {
                following = false;
                return;
            }
            following = true;
            Health.TryDamage(enemyTarget, towerType.damage);
            if (gameObject.CompareTag("Cannon"))
            {
                print("hit");
            }
            
        }

        private void RemoveDestroyedEnemies()
        {
            int i = 0;
            while (i < enemiesInRange.Count)
            {
                if (enemiesInRange[i]) i++;
                else 
                {
                    enemiesInRange.RemoveAt(i);
                    following = false;
                }
            }
        }

        IEnumerator DamageEnemyTarget()
        {
            firing = true;
            

            while (enemiesInRange.Count > 0)
            {
                RemoveDestroyedEnemies();
                if (enemiesInRange.Count > 0)
                {
                    animator.SetTrigger("Fire");
                    enemyTarget = enemiesInRange[0];
                    DamageTarget();
                }
                yield return new WaitForSeconds(towerType.fireRate);
            }
            
            firing = false;
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                enemiesInRange.Add(other.gameObject);
                following = true;
            } 
            if (!firing) StartCoroutine(DamageEnemyTarget());
        }

        private void OnTriggerExit(Collider other)
        {
            enemiesInRange.Remove(other.gameObject);
            following = false;
        }
    }
}

