---
sidebar_position: 3
---
# Acceptance test

| Project Name | Wildlife Odyssey | Block/Skip (B) | 0   |     |
| --- | --- | --- | --- | --- |
| Q/A technical support lead | [ian.tyler@temple.edu](mailto:ian.tyler@temple.edu) | Pass (P) | 0   |     |
| Q/A Round | 1   | Fail (F) | 0   |     |
| Platform |     |     |     |     |
| Tester Name |     | % Complete | 0%  | Notes if failed |
| Acceptance Testing |     |     |     |     |
| Test ID | Action/Steps | Notes/Expected Result |     |     |
| 1   | **Install Wildlife Odyssey to PC.**    Open up our Github Repository and download the executable. | Executable is now installed to device and is runnable. |     |     |
| 2   | **Signup for Wildlife Odyssey**    Upon openning Wildlife Odyssey tap the sign up button. Enter a username and password. Click Sign Up again. | You should now be given access to the main menu. The title, single player, lobby, and friends list should now be available. |     |     |
| 3   | **Login/Logout**    In the corner of the screen tap the log out button. Now, enter the username and password from the previous step. Click login. | At logout you should see the login screen. On login you should now be given access to the main menu. The title, tutorial, lobby, and friends list should now be available. |     |     |
| 4   | **Friends List**    In the upper corner of the screen, tap the friends list icon. | A side bar should now appear that lists your account name followed by an empty list. |     |     |
| 5   | **Add a Friend**    Click the plus icon. Enter in the following user ID: 'Eddyiscool123' | A friend request will be sent to the ID Eddyiscool123. A prompt will appear that states "Friend request sent" with a button to close it. |     |     |
| 6   | **Create Lobby**    Click the button labelled "Create Lobby". Then press the 'Exit Lobby' button. | \- Upon clicking the 'Create Lobby' button a new canvas will replace the Main Menu.  \- This lobby screen will contain the character selection, a generated lobby code, lock in button, and exit lobby button.  \- After hitting the exit lobby button, the player should be greeted with the main menu canvas once again. |     |     |
| 7   | **Join Lobby**    Click the button labelled "Join Lobby". Press the 'Cancel' button. | \- Upon hitting the join lobby button a text prompt will appear asking the user to enter a code. No other canvas elements will be accessible (though still visible) until a valid lobby code is entered or the 'Cancel' button is pressed. |     |     |
| 8   | **Tutorial**    Click the button labelled "Tutorial". | Clicking the tutorial button will hide all of the main menu canvas element. Player input will be enabled and a new scene will be loaded. |     |     |
| 9   | **Basic Movement**    Press the 'A' Key.  Press the ' D' Key.  Press the 'Space' Key. | Pressing 'A' should move the player sprite left.  Pressing 'D' should move the player sprite right.  Pressing 'Space' should move the player upwards and return them back down. |     |     |
| 10  | **Advanced Movement \- Wall Slide**    Using the movement inputs from the previous step, position the player sprite near a wall. Facing the wall, move towards it but jump before colliding. Continue holding the forward input until the player sprite reaches the ground. | Upon colliding with the wall, the player's descent will be slowed while the player is holding the input in the direction of the wall. |     |     |
| 11  | **Advanced Movement \- Wall Jump**    Repeat the steps from the previous test, but at any point press 'Space' while in the process of wall sliding. | Player should be displaced with some horizontal and vertical velocity away from the wall. |     |     |
| 12  | **Character Attacks/Skills & Enemy Interactions**    Press the keys 'J' 'K' 'L' and ';' | Each key pressed is associated with a different skill. When a skill is used, the character's movement inputs should be stalled and an animation will be played. |     |     |
| 13  | **Character Experience & Leveling**    Locate the enemy AI and using the Character Attack/Skills defeat it. | Experience points will be granted to the player. The player's Experience UI component will fill to the percentage that the player has until the next level. On level up, the player's stats will increase which will have a pop up window that displays the stats that increased. |     |     |
| 14  | **Procedural Map Generation**    Upon loading into the game, a map will be procedurally generated. | The map should differ on each playthrough. Including character spawn/boss location, paths to be taken through map, and enemies/platform placement throughout these paths. |     |     |
| 15  | **Game Difficult Levels**    When setting game options, the user can choose different difficulties | After loading into the game, enemies will have stat multipliers that either increase or decrease difficulty |     |     |
| 16  | **Multiplayer Gameplay**    After choosing to create or join a lobby, other players join the user for a multiplayer game. | After loading into the game, players will share game state. Each user will be able to see and interact with each other throughout the game. |     |     |
| 17  | **Final Boss**    Locate the final boss via it's teleporter room. | Final boss should spawn in it's own dedicated room. It's room can be accessed by a teleporter that is the furthest distance from the user's spawn point. |     |     |
| 18  | **Achievements**    In the main menu click the achievement icon. | Upon clicking the achievements icon you will be awarded an achievement. Any achievements you have obtained will be colored while unobtained achievements will be in gray scale. |     |     |
| 19  | **Credits** | Once the final boss is defeated the players will be greeted with end game credits. |
