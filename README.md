# ConnectFourHackathon
LET'S PLAY CONNECT FOUR!                                                                   
========================

Welcome to the Connect Four Hackathon!!

For this contest, we will be pitting dev against dev in a Connect Four algorithm showdown!

How it works:
• Every contestant will submit one or more Connect Four bots, each with an algorithm
  determining the bot's next move based on the current board state.
• We will compare bots in a Round Robin tournament. Winner takes all!

How to make a bot:
1. Download this github project and open in Visual Studio.
2. Open the 'ConnectFourBot' project and the 'ConnectFourBot.cs' file.
3. In this file is a dummy bot - feel free to replace the PlayerName and GetNextMove here,
   or make another bot to play against the example.
4. You can add as many bots as you want in this project - just make a new class that extends
   the ArtificialPlayer abstract class.
5. When you're done, build the "ConnectFourBot" project.
6. Grab the resulting .dll (will be dumped into ConnectFour/DLLs folder) and rename it with
   your full name. One dll per person! (can have multiple bots per dll)
7. Submit the .dll here:
https://advicent.sharepoint.com/:f:/s/AdvicentSocial/EmFDaUKLDDVCrAAk7nSUTw8Bvvk9m3Q5fX9HD6cGoN-Zdg?e=p4fZ83

How to test your bot:
• Run the solution in VS. A prompt should open.
• There are two options:
  • bot vs bot (can even do your bot versus itself!)
  • You vs bot
• If you'd like to practice against someone else's bot...
  1. Have the other person build the "ConnectFourBot" project with their bot in it.
  2. Copy the resulting dll, rename it, and drop it into your own 'DLLs' folder in the
     project.
  3. Run the game - their bot should now show up in the list!

Things to note:
** PLEASE set the PlayerName to a unique identifier for your bot - this is how we know who
   wins/loses!
** If your bot returns an invalid move, it will be prompted again. Any bot that returns
   10 invalid moves in a row automagically forfeits the match.
