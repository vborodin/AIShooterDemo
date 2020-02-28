using UnityEngine;

namespace AIShooterDemo
{
    public class CameraBehaviour : MonoBehaviour
    {
        GameManager gameManager;
        ICharacter player = null;
        Settings settings;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            if (gameManager == null)
            {
                Debug.LogWarning("GameManager not found.");
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (player == null)
            {
                player = gameManager.Player;
            }
            if (settings == null)
            {
                settings = gameManager.Settings;
            }

            Vector3 position = player.Position + settings.CameraPosition;
            transform.position = Vector3.Slerp(transform.position, position, Time.deltaTime * settings.CameraVelocity);
            transform.LookAt(player.Position);
        }
    }
}