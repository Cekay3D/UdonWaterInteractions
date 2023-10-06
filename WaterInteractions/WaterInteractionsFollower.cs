using UdonSharp;
using UnityEngine;

namespace Cekay.WaterInteractions
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class WaterInteractionsFollower : UdonSharpBehaviour
    {
        [SerializeField] private WaterInteractionsPlayer WaterIntPlayer;

        [SerializeField] private ParticleSystem SplashParticles;
        [SerializeField] private AudioSource SplashAudio;
        [SerializeField] private GameObject UnderwaterAudio;
        public string FollowerType;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == WaterIntPlayer.InteractableLayer)
            {
                SplashType("Enter");
                if (FollowerType == "Head")
                {
                    UnderwaterAudio.SetActive(true);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == WaterIntPlayer.InteractableLayer)
            {
                SplashType("Exit");
                if (FollowerType == "Head")
                {
                    UnderwaterAudio.SetActive(false);
                }
            }
        }

        private void SplashType(string type)
        {
            if (FollowerType == "Origin")
            {
                if (type == "Enter" && WaterIntPlayer.LocalPlayerApi.GetVelocity().magnitude > WaterIntPlayer.BigSplashVelocity)
                {
                    SplashBig();
                }
                else if (type == "Exit")
                {
                    SplashExit();
                }
                else
                {
                    SplashSmall();
                }
            }
            else
            {
                SplashSmall();
            }

            SplashParticles.Play();
        }

        private void SplashSmall()
        {
            SplashAudio.PlayOneShot(WaterIntPlayer.SmallSplashes[Random.Range(0, WaterIntPlayer.SmallSplashes.Length)]);
        }

        private void SplashBig()
        {
            SplashAudio.PlayOneShot(WaterIntPlayer.BigSplashes[Random.Range(0, WaterIntPlayer.BigSplashes.Length)]);
        }

        private void SplashExit()
        {
            SplashAudio.PlayOneShot(WaterIntPlayer.ExitSplashes[Random.Range(0, WaterIntPlayer.ExitSplashes.Length)]);
        }
    }
}