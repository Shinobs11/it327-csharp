struct VertexPriority: IComparable<VertexPriority> {
  public Priority priority;
  public Vertex vertex;

  public VertexPriority(Vertex vertex, Priority priority){
    this.priority = priority;
    this.vertex = vertex;
  }

  public static bool operator < (VertexPriority lhs, VertexPriority rhs) => (lhs.priority < rhs.priority); 
  public static bool operator > (VertexPriority lhs, VertexPriority rhs) => (lhs.priority > rhs.priority);
  public static bool operator <= (VertexPriority lhs, VertexPriority rhs) => (lhs.priority <= rhs.priority); 
  public static bool operator >= (VertexPriority lhs, VertexPriority rhs) => (lhs.priority >= rhs.priority);

  public override int GetHashCode()
  {
    return vertex.GetHashCode();
  }

  public int CompareTo(VertexPriority other)
  {
    return priority.CompareTo(other.priority);
  }

  public static implicit operator Priority(VertexPriority pv) => pv.priority;
  public static implicit operator Vertex(VertexPriority pv) => pv.vertex;














  
}