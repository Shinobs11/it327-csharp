

class AStar{

  int x_dim, y_dim;
  // Vertex  origin_pos = new Vertex(-1, -1),
  //         last_pos = new Vertex(-1, -1),
  //         current_pos = new Vertex(-1, -1),
  //         target_pos = new Vertex(-1, -1);
  // Graph<float> g, rhs;
  // PriorityQueueSet openList = new PriorityQueueSet();
  PriorityQueue<Vertex, float> open = new PriorityQueue<Vertex, float>();
  // Dictionary<Vertex, Vertex?> came_from = new Dictionary<Vertex, Vertex?>();
  // Dictionary<Vertex, float> cost_so_far = new Dictionary<Vertex, float>();
  Graph<Vertex?> came_from;
  Graph<float> accumulated_cost;

  Graph<float> cost;


  // float k_m;
  float D = float.PositiveInfinity;


  public AStar(Graph<float> costmap){
    this.x_dim = costmap.x_dim;
    this.y_dim = costmap.y_dim;
    this.cost = costmap;
    this.came_from = new Graph<Vertex?>(x_dim, y_dim);
    this.accumulated_cost = new Graph<float>(x_dim, y_dim);

    this.accumulated_cost.Fill(float.PositiveInfinity);
    for(int i = 0; i<x_dim; i++){
          for(int j = 0; j<y_dim; j++){
            if(D > cost[i, j]){
              D = cost[i, j];
            }
          }
        }

  }

  private float Heuristic(Vertex p_0, Vertex p_f){
    //Manhattan distance
    return D*(Math.Abs(p_f.x - p_0.x) + Math.Abs(p_f.y - p_0.y));
  }
  private float Cost(Vertex v0, Vertex vf){
    return this.cost[vf];
  }


  private List<Vertex> ReconstructPath(Vertex start_pos, Vertex target_pos){
    Vertex current_pos = target_pos;
    List<Vertex> path = new List<Vertex>();

    if(came_from[target_pos] == null){
      Console.WriteLine("No path found.");
      return path;
    }
    while (current_pos != start_pos){
      path.Add(current_pos);
      if (came_from[current_pos] != null){
        current_pos = (Vertex) came_from[current_pos];
      }
      else{
        Console.WriteLine("Null came_from value found");
        return path;
      }
    }
    path.Add(start_pos);
    path.Reverse();
    return path;

  }


  public List<Vertex> Pathfinder(Vertex start_pos, Vertex target_pos){
    open.Enqueue(start_pos, 0);
    came_from[start_pos] = null;
    accumulated_cost[start_pos] = 0;
    
    while(open.Count != 0){
      Vertex current_pos = open.Dequeue();
      if (current_pos == target_pos){
        break;
      }
      foreach(Vertex next_pos in cost.GetNeighbors(current_pos)){
        float new_cost = accumulated_cost[current_pos] + Cost(current_pos, next_pos);
        if (new_cost < accumulated_cost[next_pos]){
          accumulated_cost[next_pos] = new_cost;
          float priority = new_cost + Heuristic(next_pos, target_pos);
          open.Enqueue(next_pos, priority);
          came_from[next_pos] = current_pos;
        }
      }
    }

    return ReconstructPath(start_pos, target_pos);
    
  }

  public static void PrintPath(List<Vertex> path){
  foreach(Vertex v in path){
    Console.WriteLine(v);
  }
}
}


