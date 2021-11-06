using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TowerDefense
{
    public class Upgrade : MonoBehaviour
    {
        //public TowerDefense.UI_Manager uiManager;
        public int cost;
        public int maxLevel = 3;
        private int currentLevel = 0;
        private Button button;
        public TMPro.TextMeshProUGUI text;
        public TMPro.TextMeshProUGUI textDescription;


        // Start is called before the first frame update
        void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(UseUpgrade);
            text.text = $"{cost}";
        }

        // Update is called once per frame
        void Update()
        {
            if (TowerDefense.GameManager.diamondCount >= cost)
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }

            if (!(currentLevel < maxLevel))
            {
                button.interactable = false;
                textDescription.text = "MAX";
            }
        }

        public virtual void UseUpgrade()
        {
            currentLevel++;
            TowerDefense.GameManager.diamondCount -= cost;
        }

    }
}