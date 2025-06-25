using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class XPManager : MonoBehaviour, IDataPersistence
{
    [Header("Experience")]
    [SerializeField] private AnimationCurve experienceCurve;

    [SerializeField] private int _currentLevel;
    public int Level => _currentLevel;


    [SerializeField] private int totalExperience;
    [SerializeField] private int nextLevelsExperience;


    [Header("Interface")]
    [SerializeField] private TextUIFormatter _levelTextUIFormatter;
    [SerializeField] private TextUIFormatter _xpTextUIFormatter;
    [SerializeField] private Slider _xpSlider;

   

    void Start()
    {
        UpdateLevel();
    }

    void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            AddExperience(5);
        }
    }

    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        while(totalExperience >= nextLevelsExperience)
        {
            _currentLevel++;
            totalExperience = totalExperience - nextLevelsExperience;
            UpdateLevel();



            // Start level up sequence... Possibly vfx?
        }
    }

    void UpdateLevel()
    {
        
        nextLevelsExperience = (int)experienceCurve.Evaluate(_currentLevel + 1);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        int start = totalExperience;
        int end = nextLevelsExperience; 

        _levelTextUIFormatter.SetText(_currentLevel.ToString());
        _xpTextUIFormatter.SetText(totalExperience.ToString());
        _xpSlider.value = ((float)start) / end;
    }


    public void LoadData(GameData data) {
        _currentLevel = data.levelInfo.level;
        totalExperience = data.levelInfo.totalXP;
    }

    public void SaveData(ref GameData data) {
        data.levelInfo.level = _currentLevel ;
        data.levelInfo.totalXP = totalExperience;
    }
}
