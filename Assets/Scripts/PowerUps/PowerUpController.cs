using UnityEngine;
using CosmicCuration.Player;
using System.Collections;

namespace CosmicCuration.PowerUps
{
    public class PowerUpController : IPowerUp
    {
        private PowerUpView powerUpView;
        private float activeDuration;
        private bool isActive;
        private Coroutine timerCoroutine;

        public PowerUpController(PowerUpData powerUpData)
        {
            powerUpView = Object.Instantiate(powerUpData.powerUpPrefab);
            powerUpView.SetController(this);
            activeDuration = powerUpData.activeDuration;
        }

        public void Configure(Vector2 spawnPosition)
        {
            isActive = false;
            powerUpView.transform.position = spawnPosition;
            powerUpView.SetActive(true);
        }

        public void StartTimer()
        {
            if (isActive)
            {
                // Cancel existing timer if any
                if (timerCoroutine != null)
                    powerUpView.StopCoroutine(timerCoroutine);

                timerCoroutine = powerUpView.StartCoroutine(TimerCoroutine());
            }
        }

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(activeDuration);
            Deactivate();
        }

        public void PowerUpTriggerEntered(GameObject collidedObject)
        {
            if (collidedObject.GetComponent<PlayerView>() != null)
                Activate();
        }

        public virtual void Activate()
        {
            isActive = true;
            powerUpView.SetActive(false);
            StartTimer();
        }

        public virtual void Deactivate()
        {
            isActive = false;
            GameService.Instance.GetPowerUpService().ReturnPowerUpToPool(this);
        }
    } 
}