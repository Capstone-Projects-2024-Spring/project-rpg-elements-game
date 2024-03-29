function Map = mapGenerator(M,N,p)
%#codegen
arguments
    M (1,1) double
    N (1,1) double
    p (1,1) double = 10
end

% adjust M and N to wall dimensions by adding 1
M = floor(abs(M))+1;
N = floor(abs(N))+1;
p = floor(abs(p));

% set a limit max of 20x20 rooms and min of 2x2 rooms and p in [0,100)
if (M>21) || (N>21) || (M<3) || (N<3) || p<0 || p >= 100
    Map = 0;
    return
end

tic
% turn p into a percentage
p = p/100;

% get a matrix of just interior nodes
interiorNodes = reshape(M+1:1:M*(N-1),[M N-2]);
interiorNodes = interiorNodes(2:end-1,:);

% generate random maze
[Maze,Tree] = genRandomMaze(M,N);

% remove additional random interior edges to increase connectivity
[Maze,Tree] = increaseConnectivity(Maze,Tree,M,N,interiorNodes,p);

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