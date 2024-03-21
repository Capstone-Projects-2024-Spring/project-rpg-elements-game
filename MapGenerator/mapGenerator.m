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
M = floor(M)+1;
N = floor(N)+1;

% get a matrix of just interior nodes
interiorNodes = reshape(M+1:1:M*(N-1),[M N-2]);
interiorNodes = interiorNodes(2:end-1,:);

%% generate random maze
[Maze,Tree] = genRandomMaze(M,N);

%% remove additional random interior edges to increase connectivity
[Maze,Tree] = increaseConnectivity(Maze,Tree,M,N,interiorNodes);

%% assign room values to map
% set the values for the exterior walls since they are fixed
Rooms = zeros(M-1,N-1);
Rooms(1,:) = 1;
Rooms(end,:) = Rooms(end,:) + 8;
Rooms(:,1) = Rooms(:,1) + 2;
Rooms(:,end) = Rooms(:,end) + 4;

% for each interior node, get the walls connected to that node and
% calculate the modifications for each room the node touches
j_odd = false;
for j=1:N-2
    j_odd = ~j_odd;
    i_odd = false;
    for i=1:M-2
        n = interiorNodes(i,j);
        i_odd = ~i_odd;
        if i_odd
            u = findedge(Maze,n-1,n);
            d = findedge(Maze,n,n+1);
            if u
                Rooms(i,j) = Rooms(i,j) + 4;
                Rooms(i,j+1) = Rooms(i,j+1) + 2;
            end
            if d
                Rooms(i+1,j) = Rooms(i+1,j) + 4;
                Rooms(i+1,j+1) = Rooms(i+1,j+1) + 2;
            end
        end
        if j_odd
            l = findedge(Maze,n-M,n);
            r = findedge(Maze,n,n+M);
            if l
                Rooms(i,j) = Rooms(i,j) + 8;
                Rooms(i+1,j) = Rooms(i+1,j) + 1;
            end
            if r
                Rooms(i,j+1) = Rooms(i,j+1) + 8;
                Rooms(i+1,j+1) = Rooms(i+1,j+1) + 1;
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
            Rooms(end,i) = Rooms(end,i) + 4;
            Rooms(end,i+1) = Rooms(end,i+1) + 2;
        end
    end
end

% get the last column if N is even
if ~mod(N,2)
    n = interiorNodes(:,end);
    for i=1:M-2
        r = findedge(Maze,n(i),n(i)+M);
        if r
            Rooms(i,end) = Rooms(i,end) + 8;
            Rooms(i+1,end) = Rooms(i+1,end) + 1;
        end
    end
end

%% calculate the players' start room and boss room
D = distances(Tree,'Method','unweighted');
[~,bossRoom] = max(D(:));
[startRoom,bossRoom] = ind2sub(size(D),bossRoom); % column major start and boss room numbers
[startRoom,bossRoom] = ind2sub(size(Rooms),[startRoom bossRoom]);
StartBossRooms = sub2ind(flip(size(Rooms)),bossRoom,startRoom); % row major start and boss room numbers

%% output rooms vals as vector with start and boss rooms appended on end
Map = [reshape(Rooms',1,[]) StartBossRooms];
end