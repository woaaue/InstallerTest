using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.Localization.Settings;

public sealed class LocaleSelector : MonoBehaviour
{
    [SerializeField] private MenuController _menuController;

    private bool _isRoutineActive;

    [UsedImplicitly]
    public void ChangeLocale(int localeId)
    {
        if (_isRoutineActive)
            return;

        StartCoroutine(ChangeLocalesRoutine(localeId));
    }

    private IEnumerator ChangeLocalesRoutine(int localeId)
    {
        _isRoutineActive = true;

        yield return LocalizationSettings.InitializationOperation;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        ChangeModLocale(localeId);
        _isRoutineActive = false;

        yield break;
    }

    private void ChangeModLocale(int localeId) //cringe
    {
        switch (localeId) 
        {
            case 0:
                _menuController.SetupLocale(LanguageType.en);
                break;

            case 1:
                _menuController.SetupLocale(LanguageType.pt);
                break;

            case 2:
                _menuController.SetupLocale(LanguageType.ru);
                break;

            case 3:
                _menuController.SetupLocale(LanguageType.es);
                break;
        }
    }
}
