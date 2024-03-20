function [Map,Tree] = increaseConnectivity(Maze,Tree,N,interiorNodes)
%#codegen
% function to increase the connectivity of the provided maze by randomly
% removing a set portion of the interior walls
arguments
    Maze graph
    Tree graph
    N double
    interiorNodes (:,:) double
end
N = N-1;
edges = Maze.Edges.EndNodes; % node pairs of all the edges in the maze
interiorEdges = edges((ismember(edges(:,1),interiorNodes) | ismember(edges(:,2),interiorNodes)),:);
NumInteriorEdges = length(interiorEdges);
numToRemove = ceil(NumInteriorEdges/10);
toRemove = getRandomEdges(interiorEdges,NumInteriorEdges,numToRemove); % to remove from Maze
toAdd = mapMazeEdgeToTreeEdge(toRemove,N); % to add back to Tree
Map = rmedge(Maze,toRemove(:,1),toRemove(:,2));
Tree = addedge(Tree,toAdd(:,1),toAdd(:,2),ones(1,length(toAdd(:,1))));
end

function treeEdges = mapMazeEdgeToTreeEdge(mazeEdges,N)
% helper function to map the maze edges to the tree edges
n = length(mazeEdges(:,1));
treeEdges = zeros(n,2);
for i=1:n
    r = floor((mazeEdges(i,1)-1)/N); % find the row offset
    treeNode = mazeEdges(i,2)-r; % map the maze node to the tree node
    if (mazeEdges(i,2)-mazeEdges(i,1))==1 % horizontal edge
        treeEdges(i,:) = [treeNode-N+1 treeNode]; % connect tree node to the node above it
    else % vertical edge
        treeEdges(i,:) = [treeNode-1 treeNode]; % connect tree node to the node before it
    end
end
end

function edges = getRandomEdges(edgeList,numOptions,numToRemove)
% uses Knuth's Algorithm S to select edges from a list with equal
% probability
numOptionsRemaining = numOptions;
numToChoose = numToRemove;
numChosen = 0;
edges = zeros(numToRemove,2);

for i=1:numOptions
    numOptionsRemaining = numOptions - i;
    numToChoose = numToRemove - numChosen;
    if randi(numOptionsRemaining) <= numToChoose
        edges(numChosen+1,:) = edgeList(i,:);
        numChosen = numChosen+1;
    end
    if numChosen == numToRemove
        break;
    end
end
end