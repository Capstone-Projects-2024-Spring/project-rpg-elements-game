---
sidebar_position: 2
---

# System Block Diagram






import Figure from "../../src/components/Figure";

<Figure caption={"Figure 1. High level design of the Wildlife Odyssey architecture"}>

![System Block Diagram](/img/SystemBlockDiagram.jpg)

</Figure>  

Figure 1 shows the proposed design for our 2D Platformer game, which will run on all major operating systems (Windows, Mac, & Linux). The game can be downloaded, installed, and booted from your local PC. The front-end character design of the game will be created internally and animated using the Unity Engine. Custom scripting in C# will be used for player movements, animations, and the procedural generation of the map. Multiplayer will be implemented using the Photon Unity Networking solution and will provide real-time cloud-hosted matchmaking. User authentication, chat messages, achievements, and friends' lists will be stored and implemented using Firebase real-time Database/Authentication tools. Firebase Cloud Functions will also be used to respond to in-game events, such as messages, game invites, or custom matchmaking priority.
