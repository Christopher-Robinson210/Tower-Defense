using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class UpgradeBomb : TowerDefense.Upgrade
    {
        // Start is called before the first frame update
        public TowerDefense.EnemyManager enemyManager;
        public AudioSource audioSource;
        public AudioClip explosionSound;
        public float explosionRate = 0.25f;

        public override void UseUpgrade()
        {
            
            base.UseUpgrade();
            //Destroy every enemy on screen.
            print("BOOM! Everything is dead!");
            
            StartCoroutine(Boom());
            
        }

        IEnumerator Boom()
        {
            audioSource.PlayOneShot(explosionSound);
            Time.timeScale = 0;
            int children = enemyManager.transform.childCount;
            for (int i = 0; i < children; i++)
            {
                
                try
                {
                    enemyManager.transform.GetChild(0).GetComponent<TowerDefense.Enemy>().Explode();
                }
                catch
                {
                    Debug.LogWarning($"Child ({i}) Does Not Exist");
                }
                yield return new WaitForSecondsRealtime(.01f);
            }
            Time.timeScale = 1;
        }
    }
}