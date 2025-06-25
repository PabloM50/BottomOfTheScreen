using UnityEngine;
using UnityEngine.UI;

public class UIUpgrade : MonoBehaviour
{
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Slider _upgradeSlider;



    //scripts 
    [SerializeField] private UpgradeManager upgradeManager;

    public void Disable() {
        _upgradeButton.interactable = false;
    }  

    public void BuyButton(string UpgradeName) {
        upgradeManager.UpgradeItem(UpgradeName);
    }

    public void ChangeSliderValue(int level) {
         _upgradeSlider.value = level;
    }
}
