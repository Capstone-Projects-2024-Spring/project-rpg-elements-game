---
sidebar_position: 4
---

# Features and Requirements

## Functional Requirements

- Characters – Users can choose from a cast of characters. These characters feature different combos and skills, defining the class system.
  - At least eight different characters/classes will be available.
  - Characters can respawn.
  - Characters can take damage.
- Lobbies – Multiplayer system allows users to generate codes that can be sent to other players to connect and play together simultaneously
- Movement System (Player Controller) - Players have diverse movement controls in which they can combine inputs to perform various attacks and skills. In addition to this, the player can interact with the environment by wall jumping and linear dashes.
  - Player sprites will not have collision with one another.
  - Basic attacks can be performed for all characters.
  - Characters can perform skill attacks that differ from each other.
  - Characters can jump.
  - Wall jumps and dashes can be performed.
- Enemy AI (AI Controller) - The enemy AI will be simple yet diverse.
- I-frames – Characters and enemies will be invincible for a certain amount of frames after taking damage.
- Attributes – Statistics that determine how much damage a player deals, their game speed, and how much health are dictated by attributes.
  - Speed, Attack, Defense, Health
- Environment – The play area will be procedurally generated. The environment will feature different biomes associated with different bosses.
  - The environment will generate platforms that players can stand on.
  - The environment supports trap generation that damages the player.
  - Enemies will spawn in the environment.
  - Biomes will generate with different tile sets.
- Warping
  - Players should be able to warp to the location of other users (For example, if one user finds a boss and another user wants to help).
  - Should have cooldown on it, and the warping itself shouldn't happen instantaneously.
- Difficulty scaling – The number of enemies and their attributes scale with number of players but can be modified by the host.
- Experience
  - Experience is granted upon defeating an enemy or completing tasks.
  - Experience is shared across all members of the group.
  - A bar will be present that dictates a percentage of experience left to attain the next level. This bar will be present beneath the level indicator.
- Level
  - An integer value that determines the groups statistics will be permanently visible in the corner of the screen.
  - Gaining levels gives the players attribute points.
- Tutorial
  - This opens a prefabricated level in which the player may learn and experiment with the in-game systems.
- Input: Game is playable via a keyboard.
- Players will be able to send chat messages.
- Friends list functionality handles the ability to see online players and send invites.
- Camera – Game camera will track the player

## Nonfunctional Requirements

- Custom character sprites
  - Characters as well as their move sets are fabricated.
  - Character sprite clothing is modifiable by the player via choosing prefabricated clothing.
- Custom environment sprites
  - Environment uses background and entities that are designed for this project.
- Custom sound design & music
  - SFX for weapons, hit sounds, interactable objects are designed and implemented.
- Game loads in X time
  - Further testing of procedural generation is required to determine a good estimate.
- Firebase authentication handles user authentication.
- Lobby hosting is handled by either Firebase Cloud Functions or Unity Lobby.
- Should run at a smooth framerate on modern hardware (60 FPS).
- Lag should not be frequent (\<500ms spikes).


