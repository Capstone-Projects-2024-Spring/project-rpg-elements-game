---
sidebar_position: 3
---

# System Block Diagram

![Wildlife Odyssey](https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/assets/95385730/26593187-0517-458e-9beb-272a044979e4)


*Figure 1. High level design of the Wildlife Odyssey architecture*



Figure 1 shows the proposed design for our 2D Platformer game, which will run on all major operating systems (Windows, Mac, & Linux). The game can be downloaded, installed, and booted from your local PC as a desktop application. The front-end character design of the game will be created internally and animated using the Unity Engine. Custom scripting in C# will be used for player movements, animations, game physics, and the procedural generation of the map. The procedural map generation will be done on regular intervals on a VPS run on Oracle Cloud as well as on request to reduce the time taken to serve the client. User authentication, chat messages, achievements, and friends' lists will be stored and implemented using Firebase real-time Database/Authentication tools. A multiplayer matchmaking and lobby system will be implemented using the Photon Unity Networking solution PUN 2, and will provide real-time cloud-hosted matchmaking. Mirror Networking for Unity will be used to create in-game multiplayer synchronization over the network. A Digital Ocean virtual private server (droplet) is used to host the matchamde games. A dedicated server build is created with unity and uploaded to the server, where Docker & Docker Compose are used to map port numbers to the port preset on our server build. We then create several instances of the container running our game with Docker Compose. Further details can be found here: https://github.com/amcginn92/Digital-Ocean-Docker-Server.

