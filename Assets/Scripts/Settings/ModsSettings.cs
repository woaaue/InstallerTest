using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "ModsSettings", menuName = "Installer_Test/ModsSettings", order = 1)]
public sealed class ModsSettings : ScriptableObject
{
    [field: SerializeField] public List<ModSettings> ModsSetting { get; private set; }

    public ModSettings GetModSettings(string id) => ModsSetting.First(modSettings => modSettings.Id == id);

#if UNITY_EDITOR
    [Button("Generate id")]
    public void GenerateId()
    {
        var hasChanges = false;

        ModsSetting.ForEach(modSettings =>
        {
            if (string.IsNullOrEmpty(modSettings.Id))
            {
                modSettings.SetId();
                hasChanges = true;
            }
        });
    }
#endif
}
