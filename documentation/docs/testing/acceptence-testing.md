---
sidebar_position: 3
---
# Acceptance test
<table>
<thead>
<tr>
<th>Project Name</th>
<th>Wildlife Odyssey</th>
<th>Block/Skip (B)</th>
<th>0</th>
<th></th>
</tr>
</thead>
<tbody>
<tr>
<td>Q/A technical support lead</td>
<td><a href="mailto:ian.tyler@temple.edu">ian.tyler@temple.edu</a></td>
<td>Pass (P)</td>
<td>0</td>
<td></td>
</tr>
<tr>
<td>Q/A Round</td>
<td>1</td>
<td>Fail (F)</td>
<td>0</td>
<td></td>
</tr>
<tr>
<td>Platform</td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td>Tester Name</td>
<td></td>
<td>% Complete</td>
<td>0%</td>
<td>Notes if failed</td>
</tr>
<tr>
<td>Acceptance Testing</td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>
<tr>
<td>Test ID</td>
<td>Action/Steps</td>
<td>Notes/Expected Result</td>
<td></td>
<td></td>
</tr>
<tr>
<td>1</td>
<td>Install Wildlife Odyssey to PC.<br>Open up our Github Repository and download the executable.</td>
<td>Executable is now installed to device and is runnable.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>2</td>
<td>Signup for Wildlife Odyssey<br>Upon openning Wildlife Odyssey tap the sign up button. Enter a username and password. Click Sign Up again.</td>
<td>You should now be given access to the main menu. The title, single player, lobby, and friends list should now be available.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>3</td>
<td>Login/Logout<br>In the corner of the screen tap the log out button. Now, enter the username and password from the previous step. Click login.</td>
<td>At logout you should see the login screen. On login you should now be given access to the main menu. The title, tutorial, lobby, and friends list should now be available.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>4</td>
<td>Friends List<br>In the upper corner of the screen, tap the friends list icon.</td>
<td>A side bar should now appear that lists your account name followed by an empty list.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>5</td>
<td>Add a Friend<br>Click the plus icon. Enter in the following user ID: 'Eddyiscool123'<br></td>
<td>A friend request will be sent to the ID Eddyiscool123. A prompt will appear that states "Friend request sent" with a button to close it.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>6</td>
<td>Create Lobby<br>Click the button labelled "Create Lobby"<br>Press the 'Exit Lobby' button.<br><br><br></td>
<td>- Upon clicking the 'Create Lobby' button a new canvas will replace the Main Menu.<br>- This lobby screen will contain the character selection, a generated lobby code, lock in button, and exit lobby button.<br>- After hitting the exit lobby button, the player should be greeted with the main menu canvas once again.<br></td>
<td></td>
<td></td>
</tr>
<tr>
<td>7</td>
<td>Join Lobby<br>Click the button labelled "Join Lobby"<br>Press the 'Cancel' button.</td>
<td>- Upon hitting the join lobby button a text prompt will appear asking the user to enter a code. No other canvas elements will be accessible (though still visible) until a valid lobby code is entered or the 'Cancel' button is pressed.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>8</td>
<td>Tutorial<br>Click the button labelled "Tutorial".</td>
<td>Clicking the tutorial button will hide all of the main menu canvas element. Player input will be enabled and a new scene will be loaded.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>9</td>
<td>Basic Movement<br>Press the 'A' Key.<br>Press the ' D' Key.<br>Press the 'Space' Key.<br></td>
<td>Pressing 'A' should move the player sprite left.<br>Pressing 'D' should move the player sprite right.<br>Pressing 'Space' should move the player upwards and return them back down.<br></td>
<td></td>
<td></td>
</tr>
<tr>
<td>10</td>
<td>Advanced Movement - Wall Slide<br>Using the movement inputs from the previous step, position the player sprite near a wall.<br>Facing the wall, move towards it but jump before colliding. Continue holding the forward input until the player sprite reaches the ground.<br></td>
<td>Upon colliding with the wall, the player's descent will be slowed while the player is holding the input in the direction of the wall.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>11</td>
<td>Advanced Movement - Wall Jump<br>Repeat the steps from the previous test, but at any point press 'Space' while in the process of wall sliding.</td>
<td>Player should be displaced with some horizontal and vertical velocity away from the wall.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>12</td>
<td>Character Attacks/Skills &amp; Enemy Interactions<br>Press the keys 'J' 'K' 'L' and ';'</td>
<td>Each key pressed is associated with a different skill. When a skill is used, the character's movement inputs should be stalled and an animation will be played.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>13</td>
<td>Character Experience &amp; Leveling<br>Locate the enemy AI and using the Character Attack/Skills defeat it.</td>
<td>Experience points will be granted to the player. The player's Experience UI component will fill to the percentage that the player has until the next level. On level up, the player's stats will increase which will have a pop up window that displays the stats that increased.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>14</td>
<td>Procedural Map Generation<br>Upon loading into the game, a map will be procedurally generated.</td>
<td>The map should differ on each playthrough. Including character spawn/boss location, paths to be taken through map, and enemies/platform placement throughout these paths.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>15</td>
<td>Game Difficult Levels<br>When setting game options, the user can choose different difficulties</td>
<td>After loading into the game, enemies will have stat multipliers that either increase or decrease difficulty</td>
<td></td>
<td></td>
</tr>
<tr>
<td>16</td>
<td>Multiplayer Gameplay<br>After choosing to create or join a lobby, other players join the user for a multiplayer game.</td>
<td>After loading into the game, players will share game state. Each user will be able to see and interact with each other throughout the game.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>17</td>
<td>Final Boss<br>Locate the final boss via it's teleporter room.</td>
<td>Final boss should spawn in it's own dedicated room. It's room can be accessed by a teleporter that is the furthest distance from the user's spawn point.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>18</td>
<td>Achievements<br>In the main menu click the achievement icon.</td>
<td>Upon clicking the achievements icon you will be awarded an achievement. Any achievements you have obtained will be colored while unobtained achievements will be in gray scale.</td>
<td></td>
<td></td>
</tr>
<tr>
<td>19</td>
<td>Credits</td>
<td>Once the final boss is defeated the players will be greeted with end game credits.</td>
<td></td>
<td></td>
</tr>
</tbody>
</table>
