function Map = mapGenerator(M,N)
%#codegen
arguments
    M double
    N double
end

% set a limit of 20x20 map
if (M>20) || (N>20)
    Map = 0;
    return
end

% adjust M and N to wall dimensions by adding 1
M = idivide(M,uint32(1))+1;
N = idivide(N,uint32(1))+1;

% get a matrix of just interior nodes
interiorNodes = reshape(1:1:M*N,[M N]);
interiorNodes = interiorNodes(2:end-1,2:end-1);

% generate random maze
[Maze,Tree] = genRandomMaze(M,N);

% remove additional random interior edges to increase connectivity
[Maze,Tree] = increaseConnectivity(Maze,Tree,M,N,interiorNodes);

% assign room values to map
rooms = zeros(M-1,N-1);
rooms(1,:) = 1;
rooms(end,:) = rooms(end,:) + 8;
rooms(:,1) = rooms(:,1) + 2;
rooms(:,end) = rooms(:,end) + 4;
for j=1:N-2
    j_odd = mod(j,2);
    for i=1:M-2
        i_odd = mod(i,2);
        n = interiorNodes(i,j);
        if (i_odd && j_odd)
            u = findedge(Maze,n-1,n);
            d = findedge(Maze,n,n+1);
            l = findedge(Maze,n-M,n);
            r = findedge(Maze,n,n+M);
            if u
                rooms(i,j) = rooms(i,j) + 4;
                rooms(i,j+1) = rooms(i,j+1) + 2;
            end
            if d
                rooms(i+1,j) = rooms(i+1,j) + 4;
                rooms(i+1,j+1) = rooms(i+1,j+1) + 2;
            end
            if l
                rooms(i,j) = rooms(i,j) + 8;
                rooms(i+1,j) = rooms(i+1,j) + 1;
            end
            if r
                rooms(i,j+1) = rooms(i,j+1) + 8;
                rooms(i+1,j+1) = rooms(i+1,j+1) + 1;
            end
        elseif (i_odd && ~j_odd)
            u = findedge(Maze,n-1,n);
            d = findedge(Maze,n,n+1);
            if u
                rooms(i,j) = rooms(i,j) + 4;
                rooms(i,j+1) = rooms(i,j+1) + 2;
            end
            if d
                rooms(i+1,j) = rooms(i+1,j) + 4;
                rooms(i+1,j+1) = rooms(i+1,j+1) + 2;
            end
        elseif (~i_odd && j_odd)
            l = findedge(Maze,n-M,n);
            r = findedge(Maze,n,n+M);
            if l
                rooms(i,j) = rooms(i,j) + 8;
                rooms(i+1,j) = rooms(i+1,j) + 1;
            end
            if r
                rooms(i,j+1) = rooms(i,j+1) + 8;
                rooms(i+1,j+1) = rooms(i+1,j+1) + 1;
            end
        end
    end
end

% get the last row if M is even
if ~mod(M,2)
    n = interiorNodes(end,:);
    for i=1:N-2
        d = findedge(Maze,n(i),n(i)+1);
        if d
            rooms(end,i) = rooms(end,i) + 4;
            rooms(end,i+1) = rooms(end,i+1) + 2;
        end
    end
end

% get the last column if N is even
if ~mod(N,2)
    n = interiorNodes(:,end);
    for i=1:M-2
        r = findedge(Maze,n(i),n(i)+M);
        if r
            rooms(i,end) = rooms(i,end) + 8;
            rooms(i+1,end) = rooms(i+1,end) + 1;
        end
    end
end

% calculate the players' start room and boss room
D = distances(Tree,'Method','unweighted');
[~, bossRoom] = max(D(:));
[startRoom, bossRoom] = ind2sub(size(D),bossRoom);
X = [startRoom bossRoom];
[Y,Z] = ind2sub(size(rooms),X);
StartBossRooms = sub2ind(flip(size(rooms)),Z,Y);

% output rooms vals as vector with start and boss rooms appended on end
Map = [reshape(rooms',1,[]) StartBossRooms];
end