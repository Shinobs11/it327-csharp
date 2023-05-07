struct Vertex {
  public short x, y;
  public Vertex(short x, short y){
    this.x = x;
    this.y = y;
  }



  public override string ToString(){
    return "(" + x + ", " + y + ")";
  }

  public override int GetHashCode(){
        return 32768*x + y;
  }

  public override bool Equals(object obj){
    if(obj is Vertex){
      Vertex v = (Vertex) obj;
      return (v.x == this.x) && (v.y == this.y);
    } else {
      return false;
    }
  }
  public static bool operator ==(Vertex v1, Vertex v2){
    return (v1.x == v2.x) && (v1.y == v2.y);
  }
  public static bool operator !=(Vertex v1, Vertex v2){
    return (v1.x != v2.x) || (v1.y != v2.y);
  }
}