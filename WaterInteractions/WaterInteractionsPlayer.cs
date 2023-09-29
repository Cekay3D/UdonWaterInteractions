
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Cekay.WaterInteractions
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class WaterInteractionsPlayer : UdonSharpBehaviour
    {
        //[SerializeField] GameObject LeftHandFollower;
        //[SerializeField] GameObject RightHandFollower;
        //[SerializeField] GameObject HeadFollower;
        //[SerializeField] GameObject OriginFollower;
        
        [SerializeField] WaterInteractionsFollower LeftHandFollower;
        [SerializeField] WaterInteractionsFollower RightHandFollower;
        [SerializeField] WaterInteractionsFollower HeadFollower;
        [SerializeField] WaterInteractionsFollower OriginFollower;

        public int InteractableLayer = 22;
        public int BigSplashVelocity = 6;

        public AudioClip[] SmallSplashes;
        public AudioClip[] BigSplashes;
        public AudioClip[] ExitSplashes;

        private VRCPlayerApi _localPlayer;

        void Start()
        {
            _localPlayer = Networking.LocalPlayer;
        }

        private void Update()
        {
            LeftHandFollower.transform.SetPositionAndRotation(_localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.LeftHand).position,
                                                              _localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.LeftHand).rotation);
            RightHandFollower.transform.SetPositionAndRotation(_localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.RightHand).position,
                                                               _localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.RightHand).rotation);
            HeadFollower.transform.SetPositionAndRotation(_localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position,
                                                          _localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).rotation);
            OriginFollower.transform.SetPositionAndRotation(_localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Origin).position,
                                                            _localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Origin).rotation);
        }
    }
}
