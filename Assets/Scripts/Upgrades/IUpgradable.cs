using UnityEngine;
using System.Collections.Generic;
using System;





[System.Serializable]
public abstract class IUpgradable : MonoBehaviour, IDataPersistence
{

    //Name
    [SerializeField] protected  string _upgradeName;
    
    public string UpgradeName => _upgradeName;
    
    //Upgrade values
    [SerializeField] protected  int _level = 0;


    protected const int _maxLevel = 9;
    
    public int MaxLevel => _maxLevel; 
    [SerializeField] protected  List<Upgrade> Upgrades = new List<Upgrade>();



    //scripts
    [SerializeField] protected Currency currencyGold;
    [SerializeField] protected UIUpgrade uIUpgrade;


    public virtual void OnStart() {
        if(_level >= _maxLevel) {
            // do something
            uIUpgrade.Disable();
        }
        uIUpgrade.ChangeSliderValue(_level);
    }
    public virtual void Upgrade() {
        // just safety check
        if(_level >= _maxLevel) {
            return;
        }

        //Check if level and price are satifiable
        if(_level >= _maxLevel-1 && currencyGold.SubtractAmount(Upgrades[_level].Price)) {
            OnNotUpgraded("Max Level Reached");
            uIUpgrade.Disable();
            _level += 1;
            uIUpgrade.ChangeSliderValue(_level);
            
        }
        else if(currencyGold.SubtractAmount(Upgrades[_level].Price)) {
                _level += 1;
                uIUpgrade.ChangeSliderValue(_level);
        }
        else {
                OnNotUpgraded("Not Enough Money");
                return;
        }  
        
    }

    public void OnNotUpgraded(string message) {
        Debug.Log(message);
        // TODO - do something
    }

    public virtual void LoadData(GameData data) {
       
        UpgradeInfo upgradeInfo;
       
        
        
        if(data.upgrade.Upgrades.TryGetValue(_upgradeName, out upgradeInfo)) {
            _level = upgradeInfo.level;
        }
        else {
            Debug.Log(upgradeInfo);
            upgradeInfo = new UpgradeInfo { level = _level };
            
            data.upgrade.Upgrades[_upgradeName] = upgradeInfo;
        }
        
    }

    public virtual void SaveData(ref GameData data) {
        UpgradeInfo upgradeInfo = data.upgrade.Upgrades[_upgradeName];


        upgradeInfo.level = _level;

        data.upgrade.Upgrades[_upgradeName] = upgradeInfo;

    }
}



