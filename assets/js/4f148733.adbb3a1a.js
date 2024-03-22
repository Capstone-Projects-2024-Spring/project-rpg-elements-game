"use strict";(self.webpackChunkcreate_project_docs=self.webpackChunkcreate_project_docs||[]).push([[3926],{52381:(e,n,i)=>{i.r(n),i.d(n,{assets:()=>h,contentTitle:()=>r,default:()=>d,frontMatter:()=>l,metadata:()=>a,toc:()=>c});var s=i(85893),t=i(11151);const l={sidebar_position:1},r="Features and Requirements",a={id:"requirements/Features-and-Requirements",title:"Features and Requirements",description:"Functional Requirements",source:"@site/docs/requirements/Features-and-Requirements.md",sourceDirName:"requirements",slug:"/requirements/Features-and-Requirements",permalink:"/project-rpg-elements-game/docs/requirements/Features-and-Requirements",draft:!1,unlisted:!1,editUrl:"https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/edit/main/documentation/docs/requirements/Features-and-Requirements.md",tags:[],version:"current",lastUpdatedBy:"Brandon",sidebarPosition:1,frontMatter:{sidebar_position:1},sidebar:"docsSidebar",previous:{title:"Requirements Specification",permalink:"/project-rpg-elements-game/docs/category/requirements-specification"},next:{title:"General Requirements",permalink:"/project-rpg-elements-game/docs/requirements/General-Requirements"}},h={},c=[{value:"Functional Requirements",id:"functional-requirements",level:2},{value:"Nonfunctional Requirements",id:"nonfunctional-requirements",level:2}];function o(e){const n={h1:"h1",h2:"h2",li:"li",ul:"ul",...(0,t.a)(),...e.components};return(0,s.jsxs)(s.Fragment,{children:[(0,s.jsx)(n.h1,{id:"features-and-requirements",children:"Features and Requirements"}),"\n",(0,s.jsx)(n.h2,{id:"functional-requirements",children:"Functional Requirements"}),"\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsxs)(n.li,{children:["The game should load each player into a large 2D world where they can explore and fight enemies using the characters they have chosen.","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:'A room with the game\'s "final boss" is randomly placed somewhere in the world. If the final boss is defeated, the game is considered complete and the main campaign is beaten.'}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.li,{children:"Lobbies \u2013 Multiplayer system allows users to generate codes that can be sent to other players to connect and play together simultaneously"}),"\n",(0,s.jsxs)(n.li,{children:["Title Screen","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Upon starting the game, the user is greeted with a title screen with at least these buttons on it:"}),"\n",(0,s.jsxs)(n.li,{children:["Tutorial","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"This opens a prefabricated level in which the player may learn and experiment with the in-game systems."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Create Lobby","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Allows the user to create a lobby. These will have codes that allows other users to join the same lobby and play together."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Join Lobby","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Allows the user to join a lobby and play together."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Login/Create Account","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Allows the user to create an account or log in if they already have one. A user can't join or create a lobby if they are not logged in."}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.li,{children:"Profile"}),"\n",(0,s.jsx)(n.li,{children:"Available after the user has logged in. They can change their name, see their friends list, and set a profile picture."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Movement System (Player Controller) - Players have diverse movement controls in which they can combine inputs to perform various attacks and skills. In addition to this, the player can interact with the environment by wall jumping and linear dashes.","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Player sprites will not have collision with one another."}),"\n",(0,s.jsx)(n.li,{children:"Basic attacks can be performed for all characters."}),"\n",(0,s.jsx)(n.li,{children:"Characters can perform skill attacks that differ from each other."}),"\n",(0,s.jsx)(n.li,{children:"Characters can jump."}),"\n",(0,s.jsx)(n.li,{children:"Wall jumps and dashes can be performed."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Characters \u2013 Users can choose from a cast of characters. These characters have different attacks and attributes.","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"At least eight different characters will be available."}),"\n",(0,s.jsx)(n.li,{children:"Characters can respawn."}),"\n",(0,s.jsx)(n.li,{children:"Characters can take damage."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Environment \u2013 The play area will be procedurally generated. The environment will feature different biomes associated with different bosses.","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"The environment will generate platforms that players can stand on."}),"\n",(0,s.jsx)(n.li,{children:"The environment supports trap generation that damages the player."}),"\n",(0,s.jsx)(n.li,{children:"Biomes will generate with different tile sets."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Enemies","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"The environment will be populated by enemies"}),"\n",(0,s.jsx)(n.li,{children:"Each enemy will try to attack the player or hinder their progress."}),"\n",(0,s.jsx)(n.li,{children:"Certain enemies will be bosses in designated rooms that take more effort to fight."}),"\n",(0,s.jsx)(n.li,{children:"When an enemy is defeated, they will give every player experience, and will give gold to the player who defeated it."}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.li,{children:"Input: Game is playable via a keyboard."}),"\n",(0,s.jsxs)(n.li,{children:["Preparations - What the user must do after creating a lobby but before starting the game session.","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"After creating a lobby, the user must select which character they will play as."}),"\n",(0,s.jsx)(n.li,{children:"Anyone who joins the lobby must also do the same thing."}),"\n",(0,s.jsx)(n.li,{children:"The creator of the lobby is in charge of starting the game session, which will spawn them into the map. The game can only start if all players who are in the lobby are done selecting a character."}),"\n",(0,s.jsx)(n.li,{children:"If someone tries joining the lobby after the session has started, they'll have to select their character before they can be spawned into the map and will automatically be the same level as the rest of the group."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Camera \u2013 Game's camera will always follow the player.","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"For each player, the game's camera will follow their character and keep them in the center of the screen."}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.h2,{id:"nonfunctional-requirements",children:"Nonfunctional Requirements"}),"\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsxs)(n.li,{children:["Attributes \u2013 Statistics that determine how much damage a player deals, their game speed, and how much health they have are dictated by attributes.","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsxs)(n.li,{children:["The main attributes each character has will be:","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsxs)(n.li,{children:["Attack","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Affects how much damage their attacks do"}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Speed","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Affects how fast they move"}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Defense","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Affects how much damage is reduced when the player gets attacked"}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Health","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Affects how much HP the player has"}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.li,{children:"Enemies will also have these same attributes"}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Level","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"An integer value that determines the groups statistics will be permanently visible in the corner of the screen."}),"\n",(0,s.jsx)(n.li,{children:"Gaining levels increases each player's attributes."}),"\n",(0,s.jsx)(n.li,{children:"Reaching certain levels will also let the player's character learn new attacks."}),"\n",(0,s.jsx)(n.li,{children:"Enemies will also have levels, which influence how high their attributes are."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Experience","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Experience is granted upon defeating an enemy or completing tasks."}),"\n",(0,s.jsx)(n.li,{children:"Experience is shared across all members of the group."}),"\n",(0,s.jsx)(n.li,{children:"A bar will be present that dictates a percentage of experience left to attain the next level. This bar will be present beneath the level indicator."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Equipment - Armor and weapons that the player can equip and dequip to change their attributes.","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Can sometimes be dropped by enemies."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Gold - In-game currency dropped by enemies. Used to buy things in shops.","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Gold is not shared between all players, unlike experience and levels. How much gold a player has is unique to them."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["HUD - The game's HUD will display the following:","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"The health of every player at the bottom of the screen."}),"\n",(0,s.jsx)(n.li,{children:"The group's level at the top left corner of the screen, as well as how much experience they've collected."}),"\n",(0,s.jsx)(n.li,{children:"How much gold the player has, displayed directly above their health bar."}),"\n",(0,s.jsx)(n.li,{children:"The health bars of enemies will and bosses will be displayed at the top of the screen when they're interacted with."}),"\n",(0,s.jsx)(n.li,{children:"The level of each enemt and boss will be displayed directly above them."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Towns - A collection of buildings with different functionalities","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"At least 4 towns will be randomly placed throughout the map, with the exception of 1 town, which is will always be in the center of the map and will be where the players spawn when starting a game."}),"\n",(0,s.jsxs)(n.li,{children:["Each town will the same 3 buildings:","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsxs)(n.li,{children:["Attack Building","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Entering this building will display a menu that allows players to equip and dequip attacks."}),"\n",(0,s.jsx)(n.li,{children:"The menu also allows players to look at information about any notable features about each of their attacks, such as how much damage they do."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Character Building","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Entering this building will display a menu that allows players to change which character they're playing as."}),"\n",(0,s.jsx)(n.li,{children:"Switching characters should not affect the user's level, and the character will know any attacks that would've been learned in all levels before and including their current level, even if the user was playing as a different character at the time."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Shop","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Where the user can buy armor and weapons using gold."}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.li,{children:"Equipping armor and weapons will also affect the user's attributes in different ways."}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.li,{children:"Enemies can never spawn near or enter a town."}),"\n",(0,s.jsx)(n.li,{children:"Reaching a town will fully heal the player."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Menus","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"At any point, the player can press a button to open a menu."}),"\n",(0,s.jsx)(n.li,{children:"Opening the menu won't pause the game."}),"\n",(0,s.jsxs)(n.li,{children:["Each menu has the following buttons:","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsxs)(n.li,{children:["Change Equipment","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"When selected, this will open a submenu to allow the user to equip and dequip armor and weapons."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Warp","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"When selected, this will open a submenu to allow the user to warp to the location of other players, as well as any towns that have been reached by any of the players."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Leave Session","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"When selected, the player will leave the lobby without closing the game."}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.li,{children:"Difficulty scaling \u2013 The number of enemies and their attributes scale with number of players but can be modified by the host."}),"\n",(0,s.jsxs)(n.li,{children:["Custom character sprites","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Characters as well as their move sets are fabricated."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Custom environment sprites","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Environment uses background and entities that are designed for this project."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Custom sound design & music","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"SFX for weapons, hit sounds, interactable objects are designed and implemented."}),"\n"]}),"\n"]}),"\n",(0,s.jsxs)(n.li,{children:["Game loads in less than 2 minutes","\n",(0,s.jsxs)(n.ul,{children:["\n",(0,s.jsx)(n.li,{children:"Further testing of procedural generation is required to determine a good estimate."}),"\n"]}),"\n"]}),"\n",(0,s.jsx)(n.li,{children:"Firebase authentication handles user authentication."}),"\n",(0,s.jsx)(n.li,{children:"Lobby hosting is handled by either Firebase Cloud Functions or Unity Lobby."}),"\n",(0,s.jsx)(n.li,{children:"Should run at a smooth framerate on modern hardware (60 FPS)."}),"\n",(0,s.jsx)(n.li,{children:"Lag should not be frequent (<500ms spikes)."}),"\n",(0,s.jsx)(n.li,{children:"Players will be able to send in-game chat messages."}),"\n",(0,s.jsx)(n.li,{children:"Friends list functionality handles the ability to see online players and send invites."}),"\n"]})]})}function d(e={}){const{wrapper:n}={...(0,t.a)(),...e.components};return n?(0,s.jsx)(n,{...e,children:(0,s.jsx)(o,{...e})}):o(e)}},11151:(e,n,i)=>{i.d(n,{Z:()=>a,a:()=>r});var s=i(67294);const t={},l=s.createContext(t);function r(e){const n=s.useContext(l);return s.useMemo((function(){return"function"==typeof e?e(n):{...n,...e}}),[n,e])}function a(e){let n;return n=e.disableParentContext?"function"==typeof e.components?e.components(t):e.components||t:r(e.components),s.createElement(l.Provider,{value:n},e.children)}}}]);