using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Gun : MonoBehaviour
    {
        public GameObject enemyManager;
        private ParticleSystem part;
        private AudioSource audioSource;
        public List<ParticleCollisionEvent> collisionEvents;
        public float startSpeed = 20f;
        public float shotDelay = 1f;

        private void Awake()
        {
            part = GetComponent<ParticleSystem>();
            audioSource = GetComponent<AudioSource>();
            collisionEvents = new List<ParticleCollisionEvent>();
            part.Stop();
            part.Clear();
            var main = part.main;
            main.startSpeed = startSpeed;
            main.duration = shotDelay;
            main.startLifetime = main.duration;
            part.Play();
        }
        

        // Update is called once per frame
        void Update()
        {

            AimAtTarget(FindTarget());
        }

  
        void OnParticleCollision(GameObject other)
        {
            int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            int i = 0;
            print($"Collision Events: {numCollisionEvents}");
            while (i < numCollisionEvents)
            {
                if (rb)
                {
                    print("HIT");
                    //Vector3 pos = collisionEvents[i].intersection;
                    //Vector3 force = collisionEvents[i].velocity * 2;
                    //rb.AddForce(force);
                    audioSource.PlayOneShot(other.GetComponent<Enemy>().GetClip());
                    Destroy(other);
                    part.Clear();
                }
                i++;
            }

        }

        GameObject FindTarget()
        {
            //FIND THE CHILD ENEMY OF ENEMYMANAGER THAT IS CLOSEST TO THE GUN OBJECT
            
            int index = 0;

                //Loop through the children from 0 to 1 less than the child count
                for (int i = 0; i < enemyManager.transform.childCount - 1; i++)
                {
                    //set to first index in the loop
                    index = i;
                    for (int c = 1; c < enemyManager.transform.childCount; c++)
                    {
                        //if the child at index c is closer than child at index i, set indext to child c
                        if ((enemyManager.transform.GetChild(c).transform.position - transform.position).magnitude < (enemyManager.transform.GetChild(i).transform.position - transform.position).magnitude)
                        {
                            index = c;
                        }
                    }
                }

            //RETURN THE CHILD OBJECT AT "INDEX"
            return enemyManager.transform.GetChild(index).gameObject;
        }

        void AimAtTarget(GameObject enemy)
        {
            //print($"Target: {enemy.name}");  //Debug purposes

            //Set the X axis to correct angle
            if (enemy)
            {
                transform.right = enemy.transform.position - transform.position;
            }
        }

    }
}
