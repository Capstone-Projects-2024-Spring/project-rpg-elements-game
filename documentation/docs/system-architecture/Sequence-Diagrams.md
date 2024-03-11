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

## Use Case 5: Attacking
```mermaid
sequenceDiagram

    Actor P as Player
    Participant PC as PlayerController
    Participant HI as Hitbox (Player's)
    Participant PA as Player Attack
    Participant HU as Hurtbox (Enemy's)
    Participant EC as EnemyController

    autonumber
    P->>+PC: Input Attack
    PC->>+PA: DogStrike()
    PA->>+HI: setActive(true)
    PA->>PC: enterHitlag()
    deactivate PC
    deactivate PA
    HI->>+HU: OnTriggerEnter2D()
    deactivate HI
    HU->>+EC: LowerHealth()
    HU->>EC: HitStun()
    HU->>EC: AppliedKnockback()

    deactivate HU
    deactivate EC
```
#### A player initiates an attack.

1. Player provides an attack which is sent to the Player Controller.
2. The PlayerController interprets that input and initiates the associated attack.
3. The hitbox is activated.
4. The PlayerController is entered into a hitlag state where they can not provide movement.
5. When the hitbox collides with the hurtbox, the OnTrigger method activates.
6. The attack's hitbox is then deactivated.
7. The Hurtbox informs the enemy controller about various attributes that should be applied such as damage, stun, and knockback.

## Use Case 6: Skill Swap
```mermaid
sequenceDiagram
    actor P as Player
    participant S as Skill UI (Canvas)
    participant SL as Skill List
    participant SS as Skill Slot
    participant PC as PlayerController

    P->>+S:  Opens Skill Panel
    S->>+SS: DisplayCurrentSkills()
    S->>+SL: DisplayList()
    loop for each skill
        SS->>+PC: FetchCurrentSkill()
        PC-->>-SS: ReturnCurrentSkill()
    end
    P->>SL: Player drags skill from list to slot
    SL->>SS: SetSkill()
    SS->>+PC: RebindKeyToSkill()
    deactivate PC
    SS-->>SL: PreviousSkill()

    deactivate SL
    deactivate SS
    deactivate S
```

#### Player swaps skills.
1. Upon opening the skill panel two elements pop up, the list of skills and the skill slots.
2. The Skill Slot will query the player controller to see what skills are currently equipped.
3. The player can set different skills by moving a skill from the list to the slot.
4. Upon doing this, the skill is rebound to the slot and the previous skill is returned to the list.

## Use Case 7: Warping
```mermaid
sequenceDiagram

    actor P as Player 1
    participant 1C as Player 1's Canvas
    participant O1 as Player Object
    participant W as Warp (Script)
    participant O2 as Player 2 Object
    participant 2C as Player 2's Canvas
    actor P2 as Player 2

    P ->>+ 1C: Player interacts with Warp UI
    Note right of 1C: Possibly pause input while request active
    1C ->>+ W: WarpRequest(): Player Object
    W ->>+ 2C: CreateDialog(): Bool
    alt Declining
        P2 ->> 2C: Player clicks 'No' on UI
        deactivate 2C
        2C -->> W: False
        W -->> 1C: FailureDialog()
        deactivate W
        deactivate 1C

    else Accepting
        P2 ->>+ 2C: Player clicks 'Yes' on UI
        2C -->>+ W: True
        deactivate 2C
        W-->>+ 1C: SuccessDialog()
        W ->> W: Wait(3)
        W ->>+ O2:  QueryPosition()
        O2 -->>- W: get PlayerObject2.transform.position;
        W ->>+ O1: set equal PlayerObject2.transform.position
        W -->> 1C: CloseDialog()
        deactivate 1C
        deactivate O1
        deactivate W 
    end
```
#### Player sends a warp request.
1. Player interacts with Canvas Element to send warp request to other player.
2. Warp Request Dialog will appear on other player's canvas.
3. The other player may either accept or decline this request.
4. On decline, the requesting player is notified that their request failed.
5. On accept, the requesting player is notified that their request was accepted.
6. They are then forced to wait for a period of time.
7. The Warp Script will then query the second player's position and then set it to the first player's position.

## Use Case 8: Tutorial
```mermaid
sequenceDiagram
    actor P as Player

    participant C as Canvas
    participant SM as SceneManager
    participant IO as PlayerInput
    participant T as <<Scene>> Tutorial
    
    
    P->>+C: OnClickTutorial()
    C->>+SM: LoadSceneAsync(Tutorial) : Scene
    SM->>+T: LoadSceneAsync(Tutorial) : Scene
    T-->>+IO: setActive(true)
    SM-->>-C: sceneLoaded()
    C->>C: setActive(false)
    deactivate C
    loop
        P->>IO: interacting with level
    end
    
    par T to IO
        T-->>IO: setActive(false)
        deactivate IO
    and T to SM
        T-->>+SM: TutorialClear()
    end
    SM->>T: unloadSceneAsync()
    T-->>SM: sceneUnloaded()
    SM-->>+C: loadMainMenu(): Canvas
    deactivate SM
    deactivate T
    deactivate C
```
#### Player enters the tutorial.
1. Player clicks the tutorial button in the main menu.
2. Scene loads and hides the canvas.
3. Player Input is activated and the player may interact with the game.
4. Upon clearing the tutorial, the player input is deactivated and the scene is unloaded.
5. The main menu canvas is reloaded onto the player's screen.
