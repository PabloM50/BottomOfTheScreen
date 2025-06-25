using UnityEngine;

public class Gold : Currency, IDataPersistence
{
    


    private void SetAmount(int newAmount) {
        _amount = newAmount;
        SendDataToUI();
    }


    public void LoadData(GameData data) {
        //makes coins equal to saved amount
        SetAmount(data.coins);
    }


    public void SaveData(ref GameData data) {
        data.coins = GetAmount();
    }
}
