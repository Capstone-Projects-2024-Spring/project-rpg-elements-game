function [A] = latticeAdjacencyMatrix(M,N)
%#codegen
% FROM: https://www.mathworks.com/matlabcentral/answers/1820440-any-function-to-get-adjacency-matrix-of-2d-m-by-n-lattice
% N rows, M columns, denoting the size of the rectangular lattice
% A - N*M by N*M square adjacency matrix
arguments
    M double
    N double
end

% Connect nodes (i,j) to (i+1,j)
[i,j] = ndgrid(1:N-1,1:M);
ind1 = sub2ind([N,M],i,j);
ind2 = sub2ind([N,M],i+1,j);

% Connect nodes (i,j) to (i,j+1)
[i,j] = ndgrid(1:N,1:M-1);
ind3 = sub2ind([N,M],i,j);
ind4 = sub2ind([N,M],i,j+1);

% build the global adjacency matrix
totalnodes = N*(M-1) + (N-1)*M;
A = sparse([ind1(:);ind3(:)],[ind2(:);ind4(:)],ones(totalnodes,1),N*M,N*M);
end