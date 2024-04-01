function RoomsVals = calcRoomVals(Maze,interiorNodes,M,N)
%#codegen
%CALROOMVALS Calculate the room values based on the walls surrounding a
%room
arguments
    Maze (1,1) graph
    interiorNodes (:,:) double
    M (1,1) double
    N (1,1) double
end

% set the values for the exterior walls since they are fixed
RoomsVals = zeros(M-1,N-1);
RoomsVals(1,:) = 1;
RoomsVals(end,:) = RoomsVals(end,:) + 8;
RoomsVals(:,1) = RoomsVals(:,1) + 2;
RoomsVals(:,end) = RoomsVals(:,end) + 4;

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
                RoomsVals(i,j) = RoomsVals(i,j) + 4;
                RoomsVals(i,j+1) = RoomsVals(i,j+1) + 2;
            end
            if d
                RoomsVals(i+1,j) = RoomsVals(i+1,j) + 4;
                RoomsVals(i+1,j+1) = RoomsVals(i+1,j+1) + 2;
            end
        end
        if j_odd
            l = findedge(Maze,n-M,n);
            r = findedge(Maze,n,n+M);
            if l
                RoomsVals(i,j) = RoomsVals(i,j) + 8;
                RoomsVals(i+1,j) = RoomsVals(i+1,j) + 1;
            end
            if r
                RoomsVals(i,j+1) = RoomsVals(i,j+1) + 8;
                RoomsVals(i+1,j+1) = RoomsVals(i+1,j+1) + 1;
            end
        end
    end
end

% if M or N is even, previous process will miss the final row or column
% get the last row if M is even
if ~mod(M,2)
    n = interiorNodes(end,:);
    for i=1:N-2
        d = findedge(Maze,n(i),n(i)+1);
        if d
            RoomsVals(end,i) = RoomsVals(end,i) + 4;
            RoomsVals(end,i+1) = RoomsVals(end,i+1) + 2;
        end
    end
end

% get the last column if N is even
if ~mod(N,2)
    n = interiorNodes(:,end);
    for i=1:M-2
        r = findedge(Maze,n(i),n(i)+M);
        if r
            RoomsVals(i,end) = RoomsVals(i,end) + 8;
            RoomsVals(i+1,end) = RoomsVals(i+1,end) + 1;
        end
    end
end
end