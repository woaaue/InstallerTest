using UnityEngine;
using JetBrains.Annotations;

public sealed class MenuController : MonoBehaviour
{
    [SerializeField] private ModsScreenController _modsScreen;

    private LanguageType _currentLocale;

    [UsedImplicitly]
    public void ShowMods()
    {
        _modsScreen.InitScreen(_currentLocale);
    }

    public void SetupLocale(LanguageType locale)
    {
        _currentLocale = locale;
    }
}
