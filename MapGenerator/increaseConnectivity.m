function [Map,Tree] = increaseConnectivity(Maze,Tree,M,N,interiorNodes)
%#codegen
% function to increase the connectivity of the provided maze by randomly
% removing a set portion of the interior walls
arguments
    Maze graph
    Tree graph
    M double
    N double
    interiorNodes (:,:) double
end

edges = Maze.Edges.EndNodes; % node pairs of all the edges in the maze
interiorEdges = edges((ismember(edges(:,1),interiorNodes) | ismember(edges(:,2),interiorNodes)),:);
NumInteriorEdges = length(interiorEdges);
numToRemove = ceil(NumInteriorEdges/10);
toRemove = getRandomEdges(interiorEdges,NumInteriorEdges,numToRemove); % to remove from Maze
Map = rmedge(Maze,toRemove(:,1),toRemove(:,2));

% divide the Maze edges into horizontal and vertical edges
Nh = toRemove((toRemove(:,2)-toRemove(:,1)==1),1); % all right root nodes for the horizontal edges to add to Tree
Nv = toRemove((toRemove(:,2)-toRemove(:,1)~=1),1); % all lower root nodes for the vertical edges to add to Tree

% map the nodes of the maze to the nodes of the tree
for i=N-2:-1:1
    Nv = Nv-(Nv>=(M*i+1));
    Nh = Nh-(Nh>=(M*i+1));
end

% list of edges to add back to the Tree
toAdd = [Nv-1 Nv; Nh-M+1 Nh];
Tree = addedge(Tree,toAdd(:,1),toAdd(:,2),ones(1,length(toAdd(:,1))));
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