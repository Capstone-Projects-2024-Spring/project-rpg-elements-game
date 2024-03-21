function [Maze,Tree] = genRandomMaze(M,N)
%#codegen
% create a random MxN maze
arguments
    M double
    N double
end

% get Adjacency Matrix for map space, and for a space smaller than the map
% space by 1 in each dimension
A = latticeAdjacencyMatrix(M,N); % adjacency matrix for the map space
B = latticeAdjacencyMatrix(M-1,N-1); % adjacency matrix for inlaid map

% generate graphs from the adjacency matrices
G = graph(A,'upper');
S = graph(B,'upper');

% weight the edgges of the inlaid graph and fin the minimum spanning tree
S.Edges.Weight = rand(length(S.Edges.Weight),1);
Tree = minspantree(S);

% store the end nodes as ordered pairs
E = Tree.Edges.EndNodes(:,:);

% map the nodes of the spanning tree to the full map graph nodes
for i=N-2:-1:1
    E = E+(E(:,:)>(N-1)*i);
end

% find all the intersecting edges for the MST with the full map graph
Eh = E((E(:,2)-E(:,1)==1),:); % all the horizonal walls in the MST
Ev = E((E(:,2)-E(:,1)~=1),:); % all the vertical walls in the MST
intersectingEdges = [Ev(:,2) Ev(:,2)+1; Eh(:,2)  Eh(:,2)+N];

% remove all the intersecting edges from the full map to get a maze
Maze = rmedge(G,intersectingEdges(:,1),intersectingEdges(:,2));
end