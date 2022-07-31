# depthchartmanager
Sport Depth Chart Manager

This repository is all about the depth chart manager for various sports like NFL, MLB, NHL and NBA

Implemented use cases: 1 addPlayerToDepthChart (position, player, position_depth) o Adds a player to the depth chart at a given position o Adding a player without a position_depth would add them to the end of the depth chart at that position o The added player would get priority. Anyone below that player in the depth chart would get moved down a position_depth

2 removePlayerFromDepthChart(position, player) o Removes a player from the depth chart for a given position and returns that player o An empty list should be returned if that player is not listed in the depth chart at that position

3 getBackups (position, player) o For a given player and position, we want to see all players that are “Backups”, those with a lower position_depth o An empty list should be returned if the given player has no Backups o An empty list should be returned if the given player is not listed in the depth chart at that position

4 getFullDepthChart() o Print out the full depth chart with every position on the team and every player within the Depth Chart

Dev Requirements:

Runs with .NET CORE 5.0

BUILD: dotnet build

Test: dotnet test

Run: dotnet run --project DepthChartManager.ConsoleApp

This application is open for extension like Adding more sports and Adding more teams
