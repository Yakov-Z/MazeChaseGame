# Maze Chase: 2D Algorithmic Survival Game

🎮 **Play the game instantly in your browser:** [Play Maze Chase on Itch.io](https://yaakov0864.itch.io/maze-chase)

## Overview
A fast-paced 2D survival game where players navigate a dynamically generated maze while evading a relentless AI enemy. Built with Unity, the game leverages classic graph algorithms (DFS for procedural generation, BFS for pathfinding) to ensure every run provides a unique and challenging experience.

## Controls
* **W, A, S, D / Arrow Keys:** Move
* **Spacebar:** Dash (Phases through enemies)

## Technical Features
* **Procedural Maze Generation (DFS):** The `DFSMazeGenerator` utilizes a randomized Depth-First Search algorithm to carve out unique, perfect mazes dynamically at runtime.
* **Shortest-Path Enemy AI (BFS):** The enemy calculates the optimal route to the player through the complex grid using Breadth-First Search, adapting to the dynamically generated environment.
* **Advanced 2D Physics & Movement:** Fluid player movement using `Rigidbody2D`, featuring a tactical dash mechanic with Invincibility Frames (I-Frames) managed via Unity's Layer Collision Matrix and zero-friction physics materials.
* **Data Persistence:** Local JSON serialization for tracking and saving the top 5 fastest clear times in a custom Leaderboard system.
* **Event-Driven Architecture:** Clean decoupling of UI and game logic using C# `Action` events for timers and dash cooldowns.

## Tech Stack
* **Engine:** Unity 2D (Version 2022.3.15f1)
* **Language:** C#
* **Platform:** WebGL / Windows Desktop
