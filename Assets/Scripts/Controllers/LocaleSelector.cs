using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.Localization.Settings;

public sealed class LocaleSelector : MonoBehaviour
{
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
        _isRoutineActive = false;

        yield break;
    }

}
