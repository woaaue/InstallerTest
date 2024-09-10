using UnityEngine;
using JetBrains.Annotations;

public sealed class MenuController : MonoBehaviour
{
    [SerializeField] private ModsScreenController _modsScreen;

    [UsedImplicitly]
    public void ShowMods()
    {
        _modsScreen.InitScreen(LanguageType.En);
    }
}
