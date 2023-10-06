# UdonWaterInteractions

Make your VRChat world's water more immersive with sounds and particle systems that provide feedback for your hands, head, and body.

## Demo world

This was made originally for my [Waterfall Pool world](https://vrchat.com/home/launch?worldId=wrld_b2b5f60e-5162-490f-a7c5-a8fa46ea7dc5), you can see it in action there.

## Installation

Drag the .unitypackage from releases into your Unity project and import everything.

## Usage

- Drag the prefab from Cekay/WaterInteractions/Prefabs into your scene
- Create a new layer for your water interactions, and specify that in the prefab's menu
-- By default, the script looks for layer 22. You can change this in the WaterInteractionPlayer gameobject.
- Go to the gameobject you'd like to define as your interactable water, and add a new trigger collider
-- Set the collider's layer to the new water layer you just created, and resize it to cover the water's surface
- Hit play and splash around!

## Third party assets used

- [16 splashes.wav - soundslikewillem, Freesound.org](https://freesound.org/people/soundslikewillem/sounds/343748/)
- [Foley_Natural_Water_Jump_Mono.wav - Nox_Sound, Freesound.org](https://freesound.org/people/Nox_Sound/sounds/585744/)
- [Ambiance_Underwater_Stereo.wav - psiboy123, Freesound.org](https://freesound.org/people/psiboy123/sounds/448460/)
