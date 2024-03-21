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
%G.Edges.EndNodes
E = Tree.Edges.EndNodes;

% find all the intersecting edges of the MST with the Wall graph
Nh = E((E(:,2)-E(:,1)==1),2); % all right root nodes for the horizontal walls in the MST
Nv = E((E(:,2)-E(:,1)~=1),2); % all bottom root nodes for the vertical walls in the MST

% map the nodes of the spanning tree to the full map graph nodes
for i=N-2:-1:1
    Nh = Nh+(Nh>((M-1)*i));
    Nv = Nv+(Nv>((M-1)*i));
end

% 2d vector of all intersecting edges
intersectingEdges = [Nh Nh+M; Nv Nv+1];

% remove all the intersecting edges from the full map to get a maze
Maze = rmedge(G,intersectingEdges(:,1),intersectingEdges(:,2));
end