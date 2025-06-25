using UnityEngine;
using System;


public class OnChangeData
{
      
    public int _price { get; }    // Readonly
    public float _trainingTime { get; } // Readonly
    public float _growingTime { get; } // Readonly

   

    public OnChangeData(int price, float trainingTime, float growingTime)
    {
        _price = price;
        _trainingTime = trainingTime;
        _growingTime = growingTime;
    }
}


public class TreeManager : MonoBehaviour
{
    [SerializeField] private float _trainingTime;
    [SerializeField] private float _growingTime;

    [SerializeField] private int _price;


    void Start()
    {
        CallEventOnChange();
    }

#region On Change Events
    public static event Action<OnChangeData> OnChange;

    public void CallEventOnChange() {
         OnChange?.Invoke(new OnChangeData(_price, _trainingTime, _growingTime));
    }
#endregion

#region Get Methods
    public float GetTrainingTime() {
        return _trainingTime;
    }
    public float GetGrowingTime() {
        return _growingTime;
    }
    public int GetPrice() {
        return _price;
    }
#endregion

#region Set Methods
public bool SetTrainingTime(float newTrainingTime) {
    if(newTrainingTime <= 0) {
        Debug.LogError("Training time less than zero value.");
        return false;
    }
    _trainingTime = newTrainingTime;
    CallEventOnChange();
    return true;
}

public bool SetGrowingTime(float newGrowingTime) {
    if(newGrowingTime <= 0) {
        Debug.LogError("Growing time less than zero value.");
        return false;
    }
    _growingTime = newGrowingTime;
    CallEventOnChange();
    return true;
}

public bool SetPrice(int newPrice) {
    if(newPrice < 0) {
        Debug.LogError("Price less than zero value.");
        return false;
    }
    _price = newPrice;
    CallEventOnChange();
    return true;
}
#endregion

}
