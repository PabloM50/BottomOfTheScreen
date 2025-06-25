using UnityEngine;

public class TreePrice : IUpgradable
{
    [Header("Max Level - 9")]
    [SerializeField] private TreeManager treeManager;
    public override void OnStart() {
        base.OnStart();
        treeManager.SetPrice((int) Upgrades[_level].Value);
    }
    public override void Upgrade() {
        base.Upgrade();
        
        
        treeManager.SetPrice((int) Upgrades[_level].Value);
        
    }
}
