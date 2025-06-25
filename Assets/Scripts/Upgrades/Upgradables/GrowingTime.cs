using UnityEngine;

public class GrowingTime : IUpgradable
{
    [Header("Max Level - 9")]
    [SerializeField] private TreeManager treeManager;
    public override void OnStart() {
        base.OnStart();
        treeManager.SetGrowingTime(Upgrades[_level].Value);
    }
    public override void Upgrade() {
        base.Upgrade();
        
        
        treeManager.SetGrowingTime(Upgrades[_level].Value);
        
    }
}

