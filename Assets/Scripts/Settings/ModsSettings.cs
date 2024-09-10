using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ModsSettings", menuName = "Installer_Test/ModsSettings", order = 1)]
public sealed class ModsSettings : ScriptableObject
{
    [field: SerializeField] public List<ModSettings> ModsSetting { get; private set; }
}
