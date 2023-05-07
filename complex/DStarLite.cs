









class DSLBase {

    
    
    Graph<float> costmap;
    
    
    public DSLBase(Graph<float> costmap) {
      this.costmap = costmap;
      

    }
  
  public class Pathfinder {
      
      DSLBase outer;
      int x_dim, y_dim;
      Vertex  origin_pos = new Vertex(-1, -1),
              last_pos = new Vertex(-1, -1),
              current_pos = new Vertex(-1, -1),
              target_pos = new Vertex(-1, -1);
      Graph<float> g, rhs;
      PriorityQueueSet openList = new PriorityQueueSet();
      float k_m;
      float D = float.PositiveInfinity;





      public Pathfinder(DSLBase outer){
        this.outer = outer;
        this.x_dim = outer.costmap.x_dim;
        this.y_dim = outer.costmap.y_dim;

        this.g = new Graph<float>(this.x_dim, this.y_dim);
        this.rhs = new Graph<float>(this.x_dim, this.y_dim);
        for(int i=0; i<this.x_dim*this.y_dim; i++){
          g[i%this.x_dim, i/this.x_dim] = float.PositiveInfinity;
          rhs[i%this.x_dim, i/this.x_dim] = float.PositiveInfinity;
        }
        for(int i = 0; i<outer.costmap.x_dim; i++){
          for(int j = 0; j<outer.costmap.y_dim; j++){
            if(D > outer.costmap[i, j]){
              D = outer.costmap[i, j];
            }
          }
        }
        




      }

      private Tuple<Vertex, float> FindMinimumSuccessor(Vertex u){
        List<Vertex> neighbors = outer.costmap.GetNeighbors(u);
        Vertex min_v = neighbors[0];
        float min_cost = outer.costmap[min_v] + g[min_v];
        for(int i = 1; i<neighbors.Count; i++){
          if(min_cost > Cost(u, neighbors[i]) + g[neighbors[i]]){
            min_cost = Cost(u, neighbors[i]) + g[neighbors[i]];
            min_v = neighbors[i];
          }
        }

        return new Tuple<Vertex, float>(min_v, min_cost);
      }
      // c(s, s') denotes cost of moving from vertex s to vertex s'
      private float Cost(Vertex s, Vertex sp){
        return outer.costmap[sp];
      }

      private Boolean ApproxEqual(float a, float b){
        return Math.Abs(a-b) < 0.1;
      }

      private float Heuristic(Vertex p_0, Vertex p_f){
        //Manhattan distance
        return D*(Math.Abs(p_f.x - p_0.x) + Math.Abs(p_f.y - p_0.y));
      }
      private Priority CalculateKey(Vertex s){
        // float k1 = Math.Min(this.g[s], this.rhs[s]) + Heuristic(s, target_pos) + k_m;
        float k1 = Math.Min(this.g[s], this.rhs[s]) + Heuristic(s, current_pos) + k_m;
        float k2 = Math.Min(this.g[s], this.rhs[s]);
        return new Priority(k1, k2);
      }

      

      private void UpdateVertex(Vertex u) {
        if((!ApproxEqual(g[u], rhs[u])) && openList.Contains(u)) {
          openList.UpdatePriority(u, CalculateKey(u));
        } else if((!ApproxEqual(g[u], rhs[u])) && !openList.Contains(u)) {
          openList.Insert(u, CalculateKey(u));
        } else if((ApproxEqual(g[u], rhs[u])) && openList.Contains(u)) {
          openList.Remove(u);
        }
      }

      private void ComputeShortestPath() {
        while(openList.TopKey() < CalculateKey(current_pos) || rhs[current_pos] > g[current_pos]){
          Vertex u = openList.Top();
          Priority k_old = openList.TopKey();
          Priority k_new = CalculateKey(u);
          if(k_old < k_new){
            openList.UpdatePriority(u, k_new);
          }
          else if (g[u] > rhs[u]){
            g[u] = rhs[u];
            openList.Remove(u);
            foreach(Vertex s in outer.costmap.GetNeighbors(u)){
              if(s != target_pos){
                rhs[s] = Math.Min(rhs[s], outer.costmap[s] + g[u]);
              }
              UpdateVertex(s);
            }
          }
          else{ //we're not even entering this area??
            float g_old = g[u];
            g[u] = float.PositiveInfinity;
            List<Vertex> neighbors = outer.costmap.GetNeighbors(u);
            neighbors.Add(u);
            foreach(Vertex s in neighbors){
              if(ApproxEqual(rhs[s], (Cost(s, u) + g_old))){
                if(s != target_pos){
                  rhs[s] = FindMinimumSuccessor(s).Item2;
                }
              }
              UpdateVertex(s);
            }
          }
        }
      }


      private List<Vertex> ExtractShortestPath(){
        List<Vertex> path = new List<Vertex>();
        Graph<bool> history = new Graph<bool>(x_dim, y_dim);
        Vertex pos = origin_pos;
        history[origin_pos] = true;
        path.Add(pos);

        
        float min_cost;
        Vertex min_pos;
        while(pos != target_pos){
          List<Vertex> neighbors = g.GetNeighbors(pos);
          for(int i = 0; i<neighbors.Count; i++){
            if(history[neighbors[i]] == true){
              neighbors.Remove(neighbors[i]);
              i--;
            }
          }

          min_pos = neighbors[0];
          min_cost = Cost(pos, min_pos) + g[min_pos];
          for(int i = 1; i<neighbors.Count; i++){
            float new_cost = (Cost(pos, neighbors[i]) + g[neighbors[i]]);
            if(new_cost < min_cost){
              min_cost = new_cost;
              min_pos = neighbors[i];
            }
          }
        }

        return path;


      }




      public List<Vertex> Pathfind(Vertex start_pos, Vertex target_pos){
        
        
        this.origin_pos = start_pos;
        this.last_pos = start_pos;
        this.current_pos = start_pos;
        this.target_pos = target_pos;
        this.rhs[target_pos] = 0.0f;
        this.openList.Insert(target_pos, new Priority(Heuristic(start_pos, target_pos), 0.0f));
        
        ComputeShortestPath();


        Graph<float> cost_map_plus_g = new Graph<float>(x_dim, y_dim);

        for(int i = 0; i<g.x_dim; i++){
          for(int j = 0; j<g.y_dim; j++){
            cost_map_plus_g[i, j] = outer.costmap[i, j] + g[i, j];
          }
        }

        cost_map_plus_g.Print();
        List<Vertex> path = new List<Vertex>();
        // List<Vertex> path = ExtractShortestPath();
        // int c = 0;

        // while(!openList.isEmpty()){
        //   c++;
        //   if(c > 100){
        //     Console.WriteLine("No path found");
        //     return path;
        //   }
        //   if(rhs[current_pos] == float.PositiveInfinity){
        //     Console.WriteLine("No path found");
        //     return path;
        //   }
        //   current_pos = FindMinimumSuccessor(current_pos).Item1;
        //   path.Add(current_pos);
        //   Console.WriteLine(current_pos); 
        // }
        return path;

        
      }

      public static void PrintPath(List<Vertex> path){
        foreach(Vertex v in path){
          Console.WriteLine(v);
        }
      }

    }
    
}

