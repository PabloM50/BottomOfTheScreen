using UnityEngine;

public abstract class Currency : MonoBehaviour
{
    
    // amount of currency
    [SerializeField] protected int _amount;

    // name of currency and make it accesible, but not editable
    [SerializeField] private string _name;
    public string Name => _name;

    // class of TextUIFormatter, 
    [SerializeField] private TextUIFormatter textUIFormatter;

    void Start()
    {
        SendDataToUI();
    }

    
    public int GetAmount() {
        return _amount;
    }

    
    public void AddAmount(int value)  
    {
        _amount += value;
        SendDataToUI();
    }

    public bool SubtractAmount(int value)  
    {

        if((_amount - value) < 0) {
            return false;
        }

        _amount -= value;
        SendDataToUI();
        return true;
    }


    public void SendDataToUI() {
        string amountString = _amount.ToString();
        textUIFormatter.SetText(amountString);
    }
}
