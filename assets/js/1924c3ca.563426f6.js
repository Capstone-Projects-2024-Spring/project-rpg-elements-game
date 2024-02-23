"use strict";(self.webpackChunkcreate_project_docs=self.webpackChunkcreate_project_docs||[]).push([[2158],{13225:(e,a,t)=>{t.r(a),t.d(a,{assets:()=>l,contentTitle:()=>i,default:()=>d,frontMatter:()=>r,metadata:()=>c,toc:()=>o});var n=t(85893),s=t(11151);const r={sidebar_position:5},i=void 0,c={id:"system-architecture/Sequence-Diagrams",title:"Sequence-Diagrams",description:"State Diagram for Game Movement",source:"@site/docs/system-architecture/Sequence-Diagrams.md",sourceDirName:"system-architecture",slug:"/system-architecture/Sequence-Diagrams",permalink:"/project-rpg-elements-game/docs/system-architecture/Sequence-Diagrams",draft:!1,unlisted:!1,editUrl:"https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/edit/main/documentation/docs/system-architecture/Sequence-Diagrams.md",tags:[],version:"current",lastUpdatedBy:"Brian",sidebarPosition:5,frontMatter:{sidebar_position:5},sidebar:"docsSidebar",previous:{title:"Development Environment",permalink:"/project-rpg-elements-game/docs/system-architecture/Development-Environment"},next:{title:"Version Control",permalink:"/project-rpg-elements-game/docs/system-architecture/Version-Control"}},l={},o=[{value:"State Diagram for Game Movement",id:"state-diagram-for-game-movement",level:2},{value:"Use Case 1",id:"use-case-1",level:2},{value:"Single-Player Game: A new user wants to play through the game.",id:"single-player-game-a-new-user-wants-to-play-through-the-game",level:4},{value:"Use Case 2",id:"use-case-2",level:2},{value:"Procedurally Generated Map: A user wants to play through a game and have a different experience.",id:"procedurally-generated-map-a-user-wants-to-play-through-a-game-and-have-a-different-experience",level:4},{value:"Use Case 3",id:"use-case-3",level:2},{value:"A user wants to challenge themselves and increase the difficulty scale.",id:"a-user-wants-to-challenge-themselves-and-increase-the-difficulty-scale",level:4},{value:"Use Case 4",id:"use-case-4",level:2},{value:"A user wants to play the game with multiple friends.",id:"a-user-wants-to-play-the-game-with-multiple-friends",level:4}];function h(e){const a={em:"em",h2:"h2",h4:"h4",img:"img",li:"li",mermaid:"mermaid",ol:"ol",p:"p",...(0,s.a)(),...e.components};return(0,n.jsxs)(n.Fragment,{children:[(0,n.jsx)(a.h2,{id:"state-diagram-for-game-movement",children:"State Diagram for Game Movement"}),"\n",(0,n.jsx)(a.p,{children:(0,n.jsx)(a.img,{src:"https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/assets/74077655/878a32bf-9c3f-4764-ae46-dec5eac9c821",alt:"Screenshot 2024-02-18 150313"})}),"\n",(0,n.jsx)(a.p,{children:(0,n.jsx)(a.em,{children:"This state diagram details how the player can move and navigate the main game map.\nWhen idle, they have the choice of running, attacking, or jumping.\nWhile jumping, then can choose to attack while in the air, but they can not attack and then jump while they are still attacking.\nRunning is the main method of travelling the map for the user, helping them move and explore more of the game map."})}),"\n",(0,n.jsx)(a.h2,{id:"use-case-1",children:"Use Case 1"}),"\n",(0,n.jsx)(a.mermaid,{value:"sequenceDiagram\nActor User\nactivate Scene-Manager\nactivate Title-Screen\n    User ->> Title-Screen: Clicks 'Tutorial'\n    Title-Screen ->> Scene-Manager: Place user in the Tutorial-Map \n    Scene-Manager --\x3e> User: Sent to Tutorial-Map\nactivate Tutorial-Map\n    User ->> Tutorial-Map: Explores and moves around the tutorial\n    User ->> Tutorial-Map: Finishes tutorial\n    Tutorial-Map --\x3e> Scene-Manager: Send user back to Title Screen\ndeactivate Tutorial-Map\n    Scene-Manager --\x3e> User: Back to Title Screen\n    User ->> Title-Screen: Clicks 'Create Lobby'\n    Scene-Manager --\x3e> User: Send user to character select screen\n    User ->> Title-Screen: Selects character\n    User ->> Title-Screen: Clicks 'Start'\ndeactivate Title-Screen\n    Title-Screen ->> Scene-Manager: Place user in the game\n    Scene-Manager --\x3e> User: Sent to main game map\nactivate Game-Map\n    loop Main Gameplay\n    User ->> Game-Map: Defeats an enemy\n    Game-Map --\x3e> User: Earned experience points and levels up\n    User ->> Game-Map: Enters a town\n    User ->> Game-Map: Equips and removes skills\n    end\n    User ->> Game-Map: Explores and moves around the map, and finds final boss\n    User ->> Game-Map: Defeats final boss\n    Game-Map --\x3e> Scene-Manager: Send user to credits\ndeactivate Game-Map\n    Scene-Manager --\x3e> User: Puts user in credits\ndeactivate Scene-Manager"}),"\n",(0,n.jsx)(a.h4,{id:"single-player-game-a-new-user-wants-to-play-through-the-game",children:"Single-Player Game: A new user wants to play through the game."}),"\n",(0,n.jsxs)(a.ol,{children:["\n",(0,n.jsx)(a.li,{children:"The user opens the game and is treated by the home screen."}),"\n",(0,n.jsx)(a.li,{children:"The home screen has a \u201ctutorial\u201d, \u201ccreate lobby\u201d, and \u201cjoin lobby\u201d buttons. Since this is the user\u2019s first time playing the game, the user chooses \u201ctutorial\u201d."}),"\n",(0,n.jsx)(a.li,{children:"The game teaches the user about all of the main mechanics and how to play."}),"\n",(0,n.jsx)(a.li,{children:"After clearing the tutorial, the user is sent back to the title screen and clicks \u201ccreate lobby\u201d."}),"\n",(0,n.jsx)(a.li,{children:"The user selects their character. Since this is a single-player game, there is no need for them to share the lobby code, so they just select start."}),"\n",(0,n.jsx)(a.li,{children:"The user traverses through the various environments, enemies, and bosses."}),"\n",(0,n.jsx)(a.li,{children:"As the user runs through the map, they have gained experience and new move sets."}),"\n",(0,n.jsx)(a.li,{children:"The user returns to a town, where they are able to equip or remove skills."}),"\n",(0,n.jsx)(a.li,{children:"The user eventually sets back out on their adventure and finds the final boss and is strong enough to defeat it."}),"\n",(0,n.jsx)(a.li,{children:"Once the final boss is defeated, the credits roll, and the game is cleared."}),"\n"]}),"\n",(0,n.jsx)(a.h2,{id:"use-case-2",children:"Use Case 2"}),"\n",(0,n.jsx)(a.mermaid,{value:"sequenceDiagram\n    actor User\n    User ->> Main Menu: Creates a new lobby\nactivate Main Menu\n    Main Menu --\x3e> User: Sends user to Character Selection Screen\ndeactivate Main Menu\n    participant css as Character Selection Screen\n    User ->> css: Chooses a character to play as\nactivate css\n    css --\x3e> User: Sends user to main game map\ndeactivate css\n    User ->> Main Game: Explores some of the procedurely generated map\nactivate Main Game\n    User ->> Main Game: Does not enjoy the map or their character, and decides to restart\n    Main Game --\x3e> User: Sends user back to main menu\ndeactivate Main Game\n    User ->> Main Menu: Creates a new lobby\nactivate Main Menu\n    Main Menu --\x3e> User: Sends user to Character Selection Screen\ndeactivate Main Menu\n    User ->> css: Chooses a new character\nactivate css\n    css --\x3e> User: Sends user to main game map\ndeactivate css\n    User ->> Main Game: Explores a different procedurely generated map"}),"\n",(0,n.jsx)(a.h4,{id:"procedurally-generated-map-a-user-wants-to-play-through-a-game-and-have-a-different-experience",children:"Procedurally Generated Map: A user wants to play through a game and have a different experience."}),"\n",(0,n.jsxs)(a.ol,{children:["\n",(0,n.jsx)(a.li,{children:"Once loaded into the map and picked their class and character set out in the world."}),"\n",(0,n.jsx)(a.li,{children:"The user levels up and realizes they are not enjoying their class and finds the map seed confusing."}),"\n",(0,n.jsx)(a.li,{children:"The user exits to the main menu and creates a new lobby."}),"\n",(0,n.jsx)(a.li,{children:"They then go through the process of starting a new game and choosing a new character."}),"\n",(0,n.jsx)(a.li,{children:"Since the map was procedurally generated the map has completely changed and the user has a different experience."}),"\n"]}),"\n",(0,n.jsx)(a.h2,{id:"use-case-3",children:"Use Case 3"}),"\n",(0,n.jsx)(a.mermaid,{value:"sequenceDiagram\n    actor User\n    User ->> Home Screen: Starts a new lobby\nactivate Home Screen\n    Home Screen --\x3e> User: Sends user to Character Selection Screen\ndeactivate Home Screen\n    participant css as Character Selection Screen\n    User ->> css: Chooses a character and sets difficulty to the maximum\nactivate css    \n    css --\x3e> User: Sends the user to the main game map\ndeactivate css\n    User ->> Main Game: User plays the game with increased enemy stats due to difficulty\nactivate Main Game\n    User ->> Main Game: Continues play through the game until they defeat the final boss\n    Main Game --\x3e> User: Sends user to the credits and rewards an achievement for winning on the maximum difficulty\ndeactivate Main Game"}),"\n",(0,n.jsx)(a.h4,{id:"a-user-wants-to-challenge-themselves-and-increase-the-difficulty-scale",children:"A user wants to challenge themselves and increase the difficulty scale."}),"\n",(0,n.jsxs)(a.ol,{children:["\n",(0,n.jsx)(a.li,{children:"Users open the game and are greeted by the home screen."}),"\n",(0,n.jsx)(a.li,{children:"After opening the game, the host creates a lobby but does not invite any players."}),"\n",(0,n.jsx)(a.li,{children:"The user wanting to challenge themselves, increases the difficulty scale to the maximum."}),"\n",(0,n.jsx)(a.li,{children:"The user selects their class."}),"\n",(0,n.jsx)(a.li,{children:"The user starts the game and the map as well as elements load in."}),"\n",(0,n.jsx)(a.li,{children:"Compared to this player\u2019s previous runs, they find it more challenging due to there being more enemies, the enemies having more damage, and because the enemies have more health."}),"\n",(0,n.jsx)(a.li,{children:"The player carefully traverses through the environment and defeats enemies until they are strong enough to defeat the final boss."}),"\n",(0,n.jsx)(a.li,{children:"Upon defeating the final boss, the credits roll, and the game is cleared."}),"\n",(0,n.jsx)(a.li,{children:"The player gains an achievement for defeating the game on maximum difficulty."}),"\n"]}),"\n",(0,n.jsx)(a.h2,{id:"use-case-4",children:"Use Case 4"}),"\n",(0,n.jsx)(a.mermaid,{value:"sequenceDiagram\n    actor Host Player\n    Host Player ->> Home Screen: Creates a new lobby\nactivate Home Screen\nactivate Home Screen\n    Home Screen --\x3e> Host Player: Sends host player to the Character Selection Screen\ndeactivate Home Screen\n    participant css as Character Selection Screen\n    participant Main Game\n    Host Player ->> css: Chooses their character\nactivate css\n    Host Player ->> css: Copies the shown lobby code\n    actor Other Players\n    Host Player ->> Other Players: Shares lobby code with other players he wants to play with\n    Other Players ->> Home Screen: Enters their lobby code on the home screen\nactivate Home Screen\n    Home Screen --\x3e> Other Players: Sends the user to the respective lobby\ndeactivate Home Screen\ndeactivate Home Screen\n    Other Players ->> css: Chooses their character\nactivate css\n    Other Players ->> css: Clicks the 'ready' button\n    css --\x3e> Host Player: All other players are ready, so the start button can be pressed\n    Host Player ->> css: Clicks the start button\n    css --\x3e> Host Player: Sends the host player to the main game\n    css --\x3e> Other Players: Sends other players to the main game\ndeactivate css\ndeactivate css\n    Host Player ->> Main Game: Explores the game map with other players in the same map and defeats the final boss\nactivate Main Game\n    Other Players ->> Main Game: Explores the game map with other players and the host player in the same map and defeats the final boss\n    Main Game --\x3e> Host Player: Sends Host Player\n    Main Game --\x3e> Other Players: Sends other players to the credits\ndeactivate Main Game"}),"\n",(0,n.jsx)(a.h4,{id:"a-user-wants-to-play-the-game-with-multiple-friends",children:"A user wants to play the game with multiple friends."}),"\n",(0,n.jsxs)(a.ol,{children:["\n",(0,n.jsx)(a.li,{children:"Users open the game and are greeted by the home screen."}),"\n",(0,n.jsx)(a.li,{children:"After opening the game, the host chooses multiplayer and opens a lobby."}),"\n",(0,n.jsx)(a.li,{children:"Up to three other users can join the lobby using the invite code."}),"\n",(0,n.jsx)(a.li,{children:"Each user chooses their class and character."}),"\n",(0,n.jsx)(a.li,{children:"The host clicks begin after all users are ready."}),"\n",(0,n.jsx)(a.li,{children:"Each user loads into the map and can go their separate ways and play through the game."}),"\n",(0,n.jsx)(a.li,{children:"Once at least one user beats the final boss, a way to exit the game will appear."}),"\n",(0,n.jsx)(a.li,{children:"After all users go to the exit, the game will end."}),"\n"]})]})}function d(e={}){const{wrapper:a}={...(0,s.a)(),...e.components};return a?(0,n.jsx)(a,{...e,children:(0,n.jsx)(h,{...e})}):h(e)}},11151:(e,a,t)=>{t.d(a,{Z:()=>c,a:()=>i});var n=t(67294);const s={},r=n.createContext(s);function i(e){const a=n.useContext(r);return n.useMemo((function(){return"function"==typeof e?e(a):{...a,...e}}),[a,e])}function c(e){let a;return a=e.disableParentContext?"function"==typeof e.components?e.components(s):e.components||s:i(e.components),n.createElement(r.Provider,{value:a},e.children)}}}]);