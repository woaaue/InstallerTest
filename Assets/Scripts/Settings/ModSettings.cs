using System;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ModSettings", menuName = "Installer_Test/ModSettings", order = 1)]
public sealed class ModSettings : ScriptableObject
{
    [field: SerializeField] public string Id { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public List<Sprite> Screenshots { get; private set; }
    [field: SerializeField] public List<LanguageSettings> Languages { get; private set; }

    public LanguageSettings GetLanguageSettings(LanguageType languageType) => Languages.First(setting => setting.Type == languageType);

#if UNITY_EDITOR
    public void SetId()
    {
        Id = Guid.NewGuid().ToString();

        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
#endif
}

[Serializable]
public class LanguageSettings
{
    public LanguageType Type;
    public string Name;
    public string Description;
}
