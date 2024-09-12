using DG.Tweening;
using UnityEngine;
using JetBrains.Annotations;

public sealed class ScreenAnimator : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private RectTransform _panel;

    private Vector2 _endPosition;
    private Vector2 _startPosition;

    [UsedImplicitly]
    public void HideScreen()
    {
        _panel.DOAnchorPos(_startPosition, _duration).SetEase(Ease.InOutQuad)
            .OnComplete(DeactiveScreen);
    }

    private void Awake()
    {
        _startPosition = new Vector2(-_panel.rect.width, _panel.anchoredPosition.y);
        _endPosition = _panel.anchoredPosition;
    }

    private void OnEnable()
    {
        _panel.anchoredPosition = _startPosition;

        ShowScreen();
    }

    private void ShowScreen()
    {
        _panel.DOAnchorPos(_endPosition, _duration).SetEase(Ease.InOutQuad);
    }

    private void DeactiveScreen()
    {
        gameObject.SetActive(false);
    }
}
