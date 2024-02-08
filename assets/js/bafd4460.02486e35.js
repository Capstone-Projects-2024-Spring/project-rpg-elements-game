"use strict";(self.webpackChunkcreate_project_docs=self.webpackChunkcreate_project_docs||[]).push([[9617],{80134:(e,n,t)=>{t.r(n),t.d(n,{assets:()=>o,contentTitle:()=>l,default:()=>d,frontMatter:()=>s,metadata:()=>a,toc:()=>c});var i=t(85893),r=t(3905);const s={sidebar_position:4},l="Features and Requirements",a={id:"requirements/features-and-requirements",title:"Features and Requirements",description:"Functional Requirements",source:"@site/docs/requirements/features-and-requirements.md",sourceDirName:"requirements",slug:"/requirements/features-and-requirements",permalink:"/project-rpg-elements-game/docs/requirements/features-and-requirements",draft:!1,unlisted:!1,editUrl:"https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/edit/main/documentation/docs/requirements/features-and-requirements.md",tags:[],version:"current",lastUpdatedBy:"tun50126",sidebarPosition:4,frontMatter:{sidebar_position:4},sidebar:"docsSidebar",previous:{title:"General Requirements",permalink:"/project-rpg-elements-game/docs/requirements/general-requirements"},next:{title:"Use-case descriptions",permalink:"/project-rpg-elements-game/docs/requirements/use-case-descriptions"}},o={},c=[{value:"Functional Requirements",id:"functional-requirements",level:2},{value:"Nonfunctional Requirements",id:"nonfunctional-requirements",level:2}];function h(e){const n={h1:"h1",h2:"h2",li:"li",ul:"ul",...(0,r.ah)(),...e.components};return(0,i.jsxs)(i.Fragment,{children:[(0,i.jsx)(n.h1,{id:"features-and-requirements",children:"Features and Requirements"}),"\n",(0,i.jsx)(n.h2,{id:"functional-requirements",children:"Functional Requirements"}),"\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsxs)(n.li,{children:["Characters \u2013 Users have the ability to choose from a cast of characters. These characters feature different combos and skills, defining the class system.","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"At least four different characters/classes will be available."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Movement System (Player Controller) - Players have diverse movement controls in which they can combine inputs to perform various attacks and skills. In addition to this, the player can interact with the environment by wall jumping and linear dashes.","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Player sprites will not have collision with one another."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Enemy AI (AI Controller) - The enemy AI will be simple yet diverse.","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsxs)(n.li,{children:["Simple Track","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsxs)(n.li,{children:["Ground","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Enemy will attempt to collide with the player's hurt box."}),"\n",(0,i.jsx)(n.li,{children:"Enemy will stand a fixed distance away from the player, colliding a hitbox (either melee or a projectile) against the player's hurt box at certain intervals."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Flying","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"They are capable of navigating around terrain and feature attack patterns similar to ground but are not limited by gravity."}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Directional Charge","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Some standard enemies will have the ability to do a linear dash towards. the player, dealing damage upon collision, but can also be canceled if a hit box collides with them before contact."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Boss","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Each unique biome has a separate boss."}),"\n",(0,i.jsx)(n.li,{children:"Bosses feature a more diverse skillset and may choose between its attacks based on proximity from player."}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Attributes \u2013 Statistics that determine how much damage a player deals, their game speed, and how much health are dictated by attributes.","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Speed \u2013 How fast the player moves."}),"\n",(0,i.jsx)(n.li,{children:"Attack \u2013 How much damage is dealt."}),"\n",(0,i.jsx)(n.li,{children:"Defense \u2013 How much damage will be reduced when getting hit."}),"\n",(0,i.jsx)(n.li,{children:"Health \u2013 How much damage the player can take."}),"\n"]}),"\n"]}),"\n",(0,i.jsx)(n.li,{children:"Environment \u2013 The play area will be procedurally generated. The environment will feature different biomes associated with different bosses."}),"\n",(0,i.jsxs)(n.li,{children:["UI","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsxs)(n.li,{children:["Menu","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsxs)(n.li,{children:["Tutorial","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"This opens a prefabricated level in which the player may learn and experiment with the in-game systems."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Create Lobby","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Upon lobby creation a share code will be generated to invite other players."}),"\n",(0,i.jsx)(n.li,{children:"Users can begin the game, choose the number of players, and play online with up to three friends, or play alone."}),"\n",(0,i.jsx)(n.li,{children:'Within the lobby, the player may actively switch their character until they select the "Ready" button.'}),"\n",(0,i.jsx)(n.li,{children:'After clicking the "Ready" button all other options will be deactivated unless they "Unready" themselves.'}),"\n",(0,i.jsx)(n.li,{children:"The host may start the game after all players in the lobby designate themselves as ready."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Join Lobby","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Clicking the Join Lobby button will prompt the user with a text field in which they may type a code that will connect them to a lobby."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Settings","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"A settings menu will appear that allows the user to adjust various options for the sake of gameplay experience."}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Warping","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Players should be able to warp to the location of other users (For example, if one user finds a boss and another user wants to help)."}),"\n",(0,i.jsx)(n.li,{children:"Should have cooldown on it, and the warping itself shouldn't happen instantaneously."}),"\n"]}),"\n"]}),"\n",(0,i.jsx)(n.li,{children:"Difficulty scaling \u2013 The number of enemies and their attributes can be scaled to change how hard the game is."}),"\n",(0,i.jsxs)(n.li,{children:["In-game Overlay","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsxs)(n.li,{children:["Experience","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Experience is granted upon defeating an enemy or completing tasks."}),"\n",(0,i.jsx)(n.li,{children:"Experience is shared across all members of the group."}),"\n",(0,i.jsx)(n.li,{children:"A bar will be present that dictates a percentage of experience left to attain the next level. This bar will be present beneath the level indicator."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Level","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"An integer value that determines the groups statistics will be permanently visible in the corner of the screen."}),"\n",(0,i.jsx)(n.li,{children:"Gaining levels gives the players attribute points."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Attributes Window","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"A key bind may be pressed to open the attribute window."}),"\n",(0,i.jsx)(n.li,{children:"The attribute window will allow the player to increment their stats."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Health","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Health is fixed above the player's sprite."}),"\n",(0,i.jsx)(n.li,{children:"If the character's health is full, that character's health will not be visible."}),"\n"]}),"\n"]}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Equipment","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Players may purchase various equipment that can increase or decrease their attributes."}),"\n"]}),"\n"]}),"\n",(0,i.jsx)(n.li,{children:"Input: Game is playable via a keyboard."}),"\n",(0,i.jsx)(n.li,{children:"Players will be able to send chat messages."}),"\n",(0,i.jsx)(n.li,{children:"Friends list functionality handles the ability to see online players and send invites."}),"\n",(0,i.jsx)(n.li,{children:"Players will be able to obtain achievements through completing miscellaneous tasks."}),"\n"]}),"\n",(0,i.jsx)(n.h2,{id:"nonfunctional-requirements",children:"Nonfunctional Requirements"}),"\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsxs)(n.li,{children:["Custom character sprites","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Characters as well as their move sets are fabricated."}),"\n",(0,i.jsx)(n.li,{children:"Character sprite clothing is modifiable by the player via choosing prefabricated clothing."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Custom environment sprites","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Environment uses background and entities that are designed for this project."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Custom sound design & music","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"SFX for weapons, hit sounds, interactable objects are designed and implemented."}),"\n"]}),"\n"]}),"\n",(0,i.jsxs)(n.li,{children:["Game loads in X time","\n",(0,i.jsxs)(n.ul,{children:["\n",(0,i.jsx)(n.li,{children:"Further testing of procedural generation is required to determine a good estimate."}),"\n"]}),"\n"]}),"\n",(0,i.jsx)(n.li,{children:"Firebase authentication handles user authentication."}),"\n",(0,i.jsx)(n.li,{children:"Lobby hosting handled by either Firebase Cloud Functions or Unity Lobby."}),"\n",(0,i.jsx)(n.li,{children:"Should run at a smooth framerate on modern hardware (60 FPS)."}),"\n",(0,i.jsx)(n.li,{children:"Lag should not be frequent. Spikes of 500ms maximum."}),"\n"]})]})}function d(e={}){const{wrapper:n}={...(0,r.ah)(),...e.components};return n?(0,i.jsx)(n,{...e,children:(0,i.jsx)(h,{...e})}):h(e)}},3905:(e,n,t)=>{t.d(n,{ah:()=>c});var i=t(67294);function r(e,n,t){return n in e?Object.defineProperty(e,n,{value:t,enumerable:!0,configurable:!0,writable:!0}):e[n]=t,e}function s(e,n){var t=Object.keys(e);if(Object.getOwnPropertySymbols){var i=Object.getOwnPropertySymbols(e);n&&(i=i.filter((function(n){return Object.getOwnPropertyDescriptor(e,n).enumerable}))),t.push.apply(t,i)}return t}function l(e){for(var n=1;n<arguments.length;n++){var t=null!=arguments[n]?arguments[n]:{};n%2?s(Object(t),!0).forEach((function(n){r(e,n,t[n])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(t)):s(Object(t)).forEach((function(n){Object.defineProperty(e,n,Object.getOwnPropertyDescriptor(t,n))}))}return e}function a(e,n){if(null==e)return{};var t,i,r=function(e,n){if(null==e)return{};var t,i,r={},s=Object.keys(e);for(i=0;i<s.length;i++)t=s[i],n.indexOf(t)>=0||(r[t]=e[t]);return r}(e,n);if(Object.getOwnPropertySymbols){var s=Object.getOwnPropertySymbols(e);for(i=0;i<s.length;i++)t=s[i],n.indexOf(t)>=0||Object.prototype.propertyIsEnumerable.call(e,t)&&(r[t]=e[t])}return r}var o=i.createContext({}),c=function(e){var n=i.useContext(o),t=n;return e&&(t="function"==typeof e?e(n):l(l({},n),e)),t},h={inlineCode:"code",wrapper:function(e){var n=e.children;return i.createElement(i.Fragment,{},n)}},d=i.forwardRef((function(e,n){var t=e.components,r=e.mdxType,s=e.originalType,o=e.parentName,d=a(e,["components","mdxType","originalType","parentName"]),u=c(t),m=r,p=u["".concat(o,".").concat(m)]||u[m]||h[m]||s;return t?i.createElement(p,l(l({ref:n},d),{},{components:t})):i.createElement(p,l({ref:n},d))}));d.displayName="MDXCreateElement"}}]);