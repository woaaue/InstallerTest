using System;
using UnityEngine;
using System.Collections;

public sealed class LoadSystem : MonoBehaviour
{
    public event Action LoadFinished;
    public event Action<int> ValueChanged;

    private Coroutine _coroutine;

    public void InitLoad()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = StartCoroutine(LoadRoutine());
    }

    private IEnumerator LoadRoutine()
    {
        var progressLoad = 0;

        while (progressLoad != 100)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            progressLoad++;
            ValueChanged?.Invoke(progressLoad);
        }

        LoadFinished?.Invoke();
        _coroutine = null;
        yield break;
    }
}
