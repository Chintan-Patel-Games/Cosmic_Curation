using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerView : MonoBehaviour, IDamageable
    {
        [SerializeField] public SpriteRenderer playerView;
        [SerializeField] public Transform canonTransform;
        [SerializeField] public Transform turretTransform1;
        [SerializeField] public Transform turretTransform2;

        private PlayerController playerController;

        private void Awake()
        {
            playerView = GetComponent<SpriteRenderer>();
            SetActive(true);
        }

        public void SetController(PlayerController playerController) => this.playerController = playerController;

        private void Update() => playerController.HandlePlayerInput();

        public void TakeDamage(int damageToTake) => playerController.TakeDamage(damageToTake);

        public void SetActive(bool isActive) => playerView.enabled = isActive;
    } 
}