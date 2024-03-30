---
sidebar_position: 2
---
# Integration tests
<table>
<thead>
<tr>
<th>Test ID</th>
<th>Use Case</th>
<th>Mock Objects</th>
<th>Input</th>
<th>Results</th>
</tr>
</thead>
<tbody>
<tr>
<td>1</td>
<td>Single-Player Game</td>
<td>Player</td>
<td>The player provides input by moving the character left or right, jumping, attacking, and any other way they can directly interact with their character and/or environment.</td>
<td>The character moves according to the player's intended input, for example moving when the player intends the character to without delay.</td>
</tr>
<tr>
<td>2</td>
<td>Procedural Map Generation<br></td>
<td>Random number generator</td>
<td>The necessary input is the size of the map, for example 10 by 10 map blocks.</td>
<td>We should expect a procedurally generated map so that the player can access every map block.</td>
</tr>
<tr>
<td>3</td>
<td>Changing Difficulty</td>
<td>Playable Characters<br>Enemies<br>Bosses</td>
<td>The host player will provide input by selecting or changing the difficulty of the game in the 'start game' menu from the options 'easy,' 'medium,' or 'hard.'</td>
<td>Depending on the selected difficulty, the player's characters will have different statistics in their damage output, health, speed, defense. Likewise, the number of enemies that spawn, as well as their damage output/health will vary depending on the selected difficulty.</td>
</tr>
<tr>
<td>4</td>
<td>Multiplayer</td>
<td>Players</td>
<td>The user will provide input by creating a lobby and inviting people to the lobby.</td>
<td>The expectation is that there will be multiple user that are simutaneously playing in the same game.</td>
</tr>
<tr>
<td>5</td>
<td>Attacking</td>
<td>Players<br>Enemies</td>
<td>The player provides input by clicking specific buttons that will allow the user to do a specific attack which will be able to interact with enemies.</td>
<td>The characters should be able to damage and kill all enemies that they run into with different types of attacks.</td>
</tr>
<tr>
<td>6</td>
<td>Skill Swap</td>
<td>Players<br>Playable Characters</td>
<td>The player will be able to drag and drop abilities into their skill slots.</td>
<td>Every character will have a unique skill set that will be able to change after leveling up.</td>
</tr>
<tr>
<td>7</td>
<td>Warping</td>
<td>Players<br>Playable Characters</td>
<td>The player will provide input by using a button that will prompt the user to teleport them to another user.</td>
<td>The users should be able to teleport to other users in order to do things like group up for important fights.</td>
</tr>
<tr>
<td>8</td>
<td>Tutorial</td>
<td>Player</td>
<td>The input will be the user clicking tutorial from the main menu. </td>
<td>The result should be to be able to give the users a platform on how to play the game and learn the basics of the game. </td>
</tr>
</tbody>
</table>
