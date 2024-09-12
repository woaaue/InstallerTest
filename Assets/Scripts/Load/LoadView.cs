using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using JetBrains.Annotations;

public sealed class LoadView : MonoBehaviour
{
    [SerializeField] private Image _slider;
    [SerializeField] private LoadSystem _system;
    [SerializeField] private GameObject _openButton;
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private RectTransform _reloadImage;

    [UsedImplicitly]
    public void RefreshAnim()
    {
        _reloadImage.DORotate(new Vector3(0, 0, -360), 0.5f, RotateMode.FastBeyond360);
    }

    private void Start()
    {
        _system.ValueChanged += OnValueChanged;
        _system.LoadFinished += OnLoadFinished;
    }

    private void OnDisable()
    {
        _system.ValueChanged -= OnValueChanged;
        _system.LoadFinished -= OnLoadFinished;
    }

    private void OnValueChanged(int value)
    {
        _value.text = $"{value}%";
        _slider.fillAmount = value / 100f;
    }

    private void OnLoadFinished()
    {
        _openButton.SetActive(true);
    }
}
