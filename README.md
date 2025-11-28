# Programming_AT03_Version_Control_Project
Assessment 3 of programming, group members are Caleb, Eli and Matt.

|Name|First Feature|Second Feature|Third Feature|
|-|-|-|-|
|**Caleb**| Player Movement | Stats and Leveling | Respawn |
|**Eli**| Player Movement | Menu and Options | Camera Control (or dialogue system) |
|**Matt**| Player Movement | Camera Control | Stats and Leveling |

## Branching Naming Conventions
While our team is collaborating in GitHub, we will be using the Naming Conventions listed below for our branches to make them easy to understand and follow for each of our team members. 
Here are the naming Conventions our team will be using for branches

### Feature Branch
Format: - 'feature/{feature-yourname}'<br>
Example: - 'feature/Stats_and_Leveling-Matthew'<br>
### Bugfix Branches
Format: - 'bugfix/{Bug-description}'<br>
Example: - 'bugfix/fix-respawn-error'<br>
### Release Branches
Format: - 'release/{Version-Number}'<br>
Example: - 'release/v1.4'<br>

## Commit names
Every GitHub commit should include one of the following words to better explain the changes made:
- 'modification': explain why lines of code were added or removed in scripts.
- 'fix': to describe what bug you fixed.
- 'file change': to notify that files were added or removed.
- 'reflector': optimized code to make it run the game smoother.
- 'ui': to describe Added or modified UI elements.

### Camera Controls
The camera is to follow the player and adjust smoothly as the player moves. The player can move the angle and zoom of the camera, based on a clamped amount. 

### Dialogue System
Player can read through text based conversations with an NPC. The player can make choices that affect the conversation and trigger different responses. 

### Menu and Options
Main menu will include a 'New Game' 'Load Game' 'Optoins' and 'Exit'. Options will include the ability to change sound, graphics, and gameplay settings. 

### Player Movement
Player to be able to move freely using WASD or arrow keys. Speed can be changed by crouching or sprinting. movement to be smooth and responsive.

### Respawn
On death, the player is teleported to a predefined spawnpoint. Resets players health, while other stats stay the same. Player movemnt will be bfiefly delayed after respawn, to make sure the player cannot move post-death. A visual cue is required. 

### Stats and Leveling
inlcude stats such as health, XP and level. Leveling improves stats. 
