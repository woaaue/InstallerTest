using TMPro;
using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;

public sealed class Mod : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;

    private string _id;
    private LanguageType _language;
    private DescriptionScreenController _descriptionScreenController;

    public void Setup(string id, LanguageType language, DescriptionScreenController descriptionScreenController)
    {
        _id = id;
        _language = language;
        _descriptionScreenController = descriptionScreenController;

        InitMod();
    }

    [UsedImplicitly]
    public void ClickMod()
    {
        _descriptionScreenController.InitScreen(_id, _language);
    }

    private void InitMod()
    {
        var settings = SettingsProvider.Get<ModsSettings>().GetModSettings(_id);

        _image.sprite = settings.Icon;
        _name.text = settings.GetLanguageSettings(_language).Name;
    }
}
