# IcoSphere a FPS game <img src="/Images/IcoLogo.png" alt="drawing" width="200"/>
## Final project for "CS50's Introduction to Game Development"
### By Thomas Feuerstein :bearded_person:

***This is a non-commercial, educational only project!***
*My purpose in this is mainly to improve my skills in scripting in C#*
*and to get more familiar with working with the UnityEngine*

### Description
This is a short ego-shooter adventure were the player has to fight<br>
his/her way to the endboss. On the way are continously spawning <br>
sphere shaped floating enemies which try to tackle the player<br> 
or shoot toward him/her. To stop enemies from spawning<br>
and clear the way to new sections, the player has to<br>
capture and defend circular zones on his way.<br>
Starting with a laser gun after the first half, the player gains <br> 
a fully automatic weapon on which a heating feature was implemented <br>
(If used to long it has to cool down before further usage).<br>
Furthermore the endboss scene features jump- and speed-pads<br>
which interact with the FPS controller and a laser mechanism<br>
which has to be activated with four capture zones to assist<br>
defeating the endboss.<br>
If the player looses all health the game is over.

Here you can find a [Demo Video](https://youtu.be/8VxhTAMiaAw) :film_strip:

### Documentation :computer:
***Justification why this project satisfies the given Specifications***
- It is a cohesive start-to-finish experience there is a start menu ("StartState"),<br>
a tutorial scene, a parcour with an endboss ("GameState")<br> 
and a final victory scene ("EndState"). 
- Furthermore the player can quit the game anytime by pressing the escape button<br>
to pop up the Pause menu ("MenuState").
- There is a definitive way of winning (defeating the final boss).
- There is a possibility of loosing the game by loosing all health or falling down ("GameOverState").
- Altohough free third-party assets and sounds were used (see more details below)<br>
the bulk of the game's logic is handwritten.

***Justification why this project satisfies the distinctiveness and complexity requirements***
- This project is related to the assignments 9 & 10 of the course (dreadhalls & portal)<br>
since it uses Unity for a 3D Game as well as a First-Person-Controller
- However, it features far more implemented features and functionalities which are:
    - A [weapon](/Assets/Scripts/Weapon/Gun.cs) which can be used to shoot at enemies (entities which have the [target script](/Assets/Scripts/Weapon/Target.cs) attached to them)
    - There are statistics which are displayed in the right-lower corner of the player-HUD
    that are updated continuosly during gameplay (see in the [player script](/Assets/Scripts/Player.cs) kills, score, accuracy variables)
    - A functional [elevator](/Assets/Scripts/World/ElevatorButton.cs) which uses Unity's animation feature
    - Three different enemies with differences in behaviour:
    [Icos](/Assets/Scripts/Entities/IcoCode.cs) | [MicroIcos](/Assets/Scripts/Entities/MicroIcoCode.cs) | [Spikys](/Assets/Scripts/Entities/SpikyCode.cs)
    - 
- Additionally the level design is significantly more complex
    - There are obstacles, podests, stairs, platforms, straights, corners etc.
    - There are [capture Zones](/Assets/Scripts/World/CaptureZoneCode.cs) with a sphere-collider which can only be 
    activated when the player is overlapping with the collider. When the player leaves the zone to early the progress is reset.
    - The level is split into sections in which enemies are randomly and infinitely spawning from [spawners](/Assets/Scripts/Entities/IcoSpawner.cs).
    - The player is only able to move on when a section is cleared i.e. if its zone was captured whereby the spawners are deactivated.

***Documentation what I did and justification of any controversial design choices***
- Everything besides the detailed listing of assets and sounds below was done by myself within Unity<br> 
with the help of ProBuilder.
- All scripts are handwritten by my own within Visual Studio Code.
- The level design is completely self-made except for the textureing.
- Some game mechanics like shooting, progress bars and enemy behaviour are added<br> 
with the help from [Brackeys](https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA) YouTube tutorials.
- The overall game idea was strongly influenced by the similar game series [Serious Sam](https://en.wikipedia.org/wiki/Serious_Sam)
    - However, capture zones are not a crucial part of this game
    - The game design is quite distinct from The Serious Sam series which is setted in e.g. egypt with mostly grounded entities
    - In IcoSphere the design is focused on a futuristic environment and glass-like, solely floating enemies 


### References & Acknowledgements

_All third-party materials are highly appreciated, thanks alot_

Thanks to [Brackeys](https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA) for usefull tutorials
on shooting, progress bars & weapon switching.

Free Assets from Unity AssetStore used:
- Textures
    - Texture Glass Transparent Window by GlowFox Games
    - Yughues Free Metal Materials by Nobiax / Yughues
- Weapons
    - Sci Fi Gun by MASH Virtual
    - Sci Fi Gun Light by Factory Of Models
- Background
    - SkyBox Volume 2 by Hedgehog Team
- Beams for capture zones
    - VolumetricLines by Johannes Unterguggenberger

Gamemusic:
yellow by cyba (c) 
copyright 2019 Licensed under 
a Creative Commons Attribution Noncommercial (3.0) license.
http://dig.ccmixter.org/files/cyba/60166 
& new circle by cyba (c) 
copyright 2019 Licensed under 
a Creative Commons Attribution Noncommercial  (3.0) license. 
http://dig.ccmixter.org/files/cyba/60087

Soundeffects:
Sound Effects from https://freesound.org
Many thanks to: 
tim.kahn for clorina.wav | StonedB for Huge Laser.wav | 
soundmonster0 for game-over.wav | problematist for space-laser-shot.ogg |
ticebilla for shoot.wav | mattc90 for neurofunk-d-n-b-style-distorted-synth-bass-wob.wav |
cbj-student for breaking-glass-mix.wav | speedenza for whoosh-woow-pt26.wav |
navadaux for whipy-woosh-transition.wav | filmmakersmanual for bullet-flyby-3.wav |
dwareing for maroon.wav | prutsik for space-swoosh.mp3 | rhodesmas for win-02.wav |
mrickey13 for playerhurt1.wav & playerhurt2.wav | deathscyp for damage-1.wav |
javierzumer for charging-loop-2.wav | unfa for medium-far-explosion.wav |
matrixxx for powerup-07.wav |<br>
All remaining sounds are self-made with the programm [Bfxr](https://www.bfxr.net/)
