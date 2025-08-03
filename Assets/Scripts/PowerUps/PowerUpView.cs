using UnityEngine;

namespace CosmicCuration.PowerUps
{
    public class PowerUpView : MonoBehaviour
    {
        private PowerUpController powerUpController;
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D boxCollider;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider = GetComponent<BoxCollider2D>();
        }

        public void SetController(PowerUpController controller) => powerUpController = controller;

        private void OnTriggerEnter2D(Collider2D collision) => powerUpController?.PowerUpTriggerEntered(collision.gameObject);

        public void SetActive(bool isActive)
        {
            spriteRenderer.enabled = isActive;
            boxCollider.enabled = isActive;
        }
    } 
}