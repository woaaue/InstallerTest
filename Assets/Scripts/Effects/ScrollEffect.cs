using UnityEngine.UI;
using UnityEngine;

public sealed class ScrollEffect : MonoBehaviour
{
    [SerializeField] private float _scaleFactor;
    [SerializeField] private float _colorFactor;
    [SerializeField] private Transform _content;
    [SerializeField] private ScrollRect _scrollRect;

    private void Update()
    {
        foreach (Transform mod in _content)
        {
            float distanceToCenter = Mathf.Abs(_scrollRect.viewport.position.x - mod.position.x);
            float scale = Mathf.Lerp(1f, _scaleFactor, distanceToCenter / _scrollRect.viewport.rect.width);
            mod.localScale = new Vector3(scale, scale, 1f);
            float transparency = Mathf.Lerp(1f, _colorFactor, distanceToCenter / _scrollRect.viewport.rect.width);
            var image = mod.GetComponent<Image>();
            var color = image.color;
            color.a = transparency;
            image.color = color;  
        }
    }
}
