using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Collider2D))]
    public class Portal : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerMovement>(out var player))
            {
                player.DisableInput();
            }
            StartCoroutine(SceneLoader.RestartScene());
        }
    }
}