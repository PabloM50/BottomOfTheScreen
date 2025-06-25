using UnityEngine;

public class Speed : IUpgradable
{
    [Header("Max Level - 9")]
    [SerializeField] private PathFinder pathFinder;
    public override void OnStart() {
        base.OnStart();
        pathFinder.ChangeSpeed(Upgrades[_level].Value);
    }
    public override void Upgrade() {
        base.Upgrade();
        
        
        pathFinder.ChangeSpeed(Upgrades[_level].Value);
        
    }
}
