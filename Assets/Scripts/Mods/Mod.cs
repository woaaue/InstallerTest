using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class Mod : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;

    public void Setup(Sprite icon, string name)
    {
        _name.text = name;
        _image.sprite = icon;
    }
}
