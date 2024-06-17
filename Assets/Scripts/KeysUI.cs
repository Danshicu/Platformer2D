using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class KeysUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textField;

        public void UpdateText(KeyManager manager)
        {
            _textField.text = $"Keys: {manager.CollectedKeys} / {manager.MaxKeys}";
        }
    }
}