"use strict";(self.webpackChunkcreate_project_docs=self.webpackChunkcreate_project_docs||[]).push([[8198],{20343:(e,t,n)=>{n.r(t),n.d(t,{assets:()=>h,contentTitle:()=>a,default:()=>d,frontMatter:()=>r,metadata:()=>i,toc:()=>l});var o=n(85893),s=n(11151);const r={sidebar_position:1},a="Algorithms",i={id:"system-architecture/Algorithms",title:"Algorithms",description:"Procedural Generation Algorithm",source:"@site/docs/system-architecture/Algorithms.md",sourceDirName:"system-architecture",slug:"/system-architecture/Algorithms",permalink:"/project-rpg-elements-game/docs/system-architecture/Algorithms",draft:!1,unlisted:!1,editUrl:"https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/edit/main/documentation/docs/system-architecture/Algorithms.md",tags:[],version:"current",lastUpdatedBy:"tun50126",sidebarPosition:1,frontMatter:{sidebar_position:1},sidebar:"docsSidebar",previous:{title:"System Architecture",permalink:"/project-rpg-elements-game/docs/category/system-architecture"},next:{title:"Architecture",permalink:"/project-rpg-elements-game/docs/system-architecture/Architecture"}},h={},l=[{value:"Procedural Generation Algorithm",id:"procedural-generation-algorithm",level:2},{value:"Phase 1 \u2013 Generate an M by N Maze",id:"phase-1--generate-an-m-by-n-maze",level:2},{value:"Phase 2 \u2013 Increase Connectivity",id:"phase-2--increase-connectivity",level:2},{value:"Phase 3 \u2013 Calculate Room Types",id:"phase-3--calculate-room-types",level:2},{value:"Phase 4 \u2013 Choose Player\u2019s Starting Room and Boss Room",id:"phase-4--choose-players-starting-room-and-boss-room",level:2},{value:"Phase 5 \u2013 Build the Map",id:"phase-5--build-the-map",level:2}];function c(e){const t={h1:"h1",h2:"h2",li:"li",p:"p",ul:"ul",...(0,s.a)(),...e.components};return(0,o.jsxs)(o.Fragment,{children:[(0,o.jsx)(t.h1,{id:"algorithms",children:"Algorithms"}),"\n",(0,o.jsx)(t.h2,{id:"procedural-generation-algorithm",children:"Procedural Generation Algorithm"}),"\n",(0,o.jsx)(t.p,{children:"There are currently two ideas for the algorithm that may be implemented. The first is an algorithm that was created to match how a game, Spelunky, created their map. The algorithm is a simple directional checker.\nWhat this means is that at its base it looks to find if a portion of the map can be spawned to the left or the right of the previous room. If this is the case then it will spawn a room there and continue the process until it reaches the maximum Y distance.\nThe maximum Y distance describes the \u201cheight\u201d of the map or the lower bound. If the final block spawns on the max Y block the level generation code will then stop and there should be a path from the spawn point to the end.\nHowever, this does not take any of the directional openings into account. The directional openings are simple values, 0 for a left and right room opening, 1 for left, right, and bottom openings, 2 for left, right, top, and bottom openings, and 3\nfor left, right, top, and bottom openings. For left and right room spawns, the room choice does not matter as no room will block the spawn, therefore the script is told to just pick a random room from zero to three. For bottom movement, the script is\ntold to choose either 2 or 3 as they have top and bottom openings."}),"\n",(0,o.jsx)(t.p,{children:"The second algorithm is an original algorithm that will be able to assign the rooms numerical values based on where the walls are then it will use graph theory to stitch them together in a way that ensures there are no spaces that are inaccessible. The algorithm will follow this layout:"}),"\n",(0,o.jsx)(t.h2,{id:"phase-1--generate-an-m-by-n-maze",children:"Phase 1 \u2013 Generate an M by N Maze"}),"\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Generate an M by N lattice graph for the Rooms, call it R."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Generate an (M+1) by (N+1) lattice graph for the Walls around each room, call it W."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Give all the edges of R and random weight."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Construct a Minimum Spanning Tree (MST) from the edges of R, call it T."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Remove all the edges of W that intersect an edge of the MST of R."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"We now have a maze that ensures every room on the map is accessible via some path from any other room."}),"\n"]}),"\n"]}),"\n",(0,o.jsx)(t.h2,{id:"phase-2--increase-connectivity",children:"Phase 2 \u2013 Increase Connectivity"}),"\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Get a list of all the interior edges of W."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Select a portion of the edges at random and remove them."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"For each removed edge from W, add the corresponding edge to T."}),"\n"]}),"\n"]}),"\n",(0,o.jsx)(t.h2,{id:"phase-3--calculate-room-types",children:"Phase 3 \u2013 Calculate Room Types"}),"\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Assign the four walls of a room a value that is a power of 2, [1=top,2=right,4=bottom,8=left]."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"For each room in R, find the edges in W that correspond to the room."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Sum the values of the walls surrounding the room."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Assign that value to the node in R."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"The MST was originally our paths through the maze, but with the additional edges added it is now a graph of the increased connectivity caused by removing the random walls."}),"\n"]}),"\n"]}),"\n",(0,o.jsx)(t.h2,{id:"phase-4--choose-players-starting-room-and-boss-room",children:"Phase 4 \u2013 Choose Player\u2019s Starting Room and Boss Room"}),"\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Set all the edge weights of T to 1."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Use Breadth First Search to compute the shortest path between all nodes of T."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"From the resulting matrix, find the maximum value to get the longest path between any of the nodes."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"The indicies of the max value are two rooms furthest apart. Assign one as the players\u2019 starting point, and the Boss room at the other."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"This algorithm will ensure that every room on the map is accessible and that there are no holes in the exterior walls. From phase 5, we have also ensured that the boss is placed as far away from the players as possible."}),"\n"]}),"\n"]}),"\n",(0,o.jsx)(t.h2,{id:"phase-5--build-the-map",children:"Phase 5 \u2013 Build the Map"}),"\n",(0,o.jsxs)(t.ul,{children:["\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"For each node in R, get the value calculated in Phase 3."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Select a room from a bank of that type."}),"\n"]}),"\n",(0,o.jsxs)(t.li,{children:["\n",(0,o.jsx)(t.p,{children:"Spawn that room in the game space preserving the structure of R."}),"\n"]}),"\n"]})]})}function d(e={}){const{wrapper:t}={...(0,s.a)(),...e.components};return t?(0,o.jsx)(t,{...e,children:(0,o.jsx)(c,{...e})}):c(e)}},11151:(e,t,n)=>{n.d(t,{Z:()=>i,a:()=>a});var o=n(67294);const s={},r=o.createContext(s);function a(e){const t=o.useContext(r);return o.useMemo((function(){return"function"==typeof e?e(t):{...t,...e}}),[t,e])}function i(e){let t;return t=e.disableParentContext?"function"==typeof e.components?e.components(s):e.components||s:a(e.components),o.createElement(r.Provider,{value:t},e.children)}}}]);