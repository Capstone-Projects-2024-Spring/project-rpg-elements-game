Procedural Generation Algorithm

There are currently two ideas for the algorithm that may be implemented. The first is an algorithm that was created to match how a game, Spelunky, created their map. The algorithm is a simple directional checker. 
What this means is that at its base it looks to find if a portion of the map can be spawned to the left or the right of the previous room. If this is the case then it will spawn a room there and continue the process until it reaches the maximum Y distance. 
The maximum Y distance describes the “height” of the map or the lower bound. If the final block spawns on the max Y block the level generation code will then stop and there should be a path from the spawn point to the end. 
However, this does not take any of the directional openings into account. The directional opening are simple values, 0 for a left and right room opening, 1 for a left, right, and bottom openings, 2 for a left, right, top, and bottom openings, and 3 
for left, right, top, and bottom openings. For left and right room spawns, the room choice does not matter as no room will block the spawn, therefore the script is told to just pick a random room from zero to three. For bottom movement, the script is 
told to choose either 2 or 3 as they have top and bottom openings. 

The second algorithm is an original algorithm that will be able to assign the rooms numerical values based on where the walls are then it will use graph theory to stitch them together in a way that ensures there are no inaccessible spaces.
