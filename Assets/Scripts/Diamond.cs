using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Diamond : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButton(0))
            {
                TowerDefense.GameManager.diamondCount++;
                Destroy(gameObject);
            }
        }

        private void OnMouseDown()
        {
            
        }
    }
}