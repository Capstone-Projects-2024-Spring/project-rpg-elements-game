---
sidebar_position: 4
---

# Features and Requirements

## Functional Requirements
- The game should load each player into a large 2D world where they can explore and fight enemies using the characters they have chosen.
  - A room with the game's "final boss" is randomly placed somewhere in the world. If the final boss is defeated, the game is considered complete and the main campaign is beaten.
- Lobbies – Multiplayer system allows users to generate codes that can be sent to other players to connect and play together simultaneously
- Title Screen 
  - Upon starting the game, the user is greeted with a title screen with at least 3 main buttons on it:
  - Tutorial
    - This opens a prefabricated level in which the player may learn and experiment with the in-game systems.
  - Create Lobby
    - Allows the user to create a lobby. These will have codes that allows other users to join the same lobby and play together.
  - Join Lobby
    - Allows the user to join a lobby and play together.
- Movement System (Player Controller) - Players have diverse movement controls in which they can combine inputs to perform various attacks and skills. In addition to this, the player can interact with the environment by wall jumping and linear dashes.
  - Player sprites will not have collision with one another.
  - Basic attacks can be performed for all characters.
  - Characters can perform skill attacks that differ from each other.
  - Characters can jump.
  - Wall jumps and dashes can be performed.
- Characters – Users can choose from a cast of characters. These characters have different attacks and attributes.
  - At least eight different characters will be available.
  - Characters can respawn.
  - Characters can take damage.
- Environment – The play area will be procedurally generated. The environment will feature different biomes associated with different bosses.
  - The environment will generate platforms that players can stand on.
  - The environment supports trap generation that damages the player.
  - Biomes will generate with different tile sets.
- Enemies
  - The environment will be populated by enemies
  - Each enemy will try to attack the player or hinder their progress.
  - Certain enemies will be bosses in designated rooms that take more effort to fight.
 - Input: Game is playable via a keyboard.

## Nonfunctional Requirements
- Attributes – Statistics that determine how much damage a player deals, their game speed, and how much health they have are dictated by attributes.
  - The main attributes each character has will be:
    - Attack
      - Dictates how much damage their attacks do
    -  Speed
      - Dictates how fast they move
    -  Defense
      - Affects how much damage is reduced when the player gets attacked
    - Health
      - Affects how much HP the player has
  - Enemies will also have these same attributes
- Level
  - An integer value that determines the groups statistics will be permanently visible in the corner of the screen.
  - Gaining levels increases each player's attributes.
 - Experience
  - Experience is granted upon defeating an enemy or completing tasks.
  - Experience is shared across all members of the group.
  - A bar will be present that dictates a percentage of experience left to attain the next level. This bar will be present beneath the level indicator.
- Camera – Game camera will track the player.
  - For each player, the game's camera will follow their character and keep them in the center of the screen.
- Difficulty scaling – The number of enemies and their attributes scale with number of players but can be modified by the host.
- Warping
  - Players should be able to warp to the location of other users (For example, if one user finds a boss and another user wants to help).
  - Should have cooldown on it, and the warping itself shouldn't happen instantaneously.
- Custom character sprites
  - Characters as well as their move sets are fabricated.
- Custom environment sprites
  - Environment uses background and entities that are designed for this project.
- Custom sound design & music
  - SFX for weapons, hit sounds, interactable objects are designed and implemented.
- Game loads in less than a minute
  - Further testing of procedural generation is required to determine a good estimate.
- Firebase authentication handles user authentication.
- Lobby hosting is handled by either Firebase Cloud Functions or Unity Lobby.
- Should run at a smooth framerate on modern hardware (60 FPS).
- Lag should not be frequent (\<500ms spikes).
- Players will be able to send in-game chat messages.
- Friends list functionality handles the ability to see online players and send invites.



