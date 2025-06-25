using UnityEngine;

public class AddCoinsListener : MonoBehaviour
{
    [SerializeField] private Currency currency;


    #region Handling event
    private void OnEnable()
    {
        TrainingTree.OnTrainingEnd += AddCoins;
        
    }

    private void OnDisable()
    {
        TrainingTree.OnTrainingEnd -= AddCoins;
    }


    #endregion

    public void AddCoins(TrainingEndData trainingEndData) {
        currency.AddAmount(trainingEndData._price);
        
    }
}
