---
sidebar_position: 1
---
# Algorithms

## Procedural Generation Algorithm

There are currently two ideas for the algorithm that may be implemented. The first is an algorithm that was created to match how a game, Spelunky, created their map. The algorithm is a simple directional checker. 
What this means is that at its base it looks to find if a portion of the map can be spawned to the left or the right of the previous room. If this is the case then it will spawn a room there and continue the process until it reaches the maximum Y distance. 
The maximum Y distance describes the “height” of the map or the lower bound. If the final block spawns on the max Y block the level generation code will then stop and there should be a path from the spawn point to the end. 
However, this does not take any of the directional openings into account. The directional openings are simple values, 0 for a left and right room opening, 1 for left, right, and bottom openings, 2 for left, right, top, and bottom openings, and 3 
for left, right, top, and bottom openings. For left and right room spawns, the room choice does not matter as no room will block the spawn, therefore the script is told to just pick a random room from zero to three. For bottom movement, the script is 
told to choose either 2 or 3 as they have top and bottom openings. 

The second algorithm is an original algorithm that will be able to assign the rooms numerical values based on where the walls are then it will use graph theory to stitch them together in a way that ensures there are no spaces that are inaccessible. The algorithm will follow this layout: 

## Phase 1 – Generate an M by N Maze

  - Generate an M by N lattice graph for the rooms, call it R.

  - Generate an (M+1) by (N+1) lattice graph for the walls around each room, call it W.

  - Give all the edges of R and random weight.
  
  - Construct a minimum spanning tree (MST) from the edges of R, call it T.
  
  - Remove all the edges of W that intersect an edge of the MST of R.

  - We now have a maze that ensures every room on the map is accessible via some path from any other room.

## Phase 2 – Increase Connectivity

  - Get a list of all the interior edges of W.

  - Select a portion of the edges at random and remove them.
  
  - For each removed edge from W, add the corresponding edge to T.

## Phase 3 – Calculate Room Types

  - Assign the four walls of a room a value that is a power of 2, [1=top,2=right,4=bottom,8=left].

  - For each room in R, find the edges in W that correspond to the room.

  - Sum the values of the walls surrounding the room.

  - Assign that value to the node in R.

  - The MST was originally our paths through the maze, but with the additional edges added it is now a graph of the increased connectivity caused by removing the random walls.

## Phase 4 – Choose Player’s Starting Room and Boss Room

  - Set all the edge weights of T to 1.

  - Use Dijkstra's Algorithm to compute the shortest path between all nodes of T.

  - From the resulting matrix, find the maximum value to get the longest path between any of the nodes.

  - Take the two nodes that make the longest path and assign one as the players’ starting point, and the Boss room at the other.

  - This algorithm will ensure that every room on the map is accessible and that there are no holes in the exterior walls. From phase 5, we have also ensured that the boss is placed as far away from the players as possible.

## Phase 5 – Build the Map

  - For each node in R, get the value calculated in Phase 3.

  - Select a room from a bank of that type.

  - Spawn that room in the game space preserving the structure of R.
