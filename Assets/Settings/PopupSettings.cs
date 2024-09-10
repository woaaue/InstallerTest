using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PopupSettings", menuName = "Installer_Test/PopupSettings", order = 1)]
public sealed class PopupSettings : ScriptableObject
{
    [field: SerializeField] private List<PopupBase> _popups;

    public Popup<T> GetPopup<T>() where T : PopupBaseSettings
    {
        try
        {
            return (Popup<T>)_popups.First(x => x is Popup<T>);
        }
        catch (Exception e) 
        {
            Debug.LogError($"There is no popup with these settings {typeof(T)}");
            throw;
        }
    }
}
