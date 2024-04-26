"use strict";(self.webpackChunkcreate_project_docs=self.webpackChunkcreate_project_docs||[]).push([[6863],{84652:(e,n,t)=>{t.r(n),t.d(n,{assets:()=>l,contentTitle:()=>r,default:()=>h,frontMatter:()=>s,metadata:()=>o,toc:()=>c});var a=t(85893),i=t(11151);const s={sidebar_position:2},r=void 0,o={id:"system-architecture/Architecture",title:"Architecture",description:"Unity (Game Engine)",source:"@site/docs/system-architecture/Architecture.md",sourceDirName:"system-architecture",slug:"/system-architecture/Architecture",permalink:"/project-rpg-elements-game/docs/system-architecture/Architecture",draft:!1,unlisted:!1,editUrl:"https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/edit/main/documentation/docs/system-architecture/Architecture.md",tags:[],version:"current",lastUpdatedBy:"Theron Halsey",sidebarPosition:2,frontMatter:{sidebar_position:2},sidebar:"docsSidebar",previous:{title:"Algorithms",permalink:"/project-rpg-elements-game/docs/system-architecture/Algorithms"},next:{title:"Development Environment",permalink:"/project-rpg-elements-game/docs/system-architecture/Development-Environment"}},l={},c=[{value:"Unity (Game Engine)",id:"unity-game-engine",level:3},{value:"Interfaces (Data Sent)",id:"interfaces-data-sent",level:4},{value:"Firebase (Real-time Database &amp; User Authentication)",id:"firebase-real-time-database--user-authentication",level:3},{value:"Interfaces (Data Sent)",id:"interfaces-data-sent-1",level:4},{value:"Photon (Networking Solution)",id:"photon-networking-solution",level:3},{value:"Interfaces (Data Sent)",id:"interfaces-data-sent-2",level:4},{value:"To see a visual depiction of each component and their interfaces please see our System Block Diagram here.",id:"to-see-a-visual-depiction-of-each-component-and-their-interfaces-please-see-our-system-block-diagram-here",level:4}];function d(e){const n={a:"a",h1:"h1",h3:"h3",h4:"h4",li:"li",mermaid:"mermaid",p:"p",strong:"strong",ul:"ul",...(0,i.a)(),...e.components};return(0,a.jsxs)(a.Fragment,{children:[(0,a.jsx)(n.h3,{id:"unity-game-engine",children:"Unity (Game Engine)"}),"\n",(0,a.jsx)(n.p,{children:"Unity will be the hub for all of the user data."}),"\n",(0,a.jsx)(n.h4,{id:"interfaces-data-sent",children:"Interfaces (Data Sent)"}),"\n",(0,a.jsxs)(n.ul,{children:["\n",(0,a.jsxs)(n.li,{children:[(0,a.jsx)(n.strong,{children:"Firebase Real-time Database"}),"\n",(0,a.jsxs)(n.ul,{children:["\n",(0,a.jsx)(n.li,{children:"Lobby Messages"}),"\n",(0,a.jsx)(n.li,{children:"New Friends' IDs"}),"\n",(0,a.jsx)(n.li,{children:"Credentials (Authentication)"}),"\n"]}),"\n"]}),"\n",(0,a.jsxs)(n.li,{children:[(0,a.jsx)(n.strong,{children:"Photon (Multiplayer Matchmaking)"}),"\n",(0,a.jsxs)(n.ul,{children:["\n",(0,a.jsx)(n.li,{children:"Networked lobby system"}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,a.jsx)(n.h3,{id:"firebase-real-time-database--user-authentication",children:"Firebase (Real-time Database & User Authentication)"}),"\n",(0,a.jsx)(n.p,{children:"Firebase will be used to create a customizable user authentication system, as well as a real-time database for friends' lists/user messages. After logging in with Firebase, Photon will need its stored user data like a static UserID, friends list, and retained chat messages. Photon matchmaking will use this data for sending/receiving friends' game invites and displaying gamertags in lobby."}),"\n",(0,a.jsx)(n.h4,{id:"interfaces-data-sent-1",children:"Interfaces (Data Sent)"}),"\n",(0,a.jsxs)(n.ul,{children:["\n",(0,a.jsxs)(n.li,{children:[(0,a.jsx)(n.strong,{children:"Photon"}),"\n",(0,a.jsxs)(n.ul,{children:["\n",(0,a.jsx)(n.li,{children:"Authentication Approval/Denial"}),"\n",(0,a.jsx)(n.li,{children:"Restore Previous Chat Messages"}),"\n",(0,a.jsx)(n.li,{children:"Retrieve Friends' List"}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,a.jsx)(n.h3,{id:"photon-networking-solution",children:"Photon (Networking Solution)"}),"\n",(0,a.jsx)(n.p,{children:"Photon is a real-time cloud Networking solution that is used for room-based multiplayer and matchmaking. It can be used to create a lobby for players to invite friends, randomly search for a game, or search through a parameterized list."}),"\n",(0,a.jsx)(n.h4,{id:"interfaces-data-sent-2",children:"Interfaces (Data Sent)"}),"\n",(0,a.jsxs)(n.ul,{children:["\n",(0,a.jsxs)(n.li,{children:[(0,a.jsx)(n.strong,{children:"FireBase"}),"\n",(0,a.jsxs)(n.ul,{children:["\n",(0,a.jsx)(n.li,{children:"Other Users' game state"}),"\n",(0,a.jsx)(n.li,{children:"Messages From Other Users"}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,a.jsx)(n.mermaid,{value:"classDiagram\n\n    Player o-- PlayerController\n    Player o-- PlayerStats\n    Player -- UIManager\n    EnemyController o-- EnemyStats\n    CharacterStat -- EnemyStats\n    CharacterStat -- PlayerStats\n\n    Firebase o-- ChatMessenger\n    Firebase o-- UserAuthentication\n    Firebase o-- FriendsListManager\n    LoginManager --o Firebase\n\n\n    Photon o-- Launcher\n    Photon o-- QuickMatch\n    Mirror ..> Photon\n    Mirror *-- NetworkManager\n    NetworkManager --\x3e KCP Transport\n    Launcher -- FriendsListManager\n    Launcher ..> MenuManager\n    namespace BackEnd{\n        class Mirror{\n            NetworkManager: class\n        }\n\n        class NetworkManager{\n            <<Mirror Component>>\n            KCP Transport: Component\n            Gary: Prefab\n        }\n\n        class KCP Transport{\n            <<Component>>\n            + FastResend: int\n            + ReceiveWindowSize: uint\n            + SendWindowSize: uint\n            # server: KcpServer\n            # client: KcpClient\n        }\n\n        class Photon{\n            Launcher: class\n            QuickMatch: class\n        }\n\n        class Launcher{\n            + roomNameInputField: InputField\n            + roomNameText: roomNameText\n            + roomListContent: Transform\n            + roomListItemPrefab: GameObject\n            Awake() void\n            Start() void\n            OnConnectedToMaster() void\n            OnJoinedLobby() void\n            CreateRoom() void\n            OnJoinedRoom() void\n            OnMasterClientSwitched(Player newMasterClient) void\n            JoinRoom() void\n            StartGame() void\n            LeaveRoom() void\n            OnLeftRoom() void\n            OnRoomListUpdate() void\n            OnPlayerEnteredRoom() void\n            InviteFriendToRoom(Friend friend) void\n            JoinFriendRoom(Friend friend) void\n        }\n\n        class QuickMatch{\n            Start() void\n            QuickMatch() void\n            OnConnectedToMaster() void\n            OnJoinRandomFailed(short returnCode, string message) void\n            OnJoinedRoom() void\n        }\n\n        class Firebase{\n            ChatMessenger: class\n            UserAuthentication: class\n            FriendsListManager: class\n        }\n\n        class ChatMessenger{\n            returnChatlogs()\n\n        }\n\n        class UserAuthentication{\n            register()\n            login()\n            logout()\n        }\n\n        class FriendsListManager{\n            + friendsList: FriendsList\n            addFriend(ID friend)\n            removeFriend(ID friend)\n            getFriends() FriendsList\n        }\n\n        class LoginManager{\n            usernameInput: InputField\n            passwordInput: InputField\n            OnClickLogin()\n            OnClickRegister()\n\n        }\n\n        class MenuManager{\n            + instance: MenuManager$\n            + menus: Menu[]\n            Awake() void\n            OpenMenu(string MenuName) void\n            OpenMenu(Menu menu) void\n            CloseMenu(Menu menu) void\n        }\n    }\n    namespace FrontEnd{\n\n\n        class Player{\n            <<Prefab>>\n            class Rigidbody 2D\n            class Box Collider 2D\n            class PlayerStats\n            class Movement\n            class Animator\n            class Normal Attack\n            class Rising Attack\n        }\n\n        class PlayerController{\n            -Hitbox: Hitbox\n            -Hurtbox: Hurtbox\n            GetInput()\n            GetCharacter()\n            GetStats()\n            GetSprite()\n        }\n\n        class EnemyController{\n            -Hitbox: Hitbox\n            -Hurtbox: Hurtbox\n            GetStats()\n            GetSprite()\n        }\n\n        class UIManager{\n            DisplayHealth()\n            DisplayExperience()\n            DisplayLevel()\n            UpdateDisplay()\n        }\n\n        class CharacterStat{\n            +BaseValue: float\n            +Value: float\n            -StatModifiers: List<StatModifier>\n            IncreaseStat(int amt): void\n            DecreaseStat(int amt): void\n            AddModifier(StatModifier Mod): void\n            RemoveModifier(StatModifier Mod): bool\n            CalculateFinalValue(): float\n        }\n\n        class EnemyStats{\n            +Health: CharacterStat\n            +Strength: CharacterStat\n            +Speed: CharacterStat\n        }\n\n        class PlayerStats{\n            +Health: CharacterStat\n            +Strength: CharacterStat\n            +Speed: CharacterStat\n            TakeDamage(int damageTaken): void\n            Heal(int amountHealed): void\n            Die(): void\n            HandleLevelUp(int level): void \n        }\n    }"}),"\n",(0,a.jsx)(n.h1,{id:"front-end",children:"Front End"}),"\n",(0,a.jsx)(n.p,{children:"We need to add a front end UML that shows the main menu being a child of a canvas, which is a child of a scene, etc"}),"\n",(0,a.jsxs)(n.h4,{id:"to-see-a-visual-depiction-of-each-component-and-their-interfaces-please-see-our-system-block-diagram-here",children:["To see a visual depiction of each component and their interfaces please see our System Block Diagram ",(0,a.jsx)(n.a,{href:"https://capstone-projects-2024-spring.github.io/project-rpg-elements-game/docs/requirements/system-block-diagram",children:"here"}),"."]})]})}function h(e={}){const{wrapper:n}={...(0,i.a)(),...e.components};return n?(0,a.jsx)(n,{...e,children:(0,a.jsx)(d,{...e})}):d(e)}},11151:(e,n,t)=>{t.d(n,{Z:()=>o,a:()=>r});var a=t(67294);const i={},s=a.createContext(i);function r(e){const n=a.useContext(s);return a.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function o(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(i):e.components||i:r(e.components),a.createElement(s.Provider,{value:n},e.children)}}}]);