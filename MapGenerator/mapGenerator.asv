function Map = mapGenerator(M,N)
%#codegen
arguments
    M double
    N double
end

% if M>N, swap for map generation. Rotate map at end to get map in original
% dimensions
rotate = false;
if M>N
    rotate = true;
    M = bitxor(M,N);
    N = bitxor(M,N);
    M = bitxor(M,N);
end

% set a limit of 100x100 map
if (M>100) || (N>100)
    Map = 0;
    return
end

% adjust M and N to wall dimensions by adding 1
M = idivide(M,uint32(1))+1;
N = idivide(N,uint32(1))+1;

% get a matrix of just interior nodes
interiorNodes = reshape(1:1:M*N,[N M])';
interiorNodes = interiorNodes(2:end-1,2:end-1);

% generate random maze
[Maze,Tree] = genRandomMaze(M,N);

% remove additional random interior edges to increase connectivity
[Maze,Tree] = increaseConnectivity(Maze,Tree,N,interiorNodes);

% find longest distance on Tree
D = distances(Tree,'Method','unweighted');

% assign room values to map
rooms = zeros(M-1,N-1);
rooms(1,:) = 1;
rooms(end,:) = rooms(end,:) + 8;
rooms(:,1) = rooms(:,1) + 2;
rooms(:,end) = rooms(:,end) + 4;
M_odd = mod(M,2);
N_odd = mod(N,2);

for i=1:M-2
    i_odd = mod(i,2);
    for j=1:N-2
        j_odd = mod(j,2);
        n = interiorNodes(i,j);
        if i_odd
            u = findedge(Maze,n,n-N);
            if u
                rooms(i,j) = rooms(i,j) + 4;
                rooms(i,j+1) = rooms(i,j+1) + 2;
            end
            d = findedge(Maze,n,n+N);
            if d
                rooms(i+1,j) = rooms(i+1,j) + 4;
                rooms(i+1,j+1) = rooms(i+1,j+1) + 2;
            end
            if j_odd
                l = findedge(Maze,n-1,n);
                if l
                    rooms(i,j) = rooms(i,j) + 8;
                    rooms(i+1,j) = rooms(i+1,j) + 1;
                end
                r = findedge(Maze,n,n+1);
                if r
                    rooms(i,j+1) = rooms(i,j+1) + 8;
                    rooms(i+1,j+1) = rooms(i+1,j+1) + 1;
                end
            end
        else
            if j_odd
                l = findedge(Maze,n-1,n);
                if l
                    rooms(i,j) = rooms(i,j) + 8;
                    rooms(i+1,j) = rooms(i+1,j) + 1;
                end
                r = findedge(Maze,n,n+1);
                if r
                    rooms(i,j+1) = rooms(i,j+1) + 8;
                    rooms(i+1,j+1) = rooms(i+1,j+1) + 1;
                end
            end
        end
    end
    if ~N_odd
        n = interiorNodes(i,end);
        e = findedge(Maze,n,n+1);
        if e
            rooms(i,end) = rooms(i,end) + 8;
            rooms(i+1,end) = rooms(i+1,end) + 1;
        end
    end
end
if ~M_odd
    n = interiorNodes(end,:);
    for j=1:N-2
        e = findedge(Maze,n(j),n(j)+N);
        if e
            rooms(end,j) = rooms(end,j) + 4;
            rooms(end,j+1) = rooms(end,j+1) + 2;
        end
    end
end

% rotate rooms if original M>N
if rotate
    D = D';
    rooms = rooms';
    rotateVals = [2 1 3 8 10 9 11 4 6 5 7 12 14 13 15];
    for i=1:N-1
        for j=1:M-1
            if rooms(i,j)
                rooms(i,j) = rotateVals(rooms(i,j));
            end
        end
    end
end

% calculate the players' start room and boos room
[~, bossRoom] = max(D(:));
[startRoom, bossRoom] = ind2sub(size(D),bossRoom);

% output rooms vals as vector with start and boss rooms appended on end
Map = [reshape(rooms',1,[]) startRoom bossRoom];
end