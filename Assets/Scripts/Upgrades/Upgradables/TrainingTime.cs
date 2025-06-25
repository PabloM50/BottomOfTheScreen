using UnityEngine;

public class TrainingTime : IUpgradable
{
    [Header("Max Level - 9")]
    [SerializeField] private TreeManager treeManager;
    public override void OnStart() {
        base.OnStart();
        treeManager.SetTrainingTime(Upgrades[_level].Value);
    }
    public override void Upgrade() {
        base.Upgrade();
        
        
        treeManager.SetTrainingTime(Upgrades[_level].Value);
        
    }
}
