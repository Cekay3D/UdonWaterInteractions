using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace Cekay.WaterInteractions
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class WaterInteractionsPlayer : UdonSharpBehaviour
    {
        [SerializeField] private WaterInteractionsFollower HeadFollower;
        [SerializeField] private WaterInteractionsFollower LeftHandFollower;
        [SerializeField] private WaterInteractionsFollower RightHandFollower;
        [SerializeField] private WaterInteractionsFollower OriginFollower;

        public int InteractableLayer = 22;
        public int BigSplashVelocity = 6;

        public AudioClip[] SmallSplashes;
        public AudioClip[] BigSplashes;
        public AudioClip[] ExitSplashes;
        public AudioClip[] Underwater;

        public VRCPlayerApi LocalPlayerApi;

        private void Start()
        {
            LocalPlayerApi = Networking.LocalPlayer;
        }

        private void Update()
        {
            HeadFollower.transform.SetPositionAndRotation(LocalPlayerApi.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position,
                                                          LocalPlayerApi.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).rotation);
            LeftHandFollower.transform.SetPositionAndRotation(LocalPlayerApi.GetTrackingData(VRCPlayerApi.TrackingDataType.LeftHand).position,
                                                              LocalPlayerApi.GetTrackingData(VRCPlayerApi.TrackingDataType.LeftHand).rotation);
            RightHandFollower.transform.SetPositionAndRotation(LocalPlayerApi.GetTrackingData(VRCPlayerApi.TrackingDataType.RightHand).position,
                                                               LocalPlayerApi.GetTrackingData(VRCPlayerApi.TrackingDataType.RightHand).rotation);
            OriginFollower.transform.SetPositionAndRotation(LocalPlayerApi.GetTrackingData(VRCPlayerApi.TrackingDataType.Origin).position,
                                                            LocalPlayerApi.GetTrackingData(VRCPlayerApi.TrackingDataType.Origin).rotation);
        }
    }
}