using System;
using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public sealed class PoolMono<T> where T : MonoBehaviour
{
    public List<T> Pool { get; private set; }

    private T _prefab;
    private Transform _transform;
    private bool _isActiveByDefault;

    public PoolMono(T prefab, Transform position, int poolSize, bool isActiveByDefault)
    {
        _prefab = prefab;
        _transform = position;
        _isActiveByDefault = isActiveByDefault;

        CreatePool(poolSize);
    }

    private void CreatePool(int count)
    {
        Pool = new List<T>();

        for(int i = 0; i < count; i++)
        {
            CreateElement();
        }
    }

    private T CreateElement()
    {
        var element = Object.Instantiate(_prefab, _transform);
        element.gameObject.SetActive(_isActiveByDefault);
        Pool.Add(element);

        return element;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var poolElement in Pool)
        {
            if (!poolElement.gameObject.activeInHierarchy)
            {
                element = poolElement;
                element.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
            return element;

        throw new Exception($"The pool of type: {typeof(T)} is full");
    }
}
