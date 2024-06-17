using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class KeyManager : MonoBehaviour
    {
        [SerializeField] private KeysUI _keysUI;
        [SerializeField] private List<Key> _keys;
        [SerializeField] private Portal _portal;
        public int CollectedKeys { get; private set; }
        public int MaxKeys => _keys.Count;

        private void Awake()
        {
            foreach (var key in _keys)
            {
                key.OnPicked += TakeKey;
            }
        }

        private void TakeKey()
        {
            CollectedKeys += 1;
            _keysUI.UpdateText(this);
            if (CollectedKeys == _keys.Count)
            {
                _portal.gameObject.SetActive(true);
            }
        }
    }
}