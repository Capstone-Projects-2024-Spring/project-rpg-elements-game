function D = distBFS(G,s)
%#codegen
%DISTBFS Calculates the shortest path between all pairs of nodes using
%breadth-frist search
arguments
    G graph
    s double
end
D = Inf(s);
queue = zeros(1,s-1);
for i=1:s
    D(i,i) = 0;
    numFound = 1;
    numToFind = s-1;
    qi = 1;
    queue(qi) = i;
    while numFound <= numToFind
        n = neighbors(G,queue(qi))';
        d = D(i,queue(qi))+1;
        D(i,n(D(i,n)>d)) = d;
        n = n(~ismember(n,queue));
        l = length(n);
        queue(numFound+1:numFound+l) = n;
        numFound = numFound+l;
        qi = qi+1;
    end
    queue = zeros(1,s);
end
end