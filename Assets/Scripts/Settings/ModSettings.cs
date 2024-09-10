using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ModSettings", menuName = "Installer_Test/ModSettings", order = 1)]
public sealed class ModSettings : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public List<LanguageSettings> Languages { get; private set; }

    public LanguageSettings GetLanguageSettings(LanguageType languageType) => Languages.First(setting => setting.Type == languageType);
}

[Serializable]
public class LanguageSettings
{
    public LanguageType Type;
    public string Name;
    public string Description;
}
