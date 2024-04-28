"use strict";(self.webpackChunkcreate_project_docs=self.webpackChunkcreate_project_docs||[]).push([[1996],{99012:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>d,contentTitle:()=>a,default:()=>o,frontMatter:()=>s,metadata:()=>l,toc:()=>c});var i=n(85893),r=n(11151);const s={sidebar_position:2},a="Integration tests",l={id:"testing/integration-testing",title:"Integration tests",description:"| Test ID | Use Case | Mock Objects | Input | Results |",source:"@site/docs/testing/integration-testing.md",sourceDirName:"testing",slug:"/testing/integration-testing",permalink:"/project-rpg-elements-game/docs/testing/integration-testing",draft:!1,unlisted:!1,editUrl:"https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/edit/main/documentation/docs/testing/integration-testing.md",tags:[],version:"current",lastUpdatedBy:"Alex McGinn",sidebarPosition:2,frontMatter:{sidebar_position:2},sidebar:"docsSidebar",previous:{title:"Unit tests",permalink:"/project-rpg-elements-game/docs/testing/unit-testing"},next:{title:"Acceptance test",permalink:"/project-rpg-elements-game/docs/testing/acceptence-testing"}},d={},c=[];function h(e){const t={h1:"h1",table:"table",tbody:"tbody",td:"td",th:"th",thead:"thead",tr:"tr",...(0,r.a)(),...e.components};return(0,i.jsxs)(i.Fragment,{children:[(0,i.jsx)(t.h1,{id:"integration-tests",children:"Integration tests"}),"\n",(0,i.jsxs)(t.table,{children:[(0,i.jsx)(t.thead,{children:(0,i.jsxs)(t.tr,{children:[(0,i.jsx)(t.th,{children:"Test ID"}),(0,i.jsx)(t.th,{children:"Use Case"}),(0,i.jsx)(t.th,{children:"Mock Objects"}),(0,i.jsx)(t.th,{children:"Input"}),(0,i.jsx)(t.th,{children:"Results"})]})}),(0,i.jsxs)(t.tbody,{children:[(0,i.jsxs)(t.tr,{children:[(0,i.jsx)(t.td,{children:"1"}),(0,i.jsx)(t.td,{children:"Single-Player Game"}),(0,i.jsx)(t.td,{children:"Player"}),(0,i.jsx)(t.td,{children:"The player provides input by moving the character left or right, jumping, attacking, and any other way they can directly interact with their character and/or environment."}),(0,i.jsx)(t.td,{children:"The character moves according to the player's intended input, for example moving when the player intends the character to without delay."})]}),(0,i.jsxs)(t.tr,{children:[(0,i.jsx)(t.td,{children:"2"}),(0,i.jsx)(t.td,{children:"Procedural Map Generation"}),(0,i.jsx)(t.td,{children:"Random number generator"}),(0,i.jsx)(t.td,{children:"The necessary input is the size of the map, for example 10 by 10 map blocks."}),(0,i.jsx)(t.td,{children:"We should expect a procedurally generated map so that the player can access every map block."})]}),(0,i.jsxs)(t.tr,{children:[(0,i.jsx)(t.td,{children:"3"}),(0,i.jsx)(t.td,{children:"Changing Difficulty"}),(0,i.jsx)(t.td,{children:"Playable Characters,  Enemies,  Bosses"}),(0,i.jsx)(t.td,{children:"The host player will provide input by selecting or changing the difficulty of the game in the 'start game' menu from the options 'easy,' 'medium,' or 'hard.'"}),(0,i.jsx)(t.td,{children:"Depending on the selected difficulty, the player's characters will have different statistics in their damage output, health, speed, defense. Likewise, the number of enemies that spawn, as well as their damage output/health will vary depending on the selected difficulty."})]}),(0,i.jsxs)(t.tr,{children:[(0,i.jsx)(t.td,{children:"4"}),(0,i.jsx)(t.td,{children:"Multiplayer"}),(0,i.jsx)(t.td,{children:"Players"}),(0,i.jsx)(t.td,{children:"The user will provide input by creating a lobby and inviting people to the lobby."}),(0,i.jsx)(t.td,{children:"The expectation is that there will be multiple user that are simutaneously playing in the same game."})]}),(0,i.jsxs)(t.tr,{children:[(0,i.jsx)(t.td,{children:"5"}),(0,i.jsx)(t.td,{children:"Attacking"}),(0,i.jsx)(t.td,{children:"Players,  Enemies"}),(0,i.jsx)(t.td,{children:"The player provides input by clicking specific buttons that will allow the user to do a specific attack which will be able to interact with enemies."}),(0,i.jsx)(t.td,{children:"The characters should be able to damage and kill all enemies that they run into with different types of attacks."})]}),(0,i.jsxs)(t.tr,{children:[(0,i.jsx)(t.td,{children:"6"}),(0,i.jsx)(t.td,{children:"Skill Swap"}),(0,i.jsx)(t.td,{children:"Players,  Playable Characters"}),(0,i.jsx)(t.td,{children:"The player will be able to drag and drop abilities into their skill slots."}),(0,i.jsx)(t.td,{children:"Every character will have a unique skill set that will be able to change after leveling up."})]}),(0,i.jsxs)(t.tr,{children:[(0,i.jsx)(t.td,{children:"7"}),(0,i.jsx)(t.td,{children:"Warping"}),(0,i.jsx)(t.td,{children:"Players,  Playable Characters"}),(0,i.jsx)(t.td,{children:"The player will provide input by using a button that will prompt the user to teleport them to another user."}),(0,i.jsx)(t.td,{children:"The users should be able to teleport to other users in order to do things like group up for important fights."})]}),(0,i.jsxs)(t.tr,{children:[(0,i.jsx)(t.td,{children:"8"}),(0,i.jsx)(t.td,{children:"Tutorial"}),(0,i.jsx)(t.td,{children:"Player"}),(0,i.jsx)(t.td,{children:"The input will be the user clicking tutorial from the main menu."}),(0,i.jsx)(t.td,{children:"The result should be to be able to give the users a platform on how to play the game and learn the basics of the game."})]})]})]})]})}function o(e={}){const{wrapper:t}={...(0,r.a)(),...e.components};return t?(0,i.jsx)(t,{...e,children:(0,i.jsx)(h,{...e})}):h(e)}},11151:(e,t,n)=>{n.d(t,{Z:()=>l,a:()=>a});var i=n(67294);const r={},s=i.createContext(r);function a(e){const t=i.useContext(s);return i.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function l(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(r):e.components||r:a(e.components),i.createElement(s.Provider,{value:t},e.children)}}}]);