using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;




#region Events Data Classes

public class TrainingEndData
{
    public GameObject _treeColliderObject { get; }  // Readonly
    public int _price { get; }    // Readonly

    public TrainingEndData(GameObject treeColliderObject, int price)
    {
        _price = price;
        _treeColliderObject = treeColliderObject;
    }
}


public class TreeGrownData {
    public GameObject _treeColliderObject { get; }  // Readonly

    public TreeGrownData(GameObject treeColliderObject)
    {
       
        _treeColliderObject = treeColliderObject;
    }

}
#endregion

public class TrainingTree : MonoBehaviour
{
    [SerializeField] private Slider _trainingTimeSlider;

    #region Tree Stats That Change
    [SerializeField] private float _trainingTime;
    [SerializeField] private float _growingTime;
    [SerializeField] private int _price;

    [SerializeField] private CollectablesManager _collectableManager;

    #endregion
    

    
    [SerializeField] private GameObject _treeColliderObject;


    
   
    
   



    
#region Training
    public static event Action<TrainingEndData> OnTrainingEnd;
    public void Train() {
        StartCoroutine(TrainCouroutine(1f, _trainingTime));
    }
    
    private IEnumerator TrainCouroutine(float targetValue, float duration) {

        // on start
        _trainingTimeSlider.gameObject.SetActive(true);
        float elapsed = 0f;
        float startValue = _trainingTimeSlider.value;
        // --------------------------------------------
        
        while (elapsed < duration)
        {
            
            elapsed += Time.deltaTime;
            _trainingTimeSlider.value = Mathf.Lerp(startValue, targetValue, elapsed / duration);
            yield return null;
        }
        
        _trainingTimeSlider.value = targetValue; // Ensure it reaches the exact target value

        OnTraingEndFunc();
    }


    public void OnTraingEndFunc() {
        // todo finish
        
        _trainingTimeSlider.value = 0f;
        _trainingTimeSlider.gameObject.SetActive(false);

        // Invoke an event
        OnTrainingEnd?.Invoke(new TrainingEndData(_treeColliderObject, _price));

        _collectableManager.GetRandomCollectable();
        
        Grow();
    }

#endregion


#region Growing
public static event Action<TreeGrownData> OnTreeGrown;

    private void Grow() {
        Invoke("OnTreeGrownFunc", _growingTime);
    }


    void OnTreeGrownFunc() {
        OnTreeGrown?.Invoke(new TreeGrownData(_treeColliderObject));
    }

#endregion



#region OnChangeEvents

#region Handling event
    private void OnEnable()
    {
        TreeManager.OnChange += HandleChange;
        
    }

    private void OnDisable()
    {
        TreeManager.OnChange -= HandleChange;
    }


    #endregion


    private void HandleChange(OnChangeData onChangeData) {
        _price = onChangeData._price;
        _growingTime = onChangeData._growingTime;
        _trainingTime = onChangeData._trainingTime;
    }

#endregion




}
