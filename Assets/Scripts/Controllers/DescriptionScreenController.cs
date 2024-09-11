using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class DescriptionScreenController : MonoBehaviour
{
    [SerializeField] private Image _prefab;
    [SerializeField] private GameObject _screen;
    [SerializeField] private TextMeshProUGUI _mainTitle;
    [SerializeField] private Transform _scrollContainer;
    [SerializeField] private TextMeshProUGUI _description;

    private string _id;
    private LanguageType _language;

    public void InitScreen(string id, LanguageType currentLocale)
    {
        _id = id;
        _language = currentLocale;

        InitElements();
        _screen.SetActive(true);
    }

    private void InitElements()
    {
        var settings = SettingsProvider.Get<ModsSettings>().GetModSettings(_id);

        settings.Screenshots.ForEach(screenshot =>
        {
            var image = Instantiate(_prefab, _scrollContainer);         
            image.sprite = screenshot;
        });

        _mainTitle.text = settings.GetLanguageSettings(_language).Name;
        _description.text = settings.GetLanguageSettings(_language).Description;
    }
}
