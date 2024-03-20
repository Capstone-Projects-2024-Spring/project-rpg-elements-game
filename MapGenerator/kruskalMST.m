function [T] = kruskalMST(G)
%#codegen
%kruskalMST Calculates the minimum spanning tree from an undirected
%weighted graph using Kruskal's algorithm
arguments
    G graph
end
numToAdd=size(G.Nodes,1); % number of edges to add to tree
parent=1:numToAdd; % initialize all nodes' parents to themselves
[~,I]=sortrows(G.Edges.Weight); % sort edges by weight
[a,b]=findedge(G,I(1)); % get initial edge to initialize tree
T=graph(a,b,1); % initialize tree
parent(b)=a; % set parent of node b to a
i=2; % start iterator at 2
numToAdd=numToAdd-2; % set total number of edges to add to number of nodes-1-1 from initial step being done outside loop
while numToAdd % while edges ramin to be added
    [a,b]=findedge(G,I(i)); % get next edge
    if parent(a) ~= parent(b) % if adding edge does not cause a cycle
        T = addedge(T,a,b,1); % add the edge
        parent(parent==parent(b))=parent(a); % update parents of all nodes under b to a
        numToAdd=numToAdd-1; % decrement the number to add
    end
    i=i+1; % move i to next edge
end
end