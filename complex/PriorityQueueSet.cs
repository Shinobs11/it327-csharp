




class PriorityQueueSet {

  private SortedSet<VertexPriority> pq;
  private Dictionary<Vertex, VertexPriority> dict;
  public PriorityQueueSet(){
    this.pq = new SortedSet<VertexPriority>();
    this.dict = new Dictionary<Vertex, VertexPriority>();
  }


  public void Insert(Vertex v, Priority p){
    this.pq.Add(new VertexPriority(v, p));
    this.dict.Add(v, new VertexPriority(v, p));
  }

  public Vertex Dequeue(){
    VertexPriority pv = this.pq.Min;
    this.pq.Remove(pv);
    this.dict.Remove(pv.vertex);
    return pv.vertex;
  }

  public bool Contains(Vertex v){
    return this.dict.ContainsKey(v);
  }

  public void Remove(Vertex v){
    VertexPriority pv = this.dict[v];
    this.pq.Remove(pv);
    this.dict.Remove(v);
  }

  public void UpdatePriority(Vertex v, Priority p){
    this.Remove(v);
    this.Insert(v, p);
  }


  public Vertex Top(){
    return this.pq.Min.vertex;
  }
  
  public Priority TopKey(){
    return this.pq.Min.priority;
  }

  public Boolean isEmpty(){
    return this.pq.Count == 0;
  }

}