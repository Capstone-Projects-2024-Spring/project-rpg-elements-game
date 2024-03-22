"use strict";(self.webpackChunkcreate_project_docs=self.webpackChunkcreate_project_docs||[]).push([[6863],{84652:(e,n,t)=>{t.r(n),t.d(n,{assets:()=>l,contentTitle:()=>r,default:()=>h,frontMatter:()=>i,metadata:()=>o,toc:()=>c});var s=t(85893),a=t(11151);const i={sidebar_position:2},r=void 0,o={id:"system-architecture/Architecture",title:"Architecture",description:"Unity (Game Engine)",source:"@site/docs/system-architecture/Architecture.md",sourceDirName:"system-architecture",slug:"/system-architecture/Architecture",permalink:"/project-rpg-elements-game/docs/system-architecture/Architecture",draft:!1,unlisted:!1,editUrl:"https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/edit/main/documentation/docs/system-architecture/Architecture.md",tags:[],version:"current",lastUpdatedBy:"Alex McGinn",sidebarPosition:2,frontMatter:{sidebar_position:2},sidebar:"docsSidebar",previous:{title:"Algorithms",permalink:"/project-rpg-elements-game/docs/system-architecture/Algorithms"},next:{title:"Development Environment",permalink:"/project-rpg-elements-game/docs/system-architecture/Development-Environment"}},l={},c=[{value:"Unity (Game Engine)",id:"unity-game-engine",level:3},{value:"Interfaces (Data Sent)",id:"interfaces-data-sent",level:4},{value:"Firebase (Real-time Database &amp; User Authentication)",id:"firebase-real-time-database--user-authentication",level:3},{value:"Interfaces (Data Sent)",id:"interfaces-data-sent-1",level:4},{value:"Photon (Networking Solution)",id:"photon-networking-solution",level:3},{value:"Interfaces (Data Sent)",id:"interfaces-data-sent-2",level:4},{value:"To see a visual depiction of each component and their interfaces please see our System Block Diagram here.",id:"to-see-a-visual-depiction-of-each-component-and-their-interfaces-please-see-our-system-block-diagram-here",level:4}];function d(e){const n={a:"a",h3:"h3",h4:"h4",li:"li",mermaid:"mermaid",p:"p",strong:"strong",ul:"ul",...(0,a.a)(),...e.components};return(0,s.jsxs)(s.Fragment,{children:[(0,s.jsx)(n.h3,{id:"unity-game-engine",children:"Unity (Game Engine)"}),"\n",(0,s.jsx)(n.p,{children:"Unity will provide the main functionalities of the game. The Unity Editor allows us to import sprites, create scenes, animations, and attach scripts (some predefined). These scripts will be added to our in-game components within Unity and allow us to create physics for our sprites, react to player input, and generate our map procedurally."}),"\n",(0,s.jsx)(n.h4,{id:"interfaces-data-sent",children:"Interfaces (Data Sent)"}),"\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsxs)(n.li,{children:[(0,s.jsx)(n.strong,{children:"Firebase Real-time Database"}),"\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Lobby Messages"}),"\n",(0,s.jsx)(n.li,{children:"New Friends' IDs"}),"\n",(0,s.jsx)(n.li,{children:"Credentials (Authentication)"}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:[(0,s.jsx)(n.strong,{children:"Photon (Multiplayer)"}),"\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"In-game messages"}),"\n",(0,s.jsx)(n.li,{children:"Current game state"}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.mermaid,{value:"classDiagram\n\n    Unity o-- PlayerController\n    Unity o-- EnemyController\n    Unity o-- UIManager\n    LoginManager --o Unity\n    MainMenuManager --o Unity\n    LobbyManager --o Unity\n\n\n    class Unity{\n        PlayerController: class\n        EnemyController: class\n        GameManager: class\n        LoginManager: class\n        MainMenuManager: class\n        LobbyManager: class\n\n    }\n\n    class LobbyManager{\n        CreateLobby() void\n        JoinLobby() void\n        SetDifficulty() void\n    }\n\n    class LoginManager{\n        usernameInput: InputField\n        passwordInput: InputField\n        OnClickLogin()\n        OnClickRegister()\n\n    }\n\n    class MainMenuManager{\n        OnClickTutorial()\n        OnClickCreateLobby()\n        OnClickFriendsList()\n        OnClickExit()\n    }\n\n    class PlayerController{\n        -Hitbox: Hitbox\n        -Hurtbox: Hurtbox\n        GetInput()\n        GetCharacter()\n        GetStats()\n        GetSprite()\n    }\n\n    class EnemyController{\n        -Hitbox: Hitbox\n        -Hurtbox: Hurtbox\n        GetStats()\n        GetSprite()\n    }\n\n    class UIManager{\n        DisplayHealth()\n        DisplayExperience()\n        DisplayLevel()\n        UpdateDisplay()\n    }"}),"\n",(0,s.jsx)(n.h3,{id:"firebase-real-time-database--user-authentication",children:"Firebase (Real-time Database & User Authentication)"}),"\n",(0,s.jsx)(n.p,{children:"Firebase will be used to create a customizable user authentication system, as well as a real-time database for friends' lists/user messages, and game invites. Firebase (Blaze Plan) can also react to in game events, to provide features like achievements, if we would like to upgrade our service. Firebase will interface with Unity to provide these functionalities."}),"\n",(0,s.jsx)(n.h4,{id:"interfaces-data-sent-1",children:"Interfaces (Data Sent)"}),"\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsxs)(n.li,{children:[(0,s.jsx)(n.strong,{children:"Unity"}),"\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Authentication Approval/Denial"}),"\n",(0,s.jsx)(n.li,{children:"Restore Previous Chat Messages"}),"\n",(0,s.jsx)(n.li,{children:"Retrieve Friends' List"}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.mermaid,{value:"classDiagram\n\nFirebase o-- ChatMessenger\nFirebase o-- UserAuthentication\nFirebase o-- AchievementTracker\nFirebase o-- FriendsListManager\n\nclass Firebase{\n    ChatMessenger: class\n    UserAuthentication: class\n    AchievementTracker: class\n    FriendsListManager: class\n\n}\n\nclass ChatMessenger{\n    returnChatlogs()\n\n}\n\nclass UserAuthentication{\n    register()\n    login()\n    logout()\n}\n\nclass AchievementTracker{\n    achievements()\n    getProgress()\n    setCompletion()\n\n}\n\nclass FriendsListManager{\n    addFriend()\n    removeFriend()\n    getFriends()\n    %%impossible^^\n}"}),"\n",(0,s.jsx)(n.h3,{id:"photon-networking-solution",children:"Photon (Networking Solution)"}),"\n",(0,s.jsx)(n.p,{children:"Photon is a real-time cloud Networking solution that is used for room-based multiplayer. It can be used to create a lobby for players to invite friends, randomly search for a game, or search through a parameterized list. It also provides in game chat through text/voice to provide a more social experience to the game. As UDP is the preferred connection protocol for multiplayer games we will most likely use this. Suggested port nubmers for UDP Client connections to the Game Server are 5056 or 27002 from Photon's documentation."}),"\n",(0,s.jsx)(n.h4,{id:"interfaces-data-sent-2",children:"Interfaces (Data Sent)"}),"\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsxs)(n.li,{children:[(0,s.jsx)(n.strong,{children:"Unity"}),"\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Other Users' game state"}),"\n",(0,s.jsx)(n.li,{children:"Messages From Other Users"}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.mermaid,{value:"classDiagram\n\nPhoton o-- Matchmaking\nPhoton o-- Multiplayer\nPhoton o-- InGameMessage\nPhoton o-- Network\n\nclass Photon{\n    Matchmaking: class\n    Multiplayer: class\n    Network: class\n    InGameMessage: class\n}\n\nclass Matchmaking{\n    + userID: String\n    + lobbyUserIDs: List~String~\n    createLobby()\n    joinRandomGame()\n}\n\nclass Multiplayer{\n    + userID: String\n    + lobbyUserIDs: List~String~\n    startMultiplayer()\n    sendSharedState()\n    getSharedState()\n}\n\nclass Network{\n    ConnectToPhotonServer()\n}\n\nclass InGameMessage{\n    + chatLogs: List~String~\n    sendMessage()\n}"}),"\n",(0,s.jsxs)(n.h4,{id:"to-see-a-visual-depiction-of-each-component-and-their-interfaces-please-see-our-system-block-diagram-here",children:["To see a visual depiction of each component and their interfaces please see our System Block Diagram ",(0,s.jsx)(n.a,{href:"https://capstone-projects-2024-spring.github.io/project-rpg-elements-game/docs/requirements/system-block-diagram",children:"here"}),"."]})]})}function h(e={}){const{wrapper:n}={...(0,a.a)(),...e.components};return n?(0,s.jsx)(n,{...e,children:(0,s.jsx)(d,{...e})}):d(e)}},11151:(e,n,t)=>{t.d(n,{Z:()=>o,a:()=>r});var s=t(67294);const a={},i=s.createContext(a);function r(e){const n=s.useContext(i);return s.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function o(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(a):e.components||a:r(e.components),s.createElement(i.Provider,{value:n},e.children)}}}]);