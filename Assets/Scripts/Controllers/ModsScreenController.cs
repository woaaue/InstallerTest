using UnityEngine;

public sealed class ModsScreenController : MonoBehaviour
{
    [SerializeField] private DescriptionScreenController _descriptionScreenController;
    [SerializeField] private GameObject _screen;
    [SerializeField] private PoolMods _poolMods;

    public void InitScreen(LanguageType currentLocale)
    {
        _screen.gameObject.SetActive(true);
        FillMods(currentLocale);
    }

    private void FillMods(LanguageType currentLocale)
    {
        var settings = SettingsProvider.Get<ModsSettings>().ModsSetting;
        var counter = 0;

        _poolMods.Mods.Pool.ForEach(mod =>
        {
            mod.Setup(settings[counter].Id, currentLocale, _descriptionScreenController);
            counter++;
        });
    }
}
