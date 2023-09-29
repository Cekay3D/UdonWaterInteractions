
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Cekay.WaterInteractions
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class WaterInteractionsFollower : UdonSharpBehaviour
    {
        private VRCPlayerApi _localPlayer;

        [SerializeField] WaterInteractionsPlayer WaterIntPlayer;

        [SerializeField] ParticleSystem SplashParticles;
        [SerializeField] AudioSource SplashAudio;

        private string FollowerType;

        void Start()
        {

        }

        public void SetFollowerType(string DesiredFollwerType)
        {
            FollowerType = DesiredFollwerType;
        }

        private void OnTriggerEnter(Collider other)
        {
            SplashType(other, "enter");
        }

        private void OnTriggerExit(Collider other)
        {
            SplashType(other, "exit");
        }

        private void SplashType(Collider other, string type)
        {
            if (other.gameObject.layer == WaterIntPlayer.InteractableLayer)
            {
                if (FollowerType == "Origin")
                {
                    if (type == "enter" && _localPlayer.GetVelocity().magnitude > WaterIntPlayer.BigSplashVelocity)
                    {
                        SplashBig();
                    }
                    else if (type == "exit")
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
