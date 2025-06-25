using UnityEngine;
using UnityEngine.UI;

public class CollectableCard : MonoBehaviour 
{   
    // Reference these via the Inspector in the prefab
    [SerializeField] private Text _text;
    [SerializeField] private Image _image;

    public Collectable collectable;

    public void Initialize(Collectable collectable)
    {
        _image.sprite = collectable.Sprite;

        Color tmp = _image.color;
        tmp.a = 0.5f;
        _image.color = tmp;

        _text.text = collectable.Name;

        this.collectable = collectable;
        if (collectable.IsCollected())
        {
            this.Unlock();
        }
    }

    public void Unlock() {
        Color tmp = _image.color;
        tmp.a = 1f;
        _image.color = tmp;
    }
}
