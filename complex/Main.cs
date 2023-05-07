class MainClass
{
    public static void Main(string[] args)
    {
        // Vertex t = new Vertex(){x = 24, y= 52};
        // Console.WriteLine(t.GetHashCode());
      String line;
      try{
        StreamReader sr = new StreamReader("5x5.map");
        line = sr.ReadLine();
        Tuple<int, int> dimensions;
        if(line != null){
          string[] dim = line.Split(' ');
          dimensions = new Tuple<int, int>(int.Parse(dim[0]), int.Parse(dim[1]));
        } else {
          throw new Exception("File is empty");
        }
        Graph<float> pfmap = new Graph<float>(dimensions.Item1, dimensions.Item2);

        for(int y=0; y<dimensions.Item2; y++){
          line = sr.ReadLine();
          if(line != null){
            string[] costs = line.Split(' ');
            for(int x=0; x<dimensions.Item1; x++){
              pfmap[x, y] = float.Parse(costs[x]);
            }
          } else {
            throw new Exception("File is too short");
          }
        }


        // DSLBase dsl = new DSLBase(pfmap);
        // DSLBase.Pathfinder pf = new DSLBase.Pathfinder(dsl);
        // List<Vertex> path = pf.Pathfind(new Vertex(0, 0), new Vertex(4, 4));
        // DSLBase.Pathfinder.PrintPath(path);
        AStar astar = new AStar(pfmap);
        List<Vertex> path = astar.Pathfinder(new Vertex(0, 0), new Vertex(4, 4));
        AStar.PrintPath(path);

      }
      catch (Exception e){
        Console.WriteLine("Exception: " + e.Message);
      }
    }
}
