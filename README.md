# IcoSphere a FPS game <img src="/Images/IcoLogo.png" alt="drawing" width="200"/>
## Final project for "CS50's Introduction to Game Development"
### By Thomas Feuerstein :bearded_person:

***This is a non-commercial, educational only project!***
*My purpose in this is mainly to improve my skills in scripting in C#*
*and to get more familiar with working with the UnityEngine*

### Description
It is a short ego-shooter adventure were the player has to fight
his/her way to the endboss.
On the way are continously spawning sphere shaped floating
enemies which try to tackle the player or shoot spikes toward him/her.
To stop enemys from spawning and clear the way to new sections,
the player has to capture and defend circular zones on his way.
Starting with a laser gun after the first half the player gains a fully
automatic weapon on which a heating feature was implemented
(If used to long it has to cool down before further usage).
Furthermore the endboss scene features jump- and speed-pads
which interact with the FPS controller and a laser mechanism
which has to be activated with four capture zones to assist 
defeating the endboss.
If the player looses all health the game is over.

Here you can find a [Demo Video](https://youtu.be/8VxhTAMiaAw) :film_strip:

### Documentation :computer:
***Justification why this project satisfies the given Specifications***
- It is a cohesive start-to-finish experience there is a start menu ("StartState"), 
a tutorial scene, a parcour with an endboss ("GameState") 
and a final victory scene ("EndState"). 
- Furthermore the player can quit the game anytime 
by pressing the escape button to pop up the Pause menu ("MenuState").
- There is a definitive way of winning (defeating the final boss).
- There is a possibility of loosing the game by loosing all health or falling down ("GameOverState").
- Altohough free third-party assets and sounds were used (see more details below) 
the bulk of the game's logic is handwritten 


***Justification why this project satisfies the distinctiveness and complexity requirements***
- This project is related to the assignments 9 & 10 of the course (dreadhalls & portal)
since it uses unity for a 3D game as well as a First-Person-Controller
- However, it features far more implemented features and functionalities which are:
    - A Weapon which can be used to shoot at enemies (entities which have the [target script](/Assets/Scripts/Weapon/Target.cs) attached to them)
    - There are statistics which are displayed in the left-lower corner of the player-HUD
    that are updated continuosly during gameplay (see in the [player script](/Assets/Scripts/Player.cs) kills, score, accuracy variables)
    - A functional [elevator](/Assets/Scripts/World/ElevatorButton.cs) which uses Unity's Animation feature
    - Three different enemies with differences in behaviour:
    [Icos]() | [MicroIcos]() | [Spikys]()
    ---------|---------------|-----------

***Documentation what I did and justification of any controversial design choices***

Thanks to [Brackeys](https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA) for usefull tutorials
on shooting & weapon switching.

Free Assets from Unity AssetStore used:
- Texture Glass Transparent Window by GlowFox Games
- Yughues Free Metal Materials by Nobiax / Yughues
- Sci Fi Gun by MASH Virtual
- Sci Fi Gun Light by Factory Of Models
- SkyBox Volume 2 by Hedgehog Team)
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
matrixxx for powerup-07.wav |
All remaining sounds are self-made with the programm [Bfxr](https://www.bfxr.net/)
