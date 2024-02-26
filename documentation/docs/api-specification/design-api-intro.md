---
sidebar_position: 1
description: What should be in this section.
---

Design Document - Part II API
=============================
<!-----



Conversion time: 2.084 seconds.


Using this Markdown file:

1. Paste this output into your source file.
2. See the notes and action items below regarding this conversion run.
3. Check the rendered output (headings, lists, code blocks, tables) for proper
   formatting and use a linkchecker before you publish this page.

Conversion notes:

* Docs to Markdown version 1.0β35
* Sun Feb 25 2024 16:46:59 GMT-0800 (PST)
* Source doc: Design Document Part 2 API
----->


***Unity***

**LoginManager**



* Class purpose: Provides the backend for the login screen UI. Uses Firebase to register and log in a user with their provided credentials of username and password.
* Data Fields:
    *  usernameInput
        * Type: InputField
        * Purpose: Used to authenticate a user’s username on Firebase
    * passwordInput
        * Type: InputField
        * Purpose: Used to authenticate a user’s password on Firebase
* Methods:
    * OnClickLogin()
        * Purpose: Verify user inputted username and password
        * Pre-Conditions: Existing username input and password input
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * usernameInput
                * Type: InputField
                * Purpose: Used to authenticate a user’s username on Firebase
            * passwordInput
                * Type: InputField
                * Purpose: Used to authenticate a user’s password on Firebase
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “InvalidLogin”
    * OnClickRegister()
        * Purpose: Create an account on Firebase using user inputted username and password
        * Pre-Conditions: N/A
        * Post-Conditions: Successful verification message
        * Parameters / Data types:  
            * usernameInput
                * Type: InputField
                * Purpose: Used to register a user’s username on Firebase
            * passwordInput
                * Type: InputField
                * Purpose: Used to register a user’s password on Firebase
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “InvalidUsername”
            * “InvalidPassword”

**MainMenuManager**



* Class purpose: The first screen the user sees upon application launch. Allows the user to navigate to the tutorial, creation of a lobby, view friends list, and exit the application. 
* Data Fields:
    * None
* Methods:
    * OnClickTutorial()
        * Purpose: Begins the tutorial for the user upon user prompt
        * Pre-Conditions: N/A
        * Post-Conditions: The user is now in the ‘tutorial’ section of the application
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
    * OnClickCreateLobby()
        * Purpose: Brings the user to the lobby screen where the user can either join or create a lobby
        * Pre-Conditions: N/A
        * Post-Conditions: The lobby screen is presented
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
    * OnClickFriendsList()
        * Purpose: Shows the user a list of their registered friends
        * Pre-Conditions: User has at least one registered friend
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
    * OnClickExit()
        * Purpose: Exits the game and closes the application for the user
        * Pre-Conditions: N/A
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”

**LobbyManager**



* Class purpose: Controls the lobby for the user, where the game can begin and other users can join the same lobby for multiplayer gameplay.
* Data Fields:
    * N/A
* Methods:
    * CreateLobby()
        * Purpose: Creates a new lobby with just the user in it and shows a code for other user invitation 
        * Pre-Conditions: N/A
        * Post-Conditions: Generate a unique lobby code
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
    * JoinLobby()
        * Purpose: Joins an existing lobby
        * Pre-Conditions: Valid lobby code
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * lobbyCode
                * Type: String
                * Purpose: Linking the user to an existing lobby with its respective lobby code
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “InvalidCode”
    * setDifficulty()
        * Purpose: Sets the difficulty for the game lobby
        * Pre-Conditions: N/A
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * diffcultyChoice
                * Type: float
                * Purpose: Controls the amount of increased stats the enemy characters have, thus increasing difficulty 
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”

**PlayerController**



* Class purpose: Controls the movement of the player decided through user interaction, and controls the looks and stats of the user’s character. 
* Data Fields:
    * Hitbox:
        * Type: Hitbox
        * Purpose: Controls contact-based interactions between player attacks and enemies
    * Hurtbox:
        * Type: Hurtbox
        * Purpose: Controls contact-based interactions between the player itself and the enemy
* Methods:
    * GetInput()
        * Purpose: Awaits user input
        * Pre-Conditions: Valid user input
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * KeyDown
                * Type: KeyDown
                * Purpose: Registers which button the user pressed for corresponding action
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “InvalidInput”
    * GetCharacter()
        * Purpose: Gets the information from the user’s character
        * Pre-Conditions: N/A
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * Character
                * Type: Player
                * Purpose: Stores information about a specific character
        * Exceptions thrown
            * “NullPointerException”
    * GetStats()
        * Purpose: Obtains the list of stats a specific character has
        * Pre-Conditions: Valid character
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * StatSheet
                * Type: PlayerStat
                * Purpose: Lists stats of a character as well as functions for increasing and decreasing of a stat
        * Exceptions thrown
            * “NullPointerException”
    * GetSprite()
        * Purpose: Obtains the sprite of a character to show to the user
        * Pre-Conditions: Valid character
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * Character
                * Type: Sprite
                * Purpose: A specific sprite state corresponding to an action the character can perform
        * Exceptions thrown
            * “NullPointerException”

**EnemyController**



* Class purpose: Controls the movement of the enemy through AI scripts and stores information of stats and sprites. 
* Data Fields:
    * Hitbox:
        * Type: Hitbox
        * Purpose: Controls contact-based interactions between enemy attacks and the player
    * Hurtbox:
        * Type: Hurtbox
        * Purpose: Controls contact-based interactions between the enemy itself and the player
* Methods:
    * GetStats()
        * Purpose: Obtains the list of stats a specific character has
        * Pre-Conditions: Valid character
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * StatSheet
                * Type: EnemyStat
                * Purpose: Lists stats of a character as well as functions for increasing and decreasing of a stat
        * Exceptions thrown
            * “NullPointerException”
    * GetSprite()
        * Purpose: Obtains the sprite of a character to show to the user
        * Pre-Conditions: Valid character
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * Character
                * Type: Sprite
                * Purpose: A specific sprite state corresponding to an action the character can perform
        * Exceptions thrown
            * “NullPointerException”

**UIManager**



* Class purpose: Controls the display of the user interface to the player. 
* Data Fields:
    * N/A
* Methods:
    * DisplayHealth()
        * Purpose: Displays the current health of the user
        * Pre-Conditions: N/A
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * userHealth
                * Type: float
                * Purpose: Stores the current user health of how many enemy hits they can take
        * Exceptions thrown
            * “NullPointerException”
    * DisplayExperience()
        * Purpose: Displays the current experience points of the user
        * Pre-Conditions: N/A
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * userExp
                * Type: float
                * Purpose: Stores the current experience points of the user
        * Exceptions thrown
            * “NullPointerException”
    * DisplayLevel()
        * Purpose: Displays the current level of the user
        * Pre-Conditions: N/A
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * userLevel
                * Type: int
                * Purpose: Shows to the user what level they are as a reflection of their progress in the game, and what their stats may look like
        * Exceptions thrown
            * “NullPointerException”
    * UpdateDisplay()
        * Purpose: Updates the information shown to the user in current UI 
        * Pre-Conditions: N/A
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”

***Firebase***

**ChatMessenger**



* Class purpose: Manages the sending and receiving of messages from other users.
* Data Fields:
    * N/A
* Methods:
    * ReturnChatlogs()
        * Purpose: Returns the history of existing chat messages so far
        * Pre-Conditions: User has an active login session
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * ChatHistory
                * Type: list&lt;String>
                * Purpose: Stores each individual chat message between users in a lobby
        * Exceptions thrown
            * “NullPointerException”
            * “InactiveSession”

**UserAuthentication**



* Class purpose: Authenticates the user on the firebase server
* Data Fields:
    * N/A
* Methods:
    * register()
        * Purpose: Registers a user’s inputted credentials
        * Pre-Conditions: Valid username and password
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * usernameInput
                * Type: InputField
                * Purpose: Used to register a user’s username on Firebase
            * passwordInput
                * Type: InputField
                * Purpose: Used to register a user’s password on Firebase
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “InvalidLogin”
    * login()
        * Purpose: Validates 
        * Pre-Conditions: Valid username and password
        * Post-Conditions: User has an active login session
        * Parameters / Data types:  
            * usernameInput
                * Type: InputField
                * Purpose: Used to validate a user’s username on Firebase
            * passwordInput
                * Type: InputField
                * Purpose: Used to validate a user’s password on Firebase
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “InvalidLogin”
    * logout()
        * Purpose: Ends the user login session
        * Pre-Conditions: User has an active login session
        * Post-Conditions: User has no active login session
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “InactiveSession”

**AchievementTracker**



* Class purpose: Track achievements earned on a user’s account
* Data Fields:
    * N/A
* Methods:
    * achievements()
        * Purpose: Return all earned achievements
        * Pre-Conditions: User has an active login session
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * achievementsList
                * Type: List&lt;String>
                * Purpose: Holds each achievement earned by a user
        * Exceptions thrown
            * “NullPointerException”
            * “InactiveSession”
            * “IndexOutOfBounds”
    * getProgress()
        * Purpose: See active progress of a user in their current game
        * Pre-Conditions: User has an active login session
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * currentProgress
                * Type: float
                * Purpose: A number representing the current progress a user has made through their game
        * Exceptions thrown
            * “NullPointerException”
    * setCompletion()
        * Purpose: Updates the user’s current progress level through their game
        * Pre-Conditions: User has an active login session
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * currentProgress
                * Type: float
                * Purpose: A number representing the current progress a user has made through their game
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “InactiveSession”

**FriendsListManager**



* Class purpose: Manages the user’s current friends
* Data Fields:
    * N/A
* Methods:
    * addFriend()
        * Purpose: Adds a friend to a user’s friends list
        * Pre-Conditions: User has an active login session
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * Account
                * Type: Account
                * Purpose: The target account to be added to the user’s friends list
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “InactiveSession”
    * removeFriend()
        * Purpose: Remove an account from a user’s friends list
        * Pre-Conditions: User has an active login session
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * Account
                * Type: Account
                * Purpose: The target account to be removed from the user’s friends list
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “InactiveSession”
    * getFriends()
        * Purpose: Returns a list of the user’s current friends on their friends list
        * Pre-Conditions: User has an active login session
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * friendsList
                * Type: List&lt;Account>
                * Purpose: A list of each account on a user’s friends list
        * Exceptions thrown
            * “NullPointerException”
            * “InactiveSession”
            * “IndexOutOfBounds”

***Photon***

**Matchmaking**



* Class purpose: Manages the lobby connection between each user’s game
* Data Fields:
    * userID
        * Type: String
        * Purpose: Holds the ID of a specific user 
    * lobbyUserIDs
        * Type: List&lt;String>
        * Purpose: List that holds each ID of every user in the lobby
* Methods:
    * createLobby()
        * Purpose: Begins a new active lobby session
        * Pre-Conditions: User has an active login session
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “InactiveSession”
    * joinRandomGame()
        * Purpose: Allows the user to join a random active lobby without requiring the input of a specific lobby code
        * Pre-Conditions: User has an active login session
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “InactiveSession”

**Multiplayer**



* Class purpose: Manages each user’s current game state and shares it with other users to create a synced game environment.
* Data Fields:
    * userID
        * Type: String
        * Purpose: Holds the ID of a specific user 
    * lobbyUserIDs
        * Type: List&lt;String>
        * Purpose: List that holds each ID of every user in the lobby
* Methods:
    * startMultiplayer()
        * Purpose: Begins the active synchronization process between user game clients
        * Pre-Conditions: User is in a lobby
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * lobbyUserIDs
                * Type: List&lt;String>
                * Purpose: The list of user IDs to share the game state with
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “IndexOutOfBounds”
    * sendSharedState()
        * Purpose: Share the current game state of a user’s client with the other users in the lobby 
        * Pre-Conditions: User is in a lobby
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * lobbyUserIDs
                * Type: List&lt;String>
                * Purpose: The list of user IDs to share the game state with
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “IndexOutOfBounds”
    * getSharedState()
        * Purpose: Receive the current game state of other users in the lobby to ensure the game state is synced for each user
        * Pre-Conditions: User is in a lobby
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”

**InGameMessage**



* Class purpose: Manages the in game chat between users in a lobby
* Data Fields:
    * chatLogs
        * Type: List&lt;String>
        * Purpose: Holds the chat message history as a list with item being a specific message
* Methods:
    * sendMessage()
        * Purpose: Sends a chat message to other users in the lobby
        * Pre-Conditions: User is in a lobby
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * Message
                * Type: String
                * Purpose: Contains the user’s message to be shared with the lobby
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
            * “IndexOutOfBounds”

**Network**



* Class purpose: Creates the connection between the user game client and the Photon server
* Data Fields:
    * N/A
* Methods:
    * connectToPhotonServer()
        * Purpose: Connect to the Photon server for multiplayer functionality
        * Pre-Conditions: User is in a lobby
        * Post-Conditions: N/A
        * Parameters / Data types:  
            * N/A
        * Return value / output variables
            * N/A
        * Exceptions thrown
            * “NullPointerException”
