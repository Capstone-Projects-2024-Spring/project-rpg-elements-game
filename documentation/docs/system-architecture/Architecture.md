---
sidebar_position: 2
---

### Unity (Game Engine)
Unity will provide the main functionalities of the game. The Unity Editor allows us to import sprites, create scenes, animations, and attach scripts (some predefined). These scripts will be added to our in-game components within Unity and allow us to create physics for our sprites, react to player input, and generate our map procedurally. 
#### Interfaces (Data Sent)
* **Firebase Real-time Database**
    * Lobby Messages
    * New Friends' IDs
    * Credentials (Authentication)
* **Photon (Multiplayer)**
    * In-game messages
    * Current game state
```mermaid
classDiagram

    Unity o-- PlayerController
    Unity o-- EnemyController
    Unity o-- UIManager
    LoginManager --o Unity
    MainMenuManager --o Unity
    LobbyManager --o Unity


    class Unity{
        PlayerController: class
        EnemyController: class
        GameManager: class
        LoginManager: class
        MainMenuManager: class
        LobbyManager: class

    }

    class LobbyManager{
        CreateLobby() void
        JoinLobby() void
        SetDifficulty() void
    }

    class LoginManager{
        usernameInput: InputField
        passwordInput: InputField
        OnClickLogin()
        OnClickRegister()

    }

    class MainMenuManager{
        OnClickTutorial()
        OnClickCreateLobby()
        OnClickFriendsList()
        OnClickExit()
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
```
### Firebase (Real-time Database & User Authentication)
Firebase will be used to create a customizable user authentication system, as well as a real-time database for friends' lists/user messages, and game invites. Firebase (Blaze Plan) can also react to in game events, to provide features like achievements, if we would like to upgrade our service. Firebase will interface with Unity to provide these functionalities.
#### Interfaces (Data Sent)
* **Unity**
    * Authentication Approval/Denial
    * Restore Previous Chat Messages
    * Retrieve Friends' List
```mermaid
classDiagram

Firebase o-- ChatMessenger
Firebase o-- UserAuthentication
Firebase o-- AchievementTracker
Firebase o-- FriendsListManager

class Firebase{
    ChatMessenger: class
    UserAuthentication: class
    AchievementTracker: class
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

class AchievementTracker{
    achievements()
    getProgress()
    setCompletion()

}

class FriendsListManager{
    addFriend()
    removeFriend()
    getFriends()
    %%impossible^^
}
```

### Photon (Networking Solution)
Photon is a real-time cloud Networking solution that is used for room-based multiplayer. It can be used to create a lobby for players to invite friends, randomly search for a game, or search through a parameterized list. It also provides in game chat through text/voice to provide a more social experience to the game. As UDP is the preferred connection protocol for multiplayer games we will most likely use this. Suggested port nubmers for UDP Client connections to the Game Server are 5056 or 27002 from Photon's documentation.
#### Interfaces (Data Sent)
* **Unity**
    * Other Users' game state
    * Messages From Other Users


```mermaid
classDiagram

Photon o-- Matchmaking
Photon o-- Multiplayer
Photon o-- InGameMessage
Photon o-- Network

class Photon{
    Matchmaking: class
    Multiplayer: class
    Network: class
    InGameMessage: class
}

class Matchmaking{
    + userID: String
    + lobbyUserIDs: List~String~
    createLobby()
    joinRandomGame()
}

class Multiplayer{
    + userID: String
    + lobbyUserIDs: List~String~
    startMultiplayer()
    sendSharedState()
    getSharedState()
}

class Network{
    ConnectToPhotonServer()
}

class InGameMessage{
    + chatLogs: List~String~
    sendMessage()
}
```
#### To see a visual depiction of each component and their interfaces please see our System Block Diagram [here](https://capstone-projects-2024-spring.github.io/project-rpg-elements-game/docs/requirements/system-block-diagram).
