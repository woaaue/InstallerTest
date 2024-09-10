using UnityEngine;

public sealed class PopupController : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private Transform _popupParent;

    private PopupBase _currentPopup;

    public void ShowPopup<T>(T settings) where T : PopupBaseSettings
    {
        var popup = SettingsProvider.Get<PopupSettings>().GetPopup<T>();
        var instance = Instantiate(popup, _popupParent, false);
        instance.Setup(settings);
        _currentPopup = instance;
        _background.SetActive(true);
    }
}
