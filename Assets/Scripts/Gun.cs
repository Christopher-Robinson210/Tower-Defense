using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Gun : MonoBehaviour
    {
        private GameObject target;
        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.Find("Enemy");
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 targetFlat = new Vector3(target.transform.position.x, target.transform.position.y, 0);
            transform.LookAt(targetFlat);
        }
    }
}
