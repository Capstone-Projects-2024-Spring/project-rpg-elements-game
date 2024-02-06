---
sidebar_position: 4
---

# Features and Requirements

## Functional Requirements

- Characters – Users have the ability to choose from a cast of characters. These characters feature different combos and skills, defining the class system.
  - At least four different characters/classes will be available.
- Movement System (Player Controller) - Players have diverse movement controls in which they can combine inputs to perform various attacks and skills. In addition to this, the player can interact with the environment by wall jumping and linear dashes.
  - Player sprites will not have collision with one another.
- Enemy AI (AI Controller) - The enemy AI will be simple yet diverse.
  - Simple Track
    - Ground
      - Enemy will attempt to collide with the player's hurt box.
      - Enemy will stand a fixed distance away from the player, colliding a hitbox (either melee or a projectile) against the player's hurt box at certain intervals.
    - Flying
      - They are capable of navigating around terrain and feature attack patterns similar to ground but are not limited by gravity.
  - Directional Charge
    - Some standard enemies will have the ability to do a linear dash towards. the player, dealing damage upon collision, but can also be canceled if a hit box collides with them before contact.
  - Boss
    - Each unique biome has a separate boss.
    - Bosses feature a more diverse skillset and may choose between its attacks based on proximity from player.
- Attributes – Statistics that determine how much damage a player deals, their game speed, and how much health are dictated by attributes.
  - Speed – How fast the player moves.
  - Attack – How much damage is dealt.
  - Defense – How much damage will be reduced when getting hit.
  - Health – How much damage the player can take.
- Environment – The play area will be procedurally generated. The environment will feature different biomes associated with different bosses.
- UI
  - Menu
    - Tutorial
      - This opens a prefabricated level in which the player may learn and experiment with the in-game systems.
    - Create Lobby
      - Upon lobby creation a share code will be generated to invite other players.
      - Users can begin the game, choose the number of players, and play online with up to three friends, or play alone.
      - Within the lobby, the player may actively switch their character until they select the "Ready" button.
      - After clicking the "Ready" button all other options will be deactivated unless they "Unready" themselves.
      - The host may start the game after all players in the lobby designate themselves as ready.
    - Join Lobby
      - Clicking the Join Lobby button will prompt the user with a text field in which they may type a code that will connect them to a lobby.
    - Settings
      - A settings menu will appear that allows the user to adjust various options for the sake of gameplay experience.
- Warping
  - Players should be able to warp to the location of other users (For example, if one user finds a boss and another user wants to help).
  - Should have cooldown on it, and the warping itself shouldn't happen instantaneously.
- Difficulty scaling – The number of enemies and their attributes can be scaled to change how hard the game is.
- In-game Overlay
  - Experience
    - Experience is granted upon defeating an enemy or completing tasks.
    - Experience is shared across all members of the group.
    - A bar will be present that dictates a percentage of experience left to attain the next level. This bar will be present beneath the level indicator.
  - Level
    - An integer value that determines the groups statistics will be permanently visible in the corner of the screen.
    - Gaining levels gives the players attribute points.
  - Attributes Window
    - A key bind may be pressed to open the attribute window.
    - The attribute window will allow the player to increment their stats.
  - Health
    - Health is fixed above the player's sprite.
    - If the character's health is full, that character's health will not be visible.
- Equipment
  - Players may purchase various equipment that can increase or decrease their attributes.
- Input: Game is playable via a keyboard.
- Players will be able to send chat messages.
- Friends list functionality handles the ability to see online players and send invites.
- Players will be able to obtain achievements through completing miscellaneous tasks.

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
- Lobby hosting handled by either Firebase Cloud Functions or Unity Lobby.
- Should run at a smooth framerate on modern hardware (60 FPS).
- Lag should not be frequent. Spikes of 500ms maximum.

