---
sidebar_position: 2
---

### Unity (Game Engine)
Unity will be the hub for all of the user data. 
#### Interfaces (Data Sent)
* **Firebase Real-time Database**
    * Lobby Messages
    * New Friends' IDs
    * Credentials (Authentication)
* **Photon (Multiplayer Matchmaking)**
    * Networked lobby system

### Firebase (Real-time Database & User Authentication)
Firebase will be used to create a customizable user authentication system, as well as a real-time database for friends' lists/user messages. After logging in with Firebase, Photon will need its stored user data like a static UserID, friends list, and retained chat messages. Photon matchmaking will use this data for sending/receiving friends' game invites and displaying gamertags in lobby.
#### Interfaces (Data Sent)
* **Photon**
    * Authentication Approval/Denial
    * Restore Previous Chat Messages
    * Retrieve Friends' List

### Photon (Networking Solution)
Photon is a real-time cloud Networking solution that is used for room-based multiplayer and matchmaking. It can be used to create a lobby for players to invite friends, randomly search for a game, or search through a parameterized list. 
#### Interfaces (Data Sent)
* **FireBase**
    * Other Users' game state
    * Messages From Other Users


```mermaid
classDiagram

    Player o-- PlayerController
    Player o-- PlayerStats
    Player -- UIManager
    EnemyController o-- EnemyStats
    CharacterStat -- EnemyStats
    CharacterStat -- PlayerStats

    Firebase o-- ChatMessenger
    Firebase o-- UserAuthentication
    Firebase o-- FriendsListManager
    LoginManager --o Firebase


    Photon o-- Launcher
    Photon o-- QuickMatch
    Mirror ..> Photon
    Mirror *-- NetworkManager
    NetworkManager --> KCP Transport
    Launcher -- FriendsListManager
    Launcher ..> MenuManager
    namespace BackEnd{
        class Mirror{
            NetworkManager: class
        }

        class NetworkManager{
            <<Mirror Component>>
            KCP Transport: Component
            Gary: Prefab
        }

        class KCP Transport{
            <<Component>>
            + FastResend: int
            + ReceiveWindowSize: uint
            + SendWindowSize: uint
            # server: KcpServer
            # client: KcpClient
        }

        class Photon{
            Launcher: class
            QuickMatch: class
        }

        class Launcher{
            + roomNameInputField: InputField
            + roomNameText: roomNameText
            + roomListContent: Transform
            + roomListItemPrefab: GameObject
            Awake() void
            Start() void
            OnConnectedToMaster() void
            OnJoinedLobby() void
            CreateRoom() void
            OnJoinedRoom() void
            OnMasterClientSwitched(Player newMasterClient) void
            JoinRoom() void
            StartGame() void
            LeaveRoom() void
            OnLeftRoom() void
            OnRoomListUpdate() void
            OnPlayerEnteredRoom() void
            InviteFriendToRoom(Friend friend) void
            JoinFriendRoom(Friend friend) void
        }

        class QuickMatch{
            Start() void
            QuickMatch() void
            OnConnectedToMaster() void
            OnJoinRandomFailed(short returnCode, string message) void
            OnJoinedRoom() void
        }

        class Firebase{
            ChatMessenger: class
            UserAuthentication: class
            FriendsListManager: class
        }

        class ChatMessenger{
            returnChatlogs()

        }

        class UserAuthentication{
            register()
            login()
            logout()
        }

        class FriendsListManager{
            + friendsList: FriendsList
            addFriend(ID friend)
            removeFriend(ID friend)
            getFriends() FriendsList
        }

        class LoginManager{
            usernameInput: InputField
            passwordInput: InputField
            OnClickLogin()
            OnClickRegister()

        }

        class MenuManager{
            + instance: MenuManager$
            + menus: Menu[]
            Awake() void
            OpenMenu(string MenuName) void
            OpenMenu(Menu menu) void
            CloseMenu(Menu menu) void
        }
    }
    namespace FrontEnd{


        class Player{
            <<Prefab>>
            class Rigidbody 2D
            class Box Collider 2D
            class PlayerStats
            class Movement
            class Animator
            class Normal Attack
            class Rising Attack
        }

        class PlayerController{
            -Hitbox: Hitbox
            -Hurtbox: Hurtbox
            GetInput()
            GetCharacter()
            GetStats()
            GetSprite()
        }

        class EnemyController{
            -Hitbox: Hitbox
            -Hurtbox: Hurtbox
            GetStats()
            GetSprite()
        }

        class UIManager{
            DisplayHealth()
            DisplayExperience()
            DisplayLevel()
            UpdateDisplay()
        }

        class CharacterStat{
            +BaseValue: float
            +Value: float
            -StatModifiers: List<StatModifier>
            IncreaseStat(int amt): void
            DecreaseStat(int amt): void
            AddModifier(StatModifier Mod): void
            RemoveModifier(StatModifier Mod): bool
            CalculateFinalValue(): float
        }

        class EnemyStats{
            +Health: CharacterStat
            +Strength: CharacterStat
            +Speed: CharacterStat
        }

        class PlayerStats{
            +Health: CharacterStat
            +Strength: CharacterStat
            +Speed: CharacterStat
            TakeDamage(int damageTaken): void
            Heal(int amountHealed): void
            Die(): void
            HandleLevelUp(int level): void 
        }
    }
```

# Front End
We need to add a front end UML that shows the main menu being a child of a canvas, which is a child of a scene, etc

#### To see a visual depiction of each component and their interfaces please see our System Block Diagram [here](https://capstone-projects-2024-spring.github.io/project-rpg-elements-game/docs/requirements/system-block-diagram).
