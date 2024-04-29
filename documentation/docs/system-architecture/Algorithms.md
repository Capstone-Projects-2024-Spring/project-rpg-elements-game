---
sidebar_position: 1
---
# Algorithms

## Procedural Generation Algorithm

In Wildlife Odyssey, the level generation is done using an original algorithm that will be able to assign the rooms numerical values based on where the walls are then it will use graph theory to stitch them together in a way that ensures there are no spaces that are inaccessible. The algorithm will follow this layout: 

## Phase 1 – Generate an M by N Maze

  - Generate an M by N lattice graph for the Rooms, call it R.

  - Generate an (M+1) by (N+1) lattice graph for the Walls around each room, call it W.

  - Give all the edges of R and random weight.
  
  - Construct a Minimum Spanning Tree (MST) from the edges of R, call it T.
  
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

  - Use Breadth First Search to compute the shortest path between all nodes of T.

  - From the resulting matrix, find the maximum value to get the longest path between any of the nodes.

  - The indices of the max value are two rooms furthest apart. Assign one as the players’ starting point and the Boss room at the other.

  - This algorithm will ensure that every room on the map is accessible and that there are no holes in the exterior walls. From phase 5, we have also ensured that the boss is placed as far away from the players as possible.

## Phase 5 – Build the Map

  - For each node in R, get the value calculated in Phase 3.

  - Select a room from a bank of that type.

  - Spawn that room in the game space preserving the structure of R.
