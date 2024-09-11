using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEngine.UI;
using JetBrains.Annotations;
using System.Collections.Generic;

public sealed class Dropdown : MonoBehaviour
{
    [SerializeField] private Image _mainObject;
    [SerializeField] private List<Image> _otherObjects;
    [SerializeField] private RectTransform _background;

    private bool isOpen = false;

    [UsedImplicitly]
    public void DropdownClick()
    {
        isOpen = !isOpen;

        UpdateBackgroundSize();
    }

    [UsedImplicitly]
    public void ChangeMainObject(Image image)
    {
        if (_otherObjects.First(@object => @object == image))
        {
            Vector2 trasformContainer = _mainObject.gameObject.transform.localPosition;
            _mainObject.gameObject.transform.localPosition = image.gameObject.transform.localPosition;
            image.gameObject.transform.localPosition = trasformContainer;

            _otherObjects.Add(_mainObject);
            _mainObject = image;
            _mainObject.raycastTarget = false;
            _otherObjects.Remove(_mainObject);
        }
    }

    private void ChangeStateObject()
    {
        foreach (Image @object in _otherObjects)
        {
            @object.raycastTarget = isOpen;
            @object.gameObject.SetActive(isOpen);
        }
    }

    private void UpdateBackgroundSize()
    {
        if (isOpen)
        {
            ChangeStateObject();

            int count = _otherObjects.Count + 1;
            float newWidth = count * 100f;

            _background.DOSizeDelta(new Vector2(newWidth, _background.sizeDelta.y), 0.5f);
        }
        else
        {
            _background.DOSizeDelta(new Vector2(100f, _background.sizeDelta.y), 0.5f)
                .OnKill(ChangeStateObject);
        }
    }
}
