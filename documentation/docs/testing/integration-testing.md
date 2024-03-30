---
sidebar_position: 2
---
# Integration tests
| Test ID | Use Case | Mock Objects | Input | Results |
| --- | --- | --- | --- | --- |
| 1   | Single-Player Game | Player | The player provides input by moving the character left or right, jumping, attacking, and any other way they can directly interact with their character and/or environment. | The character moves according to the player's intended input, for example moving when the player intends the character to without delay. |
| 2   | Procedural Map Generation | Random number generator | The necessary input is the size of the map, for example 10 by 10 map blocks. | We should expect a procedurally generated map so that the player can access every map block. |
| 3   | Changing Difficulty | Playable Characters,  Enemies,  Bosses | The host player will provide input by selecting or changing the difficulty of the game in the 'start game' menu from the options 'easy,' 'medium,' or 'hard.' | Depending on the selected difficulty, the player's characters will have different statistics in their damage output, health, speed, defense. Likewise, the number of enemies that spawn, as well as their damage output/health will vary depending on the selected difficulty. |
| 4   | Multiplayer | Players | The user will provide input by creating a lobby and inviting people to the lobby. | The expectation is that there will be multiple user that are simutaneously playing in the same game. |
| 5   | Attacking | Players,  Enemies | The player provides input by clicking specific buttons that will allow the user to do a specific attack which will be able to interact with enemies. | The characters should be able to damage and kill all enemies that they run into with different types of attacks. |
| 6   | Skill Swap | Players,  Playable Characters | The player will be able to drag and drop abilities into their skill slots. | Every character will have a unique skill set that will be able to change after leveling up. |
| 7   | Warping | Players,  Playable Characters | The player will provide input by using a button that will prompt the user to teleport them to another user. | The users should be able to teleport to other users in order to do things like group up for important fights. |
| 8   | Tutorial | Player | The input will be the user clicking tutorial from the main menu. | The result should be to be able to give the users a platform on how to play the game and learn the basics of the game. |
