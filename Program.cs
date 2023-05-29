using System.Threading;
using System;

namespace Wizard_game{

    class Wizard{

        // to create the variables of the Wizard

        /* all the game methods & variables: 
            total variables: 8       
            total methods: 9 (8 wizard related)

            names:
                wizard
                normal spell
                special spell
                potion

            integer variables:
                hp
                damage
                spellSlots
                experience points
            
            methods:
                wizard actions:
                    normal spell
                    special spell
                    healing
                    meditating
                
                external:
                    asking for user move
                    stating wizard stats
                    stating spell slots
                    stating wizard hp

                useful:
                    line break

        */
         
        public string name;
        public string favSpell;
        public string potion;
        public string special;


        public int damage;
        public int hp;
        public int spellSlots;
        public static int Count;

        public double experience;

        /* 
        creating a constructor(class)
        we can also have default values 
        to add custom values, we would have parameters */


        // defining values
        public Wizard(string _name, string _favSpell, string _potion, string _special){

            // defaults
            spellSlots = 3;
            experience = 0f;
            damage = 10;
            hp = 100;

            

            potion = _potion;
            name = _name;
            favSpell = _favSpell;
            special = _special;

            Count += 1;
        }



        // castSpell method
        public void castSpell(string other, int damage2){
            if (spellSlots > 0){
            
            Console.WriteLine(name + " casts " + favSpell + "  Damage (" + damage2 + "): to " + other);
            spellSlots -= 1;
            experience += 1f;

            }
            else{
                Console.WriteLine(name + " is out of spell slots. ");
            }
        }
        

        // meditate method to gain spell slots
        public void Meditate(){
            Console.WriteLine("Meditating... ");
            Thread.Sleep(1000);

            Console.WriteLine("3");
            Thread.Sleep(1000);
            Console.WriteLine("2");
            Thread.Sleep(1000);
            Console.WriteLine("1");
            Thread.Sleep(1000);


            Console.WriteLine("Back to 3 spell slots! ");
            spellSlots = 3;
        }


        // heal potion 
        public void heal(){
            if (spellSlots > 0){

                Console.WriteLine(name + " has used " + potion + " potion ");
                experience += 0.5f;
                hp += 20;
                if (hp >=100){
                    Console.WriteLine("Full health achieved");
                    hp = 100;
                    Thread.Sleep(2000);
                }
                else if(hp<= 0){
                    hp = 0;
                }
            }
        }

        // special move
        public void special_move(string other){ 

            if (spellSlots > 1 && experience >= 5){
                Console.WriteLine(name + " has casted " + special + "  Damage(45) --> " + other);
            }
            else if (spellSlots > 1 && experience >= 3){
            Console.WriteLine(name + " has casted " + special + "  Damage(35) --> " + other );
            }
            else if (spellSlots > 1){
                Console.WriteLine(name + " has casted " + special + "  Damage(25) --> " + other);
            }
            else{
                Console.WriteLine(name + " is out of spell slots. ");
            }

            if (spellSlots > 1){
                spellSlots -= 2;
                experience += 2f;
            }
        }


        // end of moves



        // user info
        public void stats(int damage3){
            Console.WriteLine(name + "stats -->     Hp: " + hp + "     Experience: " + experience + "    Damage potential: " +  damage3);
        }

        public void wiz_move(){
            Console.WriteLine("Choose:  cast spell('a')   special move('b')    heal('c')   meditate('d') ");
        }

        public void t_slots(){
            if (spellSlots == 0){
                Console.WriteLine(name + " has " + spellSlots + " spell slots. Please meditate. ");
            }
            else{
                Console.WriteLine("Spell slots: " + spellSlots);
            }

        }   

        public void user_hp(){
            Console.WriteLine("Hp: " + hp);
        }    

        }

        // end of info




    class Program{

        // easier to create line breaks
        static void n(){
            Console.WriteLine(" ");
        }
      
        
        static void Main(string[] args) // static makes a variable shared to all the instances of a class
        {
            string skip = "false";

            int rounds = 0;

            while (true){
            
                // game instructions
                Console.WriteLine("This is a game where you will play as a game character against an ai. You can do different moves such as: \nMeditate to get back spell slots(start & max = 3) \nHeal to increase hp by 20(starting & max is 100)\nCast a spell(uses 1 spell slots) or special move(2 spell slots) to damage the ai \nEach move allows you to gain experience points which will increase damage as the game goes on");

                Console.WriteLine("Enter your character details: ");
                Console.WriteLine("Wizard name: ");
                string wiz_name = Console.ReadLine();

                Console.WriteLine("Normal spell: ");
                string wiz_spell = Console.ReadLine();

                Console.WriteLine("Heal potion:");
                string potion= Console.ReadLine();

                Console.WriteLine("Special spell:");
                string special = Console.ReadLine();

                Wizard wizard01 = new Wizard(wiz_name, wiz_spell, potion, special);

                
                Wizard enemy = new Wizard("Lord Voldermort", "Expelliarmus", "Avada kedavra", "Crucio");
                
                //  external/internal game variables
                int t_turns = 0;
                int damage = 10;
                int damage1 = 10;


                if (rounds == 0){
                    Console.WriteLine("\nLet the game begin! "); 
                }
                else{
                    Console.WriteLine("----- Round " + (rounds +1) + " ------");
                }

                Console.WriteLine("--------- " + wizard01.name + "'s turn --------");

                // 1v1 game with an ai or player
                while (true){

                    // tell number of available slots
                    wizard01.t_slots();    
                    wizard01.user_hp();

                    wizard01.wiz_move();
                    string move = Console.ReadLine();

                    while (move != "a" && move != "b" && move != "c" && move != "d"){
                        Console.WriteLine("Enter a valid option: ");
                        move = Console.ReadLine();

                    }

                    // user turn

                    // 1st move
                    if (move == "a"){
                        wizard01.castSpell(enemy.name, damage);
                        enemy.hp -= damage; 
                        damage += 2;

                    }

                    // second move
                    else if(move == "b"){
                        string no_slots = "false";
                        if (wizard01.spellSlots <= 1){
                            no_slots = "true";
                        }

                        double experience = wizard01.experience; // to check experience before increase   
                        wizard01.special_move(enemy.name);


                        if (no_slots== "false"){     
                            if (experience >= 5){
                                enemy.hp -= 45;
                            }
                            else if (experience >= 3){
                                enemy.hp -= 35;
                            }
                            else{
                                enemy.hp-= 25;
                            }
                        }
                    }

                    // third move
                    else if (move == "c"){
                        wizard01.heal();
                    }

                    else{
                        wizard01.Meditate();
                    }

                    t_turns += 1;

                    // to check if user has won
                    if(enemy.hp <= 0){
                        Console.Write("You have won! \nThank you for playing! ");
                        rounds += 1;
                        break;
                    }

                    enemy.user_hp(); // remove
            

                    // end of user turn



                    Thread.Sleep(1500);
                    // declare turn
                    n();
                    Console.WriteLine("--------- " + enemy.name + " turn --------");
                    // end of delaration




                    // ai turn 

                    Random numgen = new Random();
                    int enemy_turn = numgen.Next(0, 4);

                    Thread.Sleep(2000);      

                    enemy.t_slots();  

                    if (enemy.spellSlots == 0){ // to make sure it meditates on zero slots
                        enemy.Meditate();
                    }
                    else if (enemy.hp >= 30 && enemy.hp <= 45){ // heal if low hp
                        enemy.heal();
                    }
                    else if (enemy_turn == 0 || wizard01.hp <= 40){ // increase difficulty by adding or
                        enemy.castSpell(wizard01.name, damage1);
                        wizard01.hp -= damage1;
                        damage1 +=2;

                    }
                    else if(enemy_turn == 1 && enemy.spellSlots > 1){
                        double experience1 = enemy.experience; // to check experience before increase
                        enemy.special_move(wizard01.name);
                        if (enemy.spellSlots > 1 && experience1 >= 5){
                            wizard01.hp -= 45;
                        }
                        else if (enemy.spellSlots > 1 && experience1 >= 3){
                            wizard01.hp -= 35;
                        }
                        else if (enemy.spellSlots > 1){
                            wizard01.hp-= 25;
                        }
                    }

                    else if (enemy_turn ==  2){
                        enemy.heal();
                    }

                    else if (enemy_turn == 3 && enemy.spellSlots <= 1){
                        enemy.Meditate();
                    }
                    else{ // in case special spell is selected even though there is only 1 slot, or meditate even though there are enough slots
                        enemy.castSpell(wizard01.name, damage1);
                    }

                    t_turns += 1;

                    // to check if ai has won
                    if(wizard01.hp <= 0){
                        Console.Write("You have lost! \nThank you for playing! ");
                        rounds += 1;
                        break;
                    }

                    Thread.Sleep(2000);

        

                    // end of ai/user turn


                    // to display both stats every 6 turns

                    if (t_turns % 6 == 0){
                        wizard01.stats(damage);
                        enemy.stats(damage1);  
                        Thread.Sleep(2000);           
                    }

                    // declare turn
                    n();
                    Console.WriteLine("--------- " + wizard01.name + "'s turn --------");
                    // end of declaration      
                    
                }

                // end of main code

                Console.WriteLine("Would you like to play again('yes' or 'no'): ");
                string choice = Console.ReadLine();

                while (choice != "yes" && choice != "no"){
                    Console.WriteLine("Please enter 'yes' or 'no'");
                    choice = Console.ReadLine();     
                }

                if (choice == "yes"){
                    Console.WriteLine("New game beginning in ...");
                    Thread.Sleep(1000);
                    Console.WriteLine("3 ");
                    Thread.Sleep(1000);
                    Console.WriteLine("2 ");
                    Thread.Sleep(1000);
                    Console.WriteLine("1 ");
                    Thread.Sleep(1000);
                }
                else{
                    break;
                }

                // wait before closing            

            }
        }
    }
}
