# Othello-AI-Player

The game has 3 modes (Human VS Human & Human VS Computer & Computer VS Computer).
The computer player has 4 levels of difficulty from 0 to 3.

----------------------------------------------------------------------------

- We used random playing for level zero.
- For level 1 & 2 we used different implementations from Coin parity algorithm as level 1 try to maximize the number of coins by searching in all possible moves but count the coins that may be flipped for any move only in one direction. And level 2 is more adapted from level 1 by counting the coins in all directions (8 direction).
- Level 3 is max level of difficulty. It’s a static weights heuristic algorism mixed with coin parity algorithm. It calculates maximum coin flip for every possible move then adds static weights heuristic and chooses the positions which will achieve the highest score in the current turn.

