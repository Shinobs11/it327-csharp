//Overarching class with everything enemies and players must have
namespace battleTime{
class Character{
    public string name;
    protected int level=1;
    protected int health=10;
    protected int attack=10;
    protected int mana=10;
    protected int speed=10;
    protected int defense=6;
    public int takeDamage(int otherAttack, int otherMoveStrength){
        health = health - otherMoveStrength*(otherAttack/defense);
        return health;
    }
    public void displayEncounter(){
        System.Console.WriteLine("A level "+level+" "+name+" appeared!");
    }
    public void giveDamage(Character other, int moveStrength){
        other.takeDamage(attack,moveStrength);
    }
    public int displayHealth(){
        return health;
    }
    public int displaySpeed(){
        return speed;
    }
}
//Here we could bring in code from the select character program if we were trying to make a full game
//This is just focused on inheritance and showing how that can make enemies and players into a turn based battle sequence
class Classes{
    string chosenClass = "Black Mage";
    public string Name(){
        return chosenClass;
    }
}
class Player: Character{
    string[] moveList= new string[4];
    int[] movePower= new int[4];
    public Player(Classes chosenClass){
        //this can be spread out to encompass all classes
        //I also set it to only 4 different moves, this can easily be changed
        if(chosenClass.Name()=="Black Mage"){
            health=health-2;
            attack=attack+2;
            mana=mana+5;
            moveList[0]= "Blaze";
            moveList[1]= "Crack";
            moveList[2]="Whoosh";
            moveList[3]= "Crackle";
            movePower[0]=1;
            movePower[1]=2;
            movePower[2]=2;
            movePower[3]=5;
        
        }
    }
    public int chooseMove(){
        System.Console.WriteLine("Select your move from the following: ");
        bool moveNotValid;
        for(int i=0;i<4;i++){
            int num=i+1;
            System.Console.WriteLine("Select "+num+" for "+moveList[i]);
        }
        string moveChosen =System.Console.ReadLine();
        if(moveChosen=="4" && mana<5){
            System.Console.WriteLine("You don't have enough mana for that try a different move ");
            moveNotValid=true;
        }else{
            moveNotValid=false;
        }
        while(moveChosen !="1" &&moveChosen !="2" &&moveChosen !="3" &&moveChosen !="4" &&moveNotValid ){
         System.Console.WriteLine("Select a valid move from the following: ");
        for(int i=0;i<4;i++){
            int num=i+1;
            System.Console.WriteLine("Select "+num+" for "+moveList[i]);
        }
         moveChosen =System.Console.ReadLine();  
        if(moveChosen=="4" && mana<5){
            System.Console.WriteLine("You don't have enough mana for that try a different move ");
            moveNotValid=true;
        }else{
            moveNotValid=false;
        } 
        }
        if(moveChosen=="1"){
            return movePower[0];
        }else if(moveChosen=="4"){
            mana=mana-5;
            return movePower[3];
        }else{
            return movePower[1];
        }
        
    }

//With this it is very easy to add many different enemies with different stats
}
class Ork: Character{
    public Ork(){
    level=1;
    defense= 5;
    attack=10;
    mana=0;
    speed=3;
    health=10;
    name = "Ork";
    }   
}
class Troll: Character{
    public Troll(){
    level=2;
    defense= 6;
    attack=12;
    mana=0;
    speed=7;
    health=22;
    name = "Troll";
    }
}



    class Battle {         
        static void Main(string[] args)
        {
            //battle sequence so it can be reused
            void BattleTime(Character enemy, Player player){
                 enemy.displayEncounter();
                bool playerFirst;
                if(player.displaySpeed()>enemy.displaySpeed()){
                    playerFirst = true;
                }else{
                     playerFirst= false;
                }
                while(enemy.displayHealth()>0 && player.displayHealth()>0){
                    if(playerFirst&&player.displayHealth()>0){
                        player.giveDamage(enemy,player.chooseMove());
                        playerFirst=false;
                    }
                    if(!playerFirst&&enemy.displayHealth()>0){
                        enemy.giveDamage(player,1);
                        playerFirst=true;
                    }
                 System.Console.WriteLine("Player health after turn: "+player.displayHealth());
                System.Console.WriteLine("Enemy health after turn: "+enemy.displayHealth());
                }
                if(player.displayHealth()<0){
                    System.Console.WriteLine("You Lose, Game Over");
                }else{
                    System.Console.WriteLine("Congrats! you defeated the enemy!");
                }
            }
            Classes newClass = new Classes();
            Player player1 = new Player(newClass);
            Ork ork = new Ork();
            Ork ork2 = new Ork();
            Troll troll = new Troll();
            BattleTime(ork,player1);
            BattleTime(troll,player1);
            BattleTime(ork2,player1);
        }
    }
}
