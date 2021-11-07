using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Player : MonoBehaviour
    {
        public int health = 100;
        public static int playerHealth;
        // Start is called before the first frame update
        void Start()
        {
            playerHealth = health;
        }

        
        void TakeDamage(int damage)
        {
            playerHealth -= damage;
        }

        // Update is called once per frame
        void Update()
        {
            CheckHealth();
        }

        void CheckHealth()
        {
            if (playerHealth <= 0)
            {
                //Died

            }
        }
    }
}