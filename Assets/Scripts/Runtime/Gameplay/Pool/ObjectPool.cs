using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Gameplay.Pool
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _initialSize = 2;

        private readonly Stack<GameObject> _inactive = new();

        private void Awake()
        {
            for (var i = 0; i < _initialSize; i++)
            {
                _inactive.Push(Create());
            }
        }

        public GameObject Get()
        {
            var instance = _inactive.Count > 0 ? _inactive.Pop() : Create();
            instance.transform.SetParent(null);
            instance.SetActive(true);

            return instance;
        }

        public void Release(GameObject instance)
        {
            instance.SetActive(false);
            instance.transform.SetParent(transform);
            _inactive.Push(instance);
        }

        private GameObject Create()
        {
            var instance = Instantiate(_prefab, transform);
            instance.SetActive(false);

            return instance;
        }
    }
}
