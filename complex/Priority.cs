struct Priority: IComparable<Priority> {
  float k1, k2;

  public Priority(float k1, float k2){
    this.k1 = k1;
    this.k2 = k2;
  }

  public int CompareTo(Priority other)
  {
    if(this.k1 < other.k1){
      return -1;
    } else if(this.k1 > other.k1){
      return 1;
    } else {
      if(this.k2 < other.k2){
        return -1;
      } else if(this.k2 > other.k2){
        return 1;
      } else {
        return 0;
      }
    }
  }


  /* 
    Given two priorities, p1 and p2, p1 < p2 if:
      (p1.k1 < p2.k1) OR ((p1.k1 == p2.k1) AND (p1.k2 < p2.k2))
    Likewise p1 <= p2:
      (p1.k1 < p2.k1) OR ((p1.k1 == p2.k1) AND (p1.k2 <= p2.k2))
  */
  public static bool operator < (Priority lhs, Priority rhs) => ((lhs.k1 < rhs.k1) || ((lhs.k1 == rhs.k1) && (lhs.k2 < rhs.k2))); 
  public static bool operator > (Priority lhs, Priority rhs) => ((lhs.k1 > rhs.k1) || ((lhs.k1 == rhs.k1) && (lhs.k2 > rhs.k2)));
  public static bool operator <= (Priority lhs, Priority rhs) => ((lhs.k1 < rhs.k1) || ((lhs.k1 == rhs.k1) && (lhs.k2 <= rhs.k2))); 
  public static bool operator >= (Priority lhs, Priority rhs) => ((lhs.k1 > rhs.k1) || ((lhs.k1 == rhs.k1) && (lhs.k2 >= rhs.k2)));

  

}


