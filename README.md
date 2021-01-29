
UNITY VERSION 2020.2.2f1
Instructions

The project contains the standard assets. 
Use the folder provided to add to the game 

Game Build Auto resizes to 480 270

Under 0_Game/Screens

  -North Screen
  -South Screen
  -West Screen
  -East Screen
  
HOW TO USE VARIABLES:

1. Create a variable in the project view via 
  right click 
    Create -> Game -> Game Variable 
  For organization Sake move variable to this folder 
  Assets/0_Game/GameVariables
  
2. In Scene Add Variable to the Game Variables Game Object 
3. You use the Toggle Game Variable Component to manipulate the variable
   Drag your variable scriptable object to the slot that says Ref Variable 
   on the Toggle Game Variable Component
   Use the Method 'Change State' to toggle the variable on and off
   Use 'Hide World Object' to deactive the gameobject with the toggle game variable Component

Important: Don't rename/delete variables you didn't create

Example Scene :

Go to scene at "Assets/0_Game/Screens/SouthScreen/southscreen.unity"
Find the Game Variables Game Object it has a Game Var Dictionary
Here add the variables the you'll use in the scene 
This one has 'gotFrequency' in the variable list. 
Next go to the "clue1_frequencyCode" game object scroll its components until you find
the Toggle Game Variable, in its reference it has 'gotFrequency'

When adding a Game Variable you must also label it with a 'GameVariable' Label found at the lower right corner of the inspector 
when you click on a game variable asset.

Beforing testin make sure to build the variables via the menu item Tool/Build Variables while in the GameGlue scene

How you develop the logic depends on you, but the game variables will be used to know what point of the game
the player is in. 

When updating a game screen, tag the gameobjects you want to appear in the scene with "rule"
then hit the menu item Tools/Screenify
