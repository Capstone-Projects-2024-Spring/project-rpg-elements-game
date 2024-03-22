function Map = mapGenerator(M,N)
%#codegen
arguments
    M double
    N double
end
tic
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

% generate random maze
[Maze,Tree] = genRandomMaze(M,N);

% remove additional random interior edges to increase connectivity
[Maze,Tree] = increaseConnectivity(Maze,Tree,M,N,interiorNodes);

% assign room values to map
Rooms = calcRoomVals(Maze,interiorNodes,M,N);

% calculate the players' start room and boss room
D = distances(Tree,'Method','unweighted');
[~,bossRoom] = max(D(:));
[startRoom,bossRoom] = ind2sub(size(D),bossRoom); % column major start and boss room numbers
[startRoom,bossRoom] = ind2sub(size(Rooms),[startRoom bossRoom]);
StartBossRooms = sub2ind(flip(size(Rooms)),bossRoom,startRoom); % row major start and boss room numbers

% output rooms vals as vector with start and boss rooms appended on end
Map = [reshape(Rooms',1,[]) StartBossRooms];
toc
end