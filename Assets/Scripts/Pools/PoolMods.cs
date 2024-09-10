using UnityEngine;

public sealed class PoolMods : MonoBehaviour
{
    [SerializeField] private Mod _prefab;
    [SerializeField] private Transform _parent;

    public PoolMono<Mod> Mods { get; private set; }

    private void Start()
    {
        Mods = new PoolMono<Mod>(_prefab, _parent, SettingsProvider.Get<ModsSettings>().ModsSetting.Count, true);
    }
}
