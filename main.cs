using System;
using System.IO;

class MainClass {
  public static void Main (string[] args) {
    Cave cave = new Cave();
    Console.WriteLine(cave.getPosition());
  }
}

public class Cave{
  private StreamWriter log;
  public string[] moves = {"down","down right","down left","up","up right","up left"};
  public int x { get; set; }
  public int y { get; set; }
  private int [,] map = new int[,] {
    {1,2,3,4,5,6},
    {7,8,9,10,11,12},
    {13,14,15,16,17,18},
    {19,20,21,22,23,24},
    {25, 26, 27, 28, 29, 30}
  };

  public Cave(){
   x = 0;
   y = 0;
   this.log = new StreamWriter("log steps.txt");
   shuffle();
  } 
// shuffles the options so the three options are random
 private void shuffle(){
   for(int i = 0; i < 16; i++){
     int firstIndex = new Random().Next(0, 6);
     int secondIndex = new Random().Next(0, 6);

     String temp = moves[firstIndex];
     moves[firstIndex] = moves[secondIndex];
     moves[secondIndex] = temp;
   }
 }
 public String[] getChoice() {
   return new string[3] {moves[0], moves[1], moves[2]};
 }

  public bool move(String direction){
    string[] choices = getChoice();
    if(!(direction == "left" || direction == "right") && Array.IndexOf(choices, direction) == -1){
      Console.WriteLine(direction);
      Console.WriteLine("illegal move");
      return false;
    }
    if(map[x,y] % 2 == 1){
      if (direction == "down right"){
        return move("right");
      }
      if (direction == "down left"){
        return move("left");
      }
    } else {
      if (direction == "up right"){
        return move("right");
      }
      if (direction == "up left"){
        return move("left");
      }
    }
    if(direction == "down"){
      y = ((((y+1) % 5) + 5) % 5);
    } else if (direction == "up"){
      y = ((((y+1) % 5) + 5) % 5);
    }  else if(direction == "up right"){
      // True mod operator
      x = ((((x+1) % 6) + 6) % 6);
      y = ((((y-1) % 5) + 5) % 5);
    } else if (direction == "up left"){
       x = ((((x-1) % 6) + 6) % 6);
       y = ((((y-1) % 5) + 5) % 5);
    } else if(direction == "down right"){
      // True mod operator
      x = ((((x+1) % 6) + 6) % 6);
      y = ((((y+1) % 5) + 5) % 5);
    } else if (direction == "down left"){
       x = ((((x-1) % 6) + 6) % 6);
       y = ((((y+1) % 5) + 5) % 5);
    } else if(direction == "right"){
      // True mod operator
      x = ((((x+1) % 6) + 6) % 6);
    } else if (direction == "left"){
       x = ((((x-1) % 6) + 6) % 6);
    }
    log.WriteLine(direction);
    log.Flush();
    shuffle();
    return true;
  }
  public int getPosition() {
    return map[y,x];
  }

  
}