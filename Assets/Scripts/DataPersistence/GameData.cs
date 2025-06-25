using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class UpgradeInfo {
    public int level;
}


[System.Serializable]
public class ColectableInfo {
    public int ID; 
    public bool collected;
}




[System.Serializable]
public class GameData 
{
    public int coins;

    [System.Serializable]
    public class Upgrade {
        public Dictionary<string, UpgradeInfo> Upgrades = new Dictionary<string, UpgradeInfo>();
    }
    
    public Upgrade upgrade;




    [System.Serializable]
    public class LevelInfo {
        public int level;
        public int totalXP;
    }
    public LevelInfo levelInfo;




    [System.Serializable]
    public class Collectables_ {
        
        public Dictionary<int, ColectableInfo> Collectables = new Dictionary<int, ColectableInfo>();
    }
    public Collectables_ collectables_;




    public GameData() {
        
        this.coins = 0;
        this.upgrade = new Upgrade();
        this.levelInfo = new LevelInfo();
        this.collectables_ = new Collectables_();
    }
}
