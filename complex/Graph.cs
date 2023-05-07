

class Graph<T> {
  private T[,] arr;
  public int x_dim, y_dim;
  
  public Graph(int x_dim, int y_dim){
    this.arr = new T[x_dim, y_dim];
    this.x_dim = x_dim;
    this.y_dim = y_dim;
  }


  public T this[int x, int y]{
    get {return arr[x, y];}
    set {arr[x, y] = value;}
  }
  public T this[Vertex v]{
    get {return arr[v.x, v.y];}
    set {arr[v.x, v.y] = value;}
  }



  public void Fill(T value){
    for(int i = 0; i<x_dim; i++){
      for(int j = 0; j<y_dim; j++){
        arr[i, j] = value;
      }
    }
  }



  public List<Vertex> GetNeighbors(Vertex v){
    List<Vertex> neighbors = new List<Vertex>();
    if(v.x > 0){
      neighbors.Add(new Vertex((short)(v.x-1), v.y));
    }
    if(v.x < x_dim-1){
      neighbors.Add(new Vertex((short)(v.x+1), v.y));
    }
    if(v.y > 0){
      neighbors.Add(new Vertex(v.x, (short)(v.y-1)));
    }
    if(v.y < y_dim-1){
      neighbors.Add(new Vertex(v.x, (short)(v.y+1)));
    }
    return neighbors;
  }

  public void Print(){
    for(int y=0; y<arr.GetLength(1); y++){
      for(int x=0; x<arr.GetLength(0); x++){
        Console.Write(arr[x, y] + " ");
      }
      Console.WriteLine();
    }
  }
}












