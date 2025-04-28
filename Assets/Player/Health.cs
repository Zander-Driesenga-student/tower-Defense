using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public class Health : MonoBehaviour
    {
        public int currentHealth = 10;
        public bool dieOnZeroHealth = true;
        public UnityEvent OnZeroHealth = new UnityEvent();
        public UnityEvent OnTakeDamge = new UnityEvent();

        private void Awake()
        {
            
        }
        public void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            UIValues.OnValueChange.Invoke(gameObject.name + "Health", currentHealth);
            OnTakeDamge.Invoke();
            if (currentHealth <= 0 && gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
            else
            {
                OnZeroHelth();
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

        public void OnZeroHelth()
        {
            if (dieOnZeroHealth == true)
            {
                OnZeroHealth.Invoke();
            }
        }


    }
}
