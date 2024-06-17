using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class KeyManager : MonoBehaviour
    {
        [SerializeField] private List<Key> _keys;
        [SerializeField] private Portal _portal;
        private int _collectedKeys;

        private void Awake()
        {
            foreach (var key in _keys)
            {
                key.OnPicked += TakeKey;
            }
        }

        private void TakeKey()
        {
            _collectedKeys += 1;
            if (_collectedKeys == _keys.Count)
            {
                _portal.gameObject.SetActive(true);
            }
        }
    }
}