using UnityEngine;

namespace AIShooterDemo
{
    public class CameraBehaviour : MonoBehaviour
    {
        GameManager gameManager;

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
            Vector3 position = gameManager.Player.Position + gameManager.Settings.CameraPosition;
            transform.position = Vector3.Slerp(transform.position, position, Time.deltaTime * gameManager.Settings.CameraVelocity);
            transform.LookAt(gameManager.Player.Position);
        }
    }
}