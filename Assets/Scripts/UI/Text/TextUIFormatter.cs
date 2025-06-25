using UnityEngine.UI;
using UnityEngine;

public class TextUIFormatter : MonoBehaviour
{
    [SerializeField] private Text _text;


   
    public void SetText(string newText) {
        _text.text = newText;
    }
}
