using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Gun : MonoBehaviour
    {
        //public GameManager gameManager;
        public TowerDefense.EnemyManager enemyManager;
        public GameObject bullet;
        public Transform bulletSpawnLocation;
        public AudioSource gameManagerAudio;
        private Transform targetTransform;
        private bool isShooting = false;
        
        private float baseEmitOverTimeRate;
        public float bulletSpeed = 20f;
        private float shotDelay = 1f;
        private bool isAlive = true;


        private void Awake()
        {

            
            
        }

        private void Start()
        {
            shotDelay = TowerDefense.GameManager.rateOfFire;
            StartCoroutine(Shoot());
        }

        private void Update()
        {
            if (enemyManager.transform.childCount > 0 && Time.timeScale == 1)
            {
                isShooting = true;
                
            }
            else
            {
                isShooting = false;
            }
        }
      
        int FindTargetIndex()
        {
            //FIND THE CHILD ENEMY OF ENEMYMANAGER THAT IS CLOSEST TO THE GUN OBJECT

            int childIndex = -1;
            int childCount = enemyManager.transform.childCount;
            float tempMagnitude = float.PositiveInfinity;


            //Loop through the children from 0 to 1 less than the child count
            for (int i = 0; i < childCount; i++)
            {
                
                if ((enemyManager.transform.GetChild(i).transform.position - transform.position).magnitude < tempMagnitude)
                {
                    tempMagnitude = (enemyManager.transform.GetChild(i).transform.position - transform.position).magnitude;
                    childIndex = i;
                }
                
            }

            if (enemyManager.transform.GetChild(childIndex))
            {
                return childIndex;
            }
            else
            {
                return FindTargetIndex();
            }
                
        }

        void SetTargetTransform(int index)
        {
            targetTransform = enemyManager.transform.GetChild(index);
        }

        void AimAtTarget()
        {
            SetTargetTransform(FindTargetIndex());
            

            //Look at GameObject using right
            transform.right = targetTransform.position - transform.position;
        }

        void CreateBullet()
        {
            
            GameObject newBullet = Instantiate(bullet, new Vector3(bulletSpawnLocation.position.x, bulletSpawnLocation.position.y, 0f), transform.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(newBullet.transform.right * bulletSpeed, ForceMode2D.Force);
        }

        public void StopShooting()
        {
            isShooting = false;
        }

        public void StartShooting()
        {
            isShooting = true;
        }
        IEnumerator Shoot()
        {
            
            while (isAlive)
            {
                if (isShooting)
                {
                    AimAtTarget();
                    CreateBullet();
                }
                yield return new WaitForSeconds(shotDelay);
            }
        }

       
        public void PlaySound(AudioClip clip)
        {
            gameManagerAudio.PlayOneShot(clip);
        }
        
    }
}
