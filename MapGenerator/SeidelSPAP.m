function D = SeidelSPAP(G,s)
%#codegen
%SeidelSPAP Calculates the shortest distance between all points in an
%unweighted, undirected graph using Seidel's algorithm
arguments
    G graph
    s double
end
A = full(adjacency(G));
if sum(sum(A)==0)
    D=zeros(s);
    return
end
D = APD(A,s);
end

function D = APD(A,s)
Z = A^2;
B = ((A==1)|(Z>0))&~eye(s);
if isequal(B|eye(s),ones(s))
    D = 2*B-A;
    return
end
T = APD(B,s);
D = zeros(s);
i = (T*A)>=(T*diag(sum(A)));
D(i) = 2*T(i);
D(~i) = 2*T(~i)-1;
end