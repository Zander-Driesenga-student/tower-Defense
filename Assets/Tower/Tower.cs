using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [RequireComponent(typeof(Animator))]
    public class Tower : MonoBehaviour
    {
        public List<GameObject> enemiesInRange = new List<GameObject>();
        public Tower_SO towerType;
        private bool firing = false;
        GameObject enemyTarget;
        Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void DamageTarget()
        {
            if (!enemyTarget) return;
            Health.TryDamage(enemyTarget, towerType.damage);
        }

        private void RemoveDestroyedEnemies()
        {
            int i = 0;
            while (i < enemiesInRange.Count)
            {
                if (enemiesInRange[i]) i++;
                else enemiesInRange.RemoveAt(i);
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
                    enemyTarget = enemiesInRange[0];
                    animator.SetTrigger("Fire");
                }
                
                if (!enemiesInRange[0]) enemiesInRange.RemoveAt(0);
                else Health.TryDamage(enemiesInRange[0], towerType.damage);
                print("firing");
                yield return new WaitForSeconds(towerType.fireRate);
            }

            firing = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy")) enemiesInRange.Add(other.gameObject);

            if (!firing) StartCoroutine(DamageEnemyTarget());
        }

        private void OnTriggerExit(Collider other)
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}

