using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpeed : TowerDefense.Upgrade
{
    public float rofIncrease = .1f;
    // Start is called before the first frame update
    public override void UseUpgrade()
    {
        float rof = TowerDefense.GameManager.rateOfFire;
        base.UseUpgrade();
        //Destroy every enemy on screen.
        TowerDefense.GameManager.rateOfFire -= rofIncrease;
        print($"Fire Rate Increased by {rofIncrease * 100}%\nPrevious ROF: {rof} | New ROF: {TowerDefense.GameManager.rateOfFire}");
    }
}
