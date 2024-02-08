# wildlife-odyssey
GitHub Repo for a 2D platformer with RPG elements
=======
<div align="center">

# Wildlife Odyssey
[![Report Issue on Jira](https://img.shields.io/badge/Report%20Issues-Jira-0052CC?style=flat&logo=jira-software)](https://temple-cis-projects-in-cs.atlassian.net/jira/software/c/projects/DT/issues)
[![Deploy Docs](https://github.com/ApplebaumIan/tu-cis-4398-docs-template/actions/workflows/deploy.yml/badge.svg)](https://github.com/ApplebaumIan/tu-cis-4398-docs-template/actions/workflows/deploy.yml)
[![Documentation Website Link](https://img.shields.io/badge/-Documentation%20Website-brightgreen)](https://capstone-projects-2024-spring.github.io/project-rpg-elements-game/)


</div>


## Keywords
 

* Section 2
* Game Development
* Unity
* Desktop
* App
* C# 

 

## Project Abstract
This project will be a multiplayer 2D platforming game with RPG elements made in Unity in which players must work together to beat the game’s main campaign. The players can either join a private lobby or create one themselves. After joining a lobby, players can pick from a variety of different characters to play as, with each character having a distinct set of attacks that comprise their moveset. Each character also has different attributes (for example, one character can have a high attack power but low defense, while a different character can have low attack power and high defense). When all players are ready to start, they must use their characters to progress through the game’s world and defeat various enemies along the way. 

 

A mock-up of what the game is planned to look like is shown here:

![image](https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/assets/97611396/a96721c1-7089-4f1f-8502-68e50e050ead)


The group as a whole has a “level” that starts at 1, but as the players defeat more enemies, they can increase the level, allowing the characters to improve their attributes and learn new attacks that they can add or remove from their moveset. The players can even improve the attacks themselves to be stronger and more efficient. Below is an illustration to demonstrate how leveling up works:

![image](https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/assets/97611396/79b814bd-7111-4000-8ccc-04526e08cbf8)



As depicted in the illustration, a new attack was learned when leveling up. These attacks can be equipped and unequipped in a menu, like the one illustrated below:

![image](https://github.com/Capstone-Projects-2024-Spring/project-rpg-elements-game/assets/97611396/23fa6c75-710d-425a-a3dd-093402444613)

As the group progresses through the game, they gain more levels and become stronger. Overall, the game can be described as combining elements from platform fighters like Super Smash Bros. with RPG elements from games like Pokémon.


## High Level Requirements
Upon booting up the game, the player can join or create a lobby. The game will use Alteruna Multiplayer, which is a free package in Unity, to connect to other user’s lobbies. After joining the lobby, the player should be taken to a menu to select their character, even if the game itself is already in progress. Each character starts off at level 1 with a default list of moves and a default distribution of stats. Once in the game, each player can input their character’s attacks by combining different directions with the designated attack button. Players shouldn’t be able to hurt other players, but every player can hurt the game’s enemies. When enough enemies have been defeated, every character levels up, increasing their stats as well as potentially unlocking new attacks (demonstrated in the second illustration in the Project Abstract). When a new attack has been learnt, a player can open a menu to decide which attacks are in their moveset, as well as what input is needed to perform these attacks (demonstrated in the third illustration in the Project Abstract). When a player is in a menu, it shouldn’t interrupt the gameplay of the other players, though the game should still indicate when a player is in a menu. Each player is free to roam and explore the levels at their own pace, but if a player feels like they’ve gotten too far away from the rest of the party, they can warp to the other players whenever they like. Finally, if the player wants to rebind their controls, they can do so at any time.

## Conceptual Design
This game will be made with Unity, which mainly uses C# for its programming language. If needed, however, third-party plugins can be used to allow alternative languages like Python to make Unity games, though despite this, it is still likely that C# will be the language used. The game will be developed mainly for popular OS like Windows, Mac, and Linux, with no plans to make a mobile version on iOS or Android.

 

## Background
The inspiration for this game came from the idea of taking games like Super Smash Bros. or Kirby and integrating RPG elements into it. While both games have a wide variety of characters that all have distinct movesets, those movesets are always completely static. The same character will always have the same set of moves. Meanwhile, RPGs like Pokémon or Xenoblade Chronicles allow the player to customize their characters with different attacks the more they level up. While the pace of RPGs are much slower than the pace of 2D platformers, there are games like Super Paper Mario that successfully integrate the mechanics of RPGs in 2D Platformers in a seamless fashion. This game aims to be a unique blend of these two wildly different genres of games that are very popular by themselves but are seldom combined together.

 

## Required Resources
* A laptop or computer

* IDE

* Unity

* Knowledge of C# and Unity (though unfamiliarity is okay. Knowledge of these resources can be gained during the development cycle)

* Alteruna Multiplayer (A free Unity package that allows multiplayer to be used)
## Collaborators

[//]: # ( readme: collaborators -start )
<table>
<tr>
    <td align="center">
        Eddy Pike
    </td>
    <td align="center">
        Alex McGinn
    </td>
    <td align="center">
        Brandon Cuevas
    </td>
    <td align="center">
        Theron Halsey
    </td>
    <td align="center">
        Luigi Mazzocchi
    </td>
    <td align="center">
        Brian Barnefiher
    </td>
    <td align="center">
        Andrew Tran
    </td>

   </tr>
</table>

[//]: # ( readme: collaborators -end )

