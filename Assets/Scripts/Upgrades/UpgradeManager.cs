using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private List<IUpgradable> upgrades = new List<IUpgradable>();


    void Start()
    {

        foreach (IUpgradable upgrade in upgrades)
        {   
            upgrade.OnStart();
        }
    }
    public void UpgradeItem(string UpgradeThis) {

        IUpgradable iUpgradable = upgrades.Find(upg => upg.UpgradeName == UpgradeThis);
        if (iUpgradable == null) {
            Debug.Log("Upgrade not found!");
            return;
        }

        iUpgradable.Upgrade();
        
    }
}
