using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textField;

        public void UpdateText(HealthSystem system)
        {
            _textField.text = $"HP: {system.CurrentHealth} / {system.MaxHealth}";
        }
        
    }
}