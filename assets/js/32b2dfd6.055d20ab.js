"use strict";(self.webpackChunkcreate_project_docs=self.webpackChunkcreate_project_docs||[]).push([[6070],{7780:(e,t,o)=>{o.r(t),o.d(t,{assets:()=>c,contentTitle:()=>i,default:()=>m,frontMatter:()=>a,metadata:()=>s,toc:()=>h});var r=o(85893),n=o(11151);const a={},i=void 0,s={id:"system-architecture/procedural-generation",title:"procedural-generation",description:"Procedural Generation Algorithm",source:"@site/docs/system-architecture/procedural-generation.md",sourceDirName:"system-architecture",slug:"/system-architecture/procedural-generation",permalink:"/project-rpg-elements-game/docs/system-architecture/procedural-generation",draft:!1,unlisted:!1,editUrl:"https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/edit/main/documentation/docs/system-architecture/procedural-generation.md",tags:[],version:"current",lastUpdatedBy:"Alex McGinn",frontMatter:{},sidebar:"docsSidebar",previous:{title:"Architecture",permalink:"/project-rpg-elements-game/docs/system-architecture/Architecture"},next:{title:"sequenceDiagram",permalink:"/project-rpg-elements-game/docs/system-architecture/sequenceDiagram"}},c={},h=[];function l(e){const t={p:"p",...(0,n.a)(),...e.components};return(0,r.jsxs)(r.Fragment,{children:[(0,r.jsx)(t.p,{children:"Procedural Generation Algorithm"}),"\n",(0,r.jsx)(t.p,{children:"There are currently two ideas for the algorithm that may be implemented. The first is an algorithm that was created to match how a game, Spelunky, created their map. The algorithm is a simple directional checker.\nWhat this means is that at its base it looks to find if a portion of the map can be spawned to the left or the right of the previous room. If this is the case then it will spawn a room there and continue the process until it reaches the maximum Y distance.\nThe maximum Y distance describes the \u201cheight\u201d of the map or the lower bound. If the final block spawns on the max Y block the level generation code will then stop and there should be a path from the spawn point to the end.\nHowever, this does not take any of the directional openings into account. The directional opening are simple values, 0 for a left and right room opening, 1 for a left, right, and bottom openings, 2 for a left, right, top, and bottom openings, and 3\nfor left, right, top, and bottom openings. For left and right room spawns, the room choice does not matter as no room will block the spawn, therefore the script is told to just pick a random room from zero to three. For bottom movement, the script is\ntold to choose either 2 or 3 as they have top and bottom openings."}),"\n",(0,r.jsx)(t.p,{children:"The second algorithm is an original algorithm that will be able to assign the rooms numerical values based on where the walls are then it will use graph theory to stitch them together in a way that ensures there are no inaccessible spaces."})]})}function m(e={}){const{wrapper:t}={...(0,n.a)(),...e.components};return t?(0,r.jsx)(t,{...e,children:(0,r.jsx)(l,{...e})}):l(e)}},11151:(e,t,o)=>{o.d(t,{Z:()=>s,a:()=>i});var r=o(67294);const n={},a=r.createContext(n);function i(e){const t=r.useContext(a);return r.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function s(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(n):e.components||n:i(e.components),r.createElement(a.Provider,{value:t},e.children)}}}]);