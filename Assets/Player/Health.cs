using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Health : MonoBehaviour
    {
        public int currentHealth = 10;

        public void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        public static void TryDamage(GameObject target, int damageAmount)
        {
            Health targetHealth = target.GetComponent<Health>();

            if (targetHealth)
            {
                targetHealth.TakeDamage(damageAmount);
            }
        }
    }
}
