using System;

class MainClass {
  public static void Main (string[] args) {
    Cave cave = new Cave();
    cave.move("right");
    cave.move("down");
    cave.move("right");
    cave.move("left");
    cave.move("down");
    cave.move("right");
    cave.move("up");
    Console.WriteLine(cave.getPosition());
  }
}

public class Cave{
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
  } 

  public bool move(String direction){
    if(direction == "right"){
      x = (x+1) % 6;
    } else if(direction == "left"){
      x = (x-1) % 6;
    }else if(direction == "down"){
      y = (y+1) % 5;
    } else if (direction == "up"){
      y = (y-1) % 5;
    }   
    return true;
  }
  public int getPosition() {
    return map[y,x];
  }

  
}