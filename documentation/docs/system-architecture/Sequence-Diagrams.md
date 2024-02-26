---
sidebar_position: 5
---
## State Diagram for Game Movement
![Screenshot 2024-02-18 150313](https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/assets/74077655/878a32bf-9c3f-4764-ae46-dec5eac9c821)

*This state diagram details how the player can move and navigate the main game map. 
When idle, they have the choice of running, attacking, or jumping. 
While jumping, then can choose to attack while in the air, but they can not attack and then jump while they are still attacking. 
Running is the main method of travelling the map for the user, helping them move and explore more of the game map.*

## Use Case 1: Single-Player Game
```mermaid
sequenceDiagram
Actor User
activate Scene-Manager
activate Title-Screen
    User ->> Title-Screen: Clicks 'Tutorial'
    Title-Screen ->> Scene-Manager: Place user in the Tutorial-Map 
    Scene-Manager -->> User: Sent to Tutorial-Map
activate Tutorial-Map
    User ->> Tutorial-Map: Explores and moves around the tutorial
    User ->> Tutorial-Map: Finishes tutorial
    Tutorial-Map -->> Scene-Manager: Send user back to Title Screen
deactivate Tutorial-Map
    Scene-Manager -->> User: Back to Title Screen
    User ->> Title-Screen: Clicks 'Create Lobby'
    Scene-Manager -->> User: Send user to character select screen
    User ->> Title-Screen: Selects character
    User ->> Title-Screen: Clicks 'Start'
deactivate Title-Screen
    Title-Screen ->> Scene-Manager: Place user in the game
    Scene-Manager -->> User: Sent to main game map
activate Game-Map
    loop Main Gameplay
    User ->> Game-Map: Defeats an enemy
    Game-Map -->> User: Earned experience points and levels up
    User ->> Game-Map: Enters a town
    User ->> Game-Map: Equips and removes skills
    end
    User ->> Game-Map: Explores and moves around the map, and finds final boss
    User ->> Game-Map: Defeats final boss
    Game-Map -->> Scene-Manager: Send user to credits
deactivate Game-Map
    Scene-Manager -->> User: Puts user in credits
deactivate Scene-Manager
```
#### Single-Player Game: A new user wants to play through the game. 

1. The user opens the game and is treated by the home screen. 
2. The home screen has a “tutorial”, “create lobby”, and “join lobby” buttons. Since this is the user’s first time playing the game, the user chooses “tutorial”.
3. The game teaches the user about all of the main mechanics and how to play.
4. After clearing the tutorial, the user is sent back to the title screen and clicks “create lobby”.
5. The user selects their character. Since this is a single-player game, there is no need for them to share the lobby code, so they just select start.
7. The user traverses through the various environments, enemies, and bosses.
8. As the user runs through the map, they have gained experience and new move sets.
9. The user returns to a town, where they are able to equip or remove skills.
11. The user eventually sets back out on their adventure and finds the final boss and is strong enough to defeat it.
12. Once the final boss is defeated, the credits roll, and the game is cleared.

## Use Case 2: Procedurally Generated Map
```mermaid
sequenceDiagram
    actor User
    User ->> Main Menu: Creates a new lobby
activate Main Menu
    Main Menu -->> User: Sends user to Character Selection Screen
deactivate Main Menu
    participant css as Character Selection Screen
    User ->> css: Chooses a character to play as
activate css
    css -->> User: Sends user to main game map
deactivate css
    User ->> Main Game: Explores some of the procedurely generated map
activate Main Game
    User ->> Main Game: Does not enjoy the map or their character, and decides to restart
    Main Game -->> User: Sends user back to main menu
deactivate Main Game
    User ->> Main Menu: Creates a new lobby
activate Main Menu
    Main Menu -->> User: Sends user to Character Selection Screen
deactivate Main Menu
    User ->> css: Chooses a new character
activate css
    css -->> User: Sends user to main game map
deactivate css
    User ->> Main Game: Explores a different procedurely generated map
```
#### Procedurally Generated Map: A user wants to play through a game and have a different experience. 

1. Once loaded into the map and picked their class and character set out in the world.
2. The user levels up and realizes they are not enjoying their class and finds the map seed confusing.
3. The user exits to the main menu and creates a new lobby.
4. They then go through the process of starting a new game and choosing a new character.
5. Since the map was procedurally generated the map has completely changed and the user has a different experience. 

## Use Case 3: Changing difficulty
```mermaid
sequenceDiagram
    actor User
    User ->> Home Screen: Starts a new lobby
activate Home Screen
    Home Screen -->> User: Sends user to Character Selection Screen
deactivate Home Screen
    participant css as Character Selection Screen
    User ->> css: Chooses a character and sets difficulty to the maximum
activate css    
    css -->> User: Sends the user to the main game map
deactivate css
    User ->> Main Game: User plays the game with increased enemy stats due to difficulty
activate Main Game
    User ->> Main Game: Continues play through the game until they defeat the final boss
    Main Game -->> User: Sends user to the credits and rewards an achievement for winning on the maximum difficulty
deactivate Main Game
```
#### A user wants to challenge themselves and increase the difficulty scale. 

1. Users open the game and are greeted by the home screen.  
2. After opening the game, the host creates a lobby but does not invite any players. 
3. The user wanting to challenge themselves, increases the difficulty scale to the maximum. 
4. The user selects their class. 
5. The user starts the game and the map as well as elements load in. 
6. Compared to this player’s previous runs, they find it more challenging due to there being more enemies, the enemies having more damage, and because the enemies have more health. 
7. The player carefully traverses through the environment and defeats enemies until they are strong enough to defeat the final boss. 
8. Upon defeating the final boss, the credits roll, and the game is cleared. 
9. The player gains an achievement for defeating the game on maximum difficulty. 
## Use Case 4: Multiplayer
```mermaid
sequenceDiagram
    actor Host Player
    Host Player ->> Home Screen: Creates a new lobby
activate Home Screen
activate Home Screen
    Home Screen -->> Host Player: Sends host player to the Character Selection Screen
deactivate Home Screen
    participant css as Character Selection Screen
    participant Main Game
    Host Player ->> css: Chooses their character
activate css
    Host Player ->> css: Copies the shown lobby code
    actor Other Players
    Host Player ->> Other Players: Shares lobby code with other players he wants to play with
    Other Players ->> Home Screen: Enters their lobby code on the home screen
activate Home Screen
    Home Screen -->> Other Players: Sends the user to the respective lobby
deactivate Home Screen
deactivate Home Screen
    Other Players ->> css: Chooses their character
activate css
    Other Players ->> css: Clicks the 'ready' button
    css -->> Host Player: All other players are ready, so the start button can be pressed
    Host Player ->> css: Clicks the start button
    css -->> Host Player: Sends the host player to the main game
    css -->> Other Players: Sends other players to the main game
deactivate css
deactivate css
    Host Player ->> Main Game: Explores the game map with other players in the same map and defeats the final boss
activate Main Game
    Other Players ->> Main Game: Explores the game map with other players and the host player in the same map and defeats the final boss
    Main Game -->> Host Player: Sends Host Player
    Main Game -->> Other Players: Sends other players to the credits
deactivate Main Game
```
#### A user wants to play the game with multiple friends. 

1. Users open the game and are greeted by the home screen.  
2. After opening the game, the host chooses multiplayer and opens a lobby. 
3. Up to three other users can join the lobby using the invite code. 
4. Each user chooses their class and character. 
5. The host clicks begin after all users are ready. 
6. Each user loads into the map and can go their separate ways and play through the game.
7. Once at least one user beats the final boss, a way to exit the game will appear.
8. After all users go to the exit, the game will end.
