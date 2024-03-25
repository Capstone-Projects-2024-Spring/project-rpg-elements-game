function A = latticeAdjacencyMatrix(M,N)
%#codegen
% FROM: https://www.mathworks.com/matlabcentral/answers/1820440-any-function-to-get-adjacency-matrix-of-2d-m-by-n-lattice
% M rows, N columns, denoting the size of the rectangular lattice
% A - N*M by N*M square adjacency matrix
arguments
    M (1,1) double
    N (1,1) double
end

% Connect nodes (i,j) to (i+1,j)
[i,j] = ndgrid(1:M-1,1:N);
ind1 = sub2ind([M,N],i,j);
ind2 = sub2ind([M,N],i+1,j);

% Connect nodes (i,j) to (i,j+1)
[i,j] = ndgrid(1:M,1:N-1);
ind3 = sub2ind([M,N],i,j);
ind4 = sub2ind([M,N],i,j+1);

% build the global adjacency matrix
A = sparse([ind1(:);ind3(:)],[ind2(:);ind4(:)],ones(N*(M-1) + (N-1)*M,1),N*M,N*M);
end