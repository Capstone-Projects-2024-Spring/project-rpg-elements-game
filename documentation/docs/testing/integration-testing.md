---
sidebar_position: 2
---
# Integration tests

Tests to demonstrate each use-case based on the use-case descriptions and the sequence diagrams. External input is provided via mock objects and results verified via mock objects. Integration tests do not require manual entry of data nor require manual interpretation of results.

<table cellspacing="0" style="border-collapse: collapse;">
  <tbody>
    <tr>
    <tr>
      <td class="" style="width: 206.25px; height: 33.75px; font-weight: bold; font-size: 10px; text-align: center; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0);"></td>
      <td class="" style="width: 195.75px; height: 33.75px; font-weight: bold; font-size: 10px; text-align: center; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0);"></td>
      <td class="" style="width: 164.25px; height: 33.75px; font-weight: bold; font-size: 10px; text-align: center; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0);"></td>
      <td class="" style="width: 164.25px; height: 33.75px; font-weight: bold; font-size: 10px; text-align: center; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);"></td>
    </tr>
    <tr>
      <td class="" style="background-color: rgb(0, 0, 255); width: 164.25px; height: 33.75px; font-weight: bold; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(0, 255, 0); border-left: 1px solid rgb(255, 0, 0);">Test ID</td>
      <td class="" style="background-color: rgb(0, 0, 255); width: 206.25px; height: 33.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Use Case</td>
      <td class="" style="background-color: rgb(0, 0, 255); width: 195.75px; height: 33.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Mock Objects</td>
      <td class="" style="background-color: rgb(0, 0, 255); width: 164.25px; height: 33.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Input</td>
      <td class="" style="background-color: rgb(0, 0, 255); width: 164.25px; height: 33.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Results</td>
    </tr>
    <tr>
      <td class="" style="background-color: rgb(255, 255, 0); width: 164.25px; height: 62.25px; font-weight: bold; font-size: 10px; text-align: right; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0); border-left: 1px solid rgb(255, 0, 0);">1</td>
      <td class="" style="width: 206.25px; height: 62.25px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Single-Player Game</td>
      <td class="" style="width: 195.75px; height: 62.25px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Player</td>
      <td class="" style="width: 164.25px; height: 62.25px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The player provides input by moving the character left or right, jumping, attacking, and any other way they can directly interact with their character and/or environment.</td>
      <td class="" style="width: 164.25px; height: 62.25px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The character moves according to the player's intended input, for example moving when the player intends the character to without delay.</td>
    </tr>
    <tr>
      <td class="" style="background-color: rgb(255, 255, 0); width: 164.25px; height: 48px; font-weight: bold; font-size: 10px; text-align: right; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0); border-left: 1px solid rgb(255, 0, 0);">2</td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 206.25px; height: 48px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Procedural Map Generation
</td>
      <td class="" style="background-color: rgb(255, 0, 255); width: 195.75px; height: 48px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Random number generator</td>
      <td class="" style="width: 164.25px; height: 48px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The necessary input is the size of the map, for example 10 by 10 map blocks.</td>
      <td class="" style="width: 164.25px; height: 48px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">We should expect a procedurally generated map so that the player can access every map block.</td>
    </tr>
    <tr>
      <td class="" style="background-color: rgb(255, 255, 0); width: 164.25px; height: 51.75px; font-weight: bold; font-size: 10px; text-align: right; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0); border-left: 1px solid rgb(255, 0, 0);">3</td>
      <td class="" style="width: 206.25px; height: 51.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Changing Difficulty</td>
      <td class="" style="width: 195.75px; height: 51.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Playable Characters
Enemies
Bosses</td>
      <td class="" style="width: 164.25px; height: 51.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The host player will provide input by selecting or changing the difficulty of the game in the 'start game' menu from the options 'easy,' 'medium,' or 'hard.'</td>
      <td class="" style="width: 164.25px; height: 51.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Depending on the selected difficulty, the player's characters will have different statistics in their damage output, health, speed, defense. Likewise, the number of enemies that spawn, as well as their damage output/health will vary depending on the selected difficulty.</td>
    </tr>
    <tr>
      <td class="" style="background-color: rgb(255, 255, 0); width: 164.25px; height: 43.5px; font-weight: bold; font-size: 10px; text-align: right; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0); border-left: 1px solid rgb(255, 0, 0);">4</td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 206.25px; height: 43.5px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Multiplayer</td>
      <td class="" style="background-color: rgb(255, 0, 255); width: 195.75px; height: 43.5px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Players </td>
      <td class="" style="background-color: rgb(255, 0, 255); width: 164.25px; height: 43.5px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The user will provide input by creating a lobby and inviting people to the lobby. </td>
      <td class="" style="background-color: rgb(255, 0, 255); width: 164.25px; height: 43.5px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The expectation is that there will be multiple user that are simutaneously playing in the same game.</td>
    </tr>
    <tr>
      <td class="" style="background-color: rgb(255, 255, 0); width: 164.25px; height: 63.75px; font-weight: bold; font-size: 10px; text-align: right; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0); border-left: 1px solid rgb(255, 0, 0);">5</td>
      <td class="" style="width: 206.25px; height: 63.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Attacking</td>
      <td class="" style="width: 195.75px; height: 63.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Players
Enemies</td>
      <td class="" style="width: 164.25px; height: 63.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The player provides input by clicking specific buttons that will allow the user to do a specific attack which will be able to interact with enemies. </td>
      <td class="" style="width: 164.25px; height: 63.75px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The characters should be able to damage and kill all enemies that they run into with different types of attacks.</td>
    </tr>
    <tr>
      <td class="" style="background-color: rgb(255, 255, 0); width: 164.25px; height: 49.5px; font-weight: bold; font-size: 10px; text-align: right; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0); border-left: 1px solid rgb(255, 0, 0);">6</td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 206.25px; height: 49.5px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Skill Swap</td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 195.75px; height: 49.5px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Players
Playable Characters</td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 164.25px; height: 49.5px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The player will be able to drag and drop abilities into their skill slots. </td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 164.25px; height: 49.5px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Every character will have a unique skill set that will be able to change after leveling up.</td>
    </tr>
    <tr>
      <td class="" style="background-color: rgb(255, 255, 0); width: 164.25px; height: 48px; font-weight: bold; font-size: 10px; text-align: right; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0); border-left: 1px solid rgb(255, 0, 0);">7</td>
      <td class="" style="width: 206.25px; height: 48px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Warping</td>
      <td class="" style="width: 195.75px; height: 48px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Players
Playable Characters</td>
      <td class="" style="width: 164.25px; height: 48px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The player will provide input by using a button that will prompt the user to teleport them to another user. </td>
      <td class="" style="width: 164.25px; height: 48px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The users should be able to teleport to other users in order to do things like group up for important fights. </td>
    </tr>
    <tr>
      <td class="" style="background-color: rgb(255, 255, 0); width: 164.25px; height: 47.25px; font-weight: bold; font-size: 10px; text-align: right; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0); border-left: 1px solid rgb(255, 0, 0);">8</td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 206.25px; height: 47.25px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Tutorial</td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 195.75px; height: 47.25px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">Player</td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 164.25px; height: 47.25px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The input will be the user clicking tutorial from the main menu. </td>
      <td class="" style="background-color: rgb(242, 242, 242); width: 164.25px; height: 47.25px; font-size: 10px; text-align: left; vertical-align: top; border-bottom: 1px solid rgb(255, 0, 0); border-right: 1px solid rgb(255, 0, 0);">The result should be to be able to give the users a platform on how to play the game and learn the basics of the game. </td>
    </tr>
  </tbody>
</table>
