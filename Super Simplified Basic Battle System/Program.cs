using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WMPLib;
//somehow can't use actually get WMPLib without it getting underlined so I can't use .mp3 files ):

namespace Super_Simplified_Basic_Battle_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new WMPLib.WindowsMediaPlayer();
            player.URL = @"C:\Users\ibren\Documents\Visual Studio 2015\Projects\Super Simplified Basic Battle System\Super Simplified Basic Battle System\Blinded by Light FFXIII Use.wav";

            //System.Media.SoundPlayer battle = new System.Media.SoundPlayer();
            //battle.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Blinded by Light FFXIII Use.wav";
            //battle.Play();

            System.Media.SoundPlayer effect = new System.Media.SoundPlayer();

            int enemyhp = 70;
            int enemymp = 15;
            int enemyatk = 10;
            int enemydef = 5;
            int enemymagatk = 15;
            int enemymagdef = 5;

            int yourhp = 45;
            int yourmp = 18;
            int youratk = 15;
            int yourdef = 3;
            int yourmagatk = 25;
            int yourmagdef = 20;

            int yoursaveddef = yourdef;

            bool gameover = false;

            bool enemyscanned = false;


            int potion = 4;
            int ether = 2;

            Random chance = new Random();
            int misschance = 0;
            int hitchance = 0;

            Console.WriteLine("The enemy appeared!");

            while (gameover == false)
            {
                int exiting = 2;
                Console.WriteLine("Enemy HP: {0} Your HP: {1}", enemyhp, yourhp);
                Console.WriteLine("Enemy MP: {0} Your MP: {1}", enemymp, yourmp);

                if (hitchance == 1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("...");

                    int savedyourattack = youratk;

                    int yourtrueatk = randomizedattack.atk(youratk);

                    // Console.WriteLine("Value of attack: {0}", yourtrueatk);

                    double yourtruerealatk = yourtrueatk * 2.3;
                    Math.Round(yourtruerealatk, 0, MidpointRounding.AwayFromZero);
                    int yourtruerealatkrounded = Convert.ToInt32(yourtruerealatk);

                    yourtrueatk = yourtruerealatkrounded - enemydef;

                    enemyhp = enemyhp - yourtruerealatkrounded;
                    Console.WriteLine("The enemy heavily took {0} damage!", yourtruerealatkrounded);
                    // Console.WriteLine("Value of true final attack: {0}", yourtruerealatkrounded);
                    youratk = savedyourattack;
                    hitchance = 0;
                    goto EnemyPhase;

                }

                if (misschance == 1)
                {

                    var effecttious = new WMPLib.WindowsMediaPlayer();
                    effecttious.URL = @"C:\Users\ibren\Documents\Visual Studio 2015\Projects\Super Simplified Basic Battle System\Super Simplified Basic Battle System\The Price is Right losing horn lose.mp3";

                    Console.WriteLine("");
                    Console.WriteLine("...");
                    Console.WriteLine("You strike with all of your might!");
                    Console.WriteLine("...but you missed!");
                    misschance = 0;
                    goto EnemyPhase;
                }

                Console.WriteLine("What is your next action? Type either; attack, magic, defend, skills, status, or item to act this turn.");

                string act = Console.ReadLine();

                if (act.Equals("attack", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("");

                    int savedyourattack = youratk;

                    int yourtrueatk = randomizedattack.atk(youratk);
                    yourtrueatk = yourtrueatk - enemydef;
                    enemyhp = enemyhp - yourtrueatk;
                    Console.WriteLine("The enemy took {0} damage!", yourtrueatk);
                    //Console.WriteLine("Value of true final attack: {0}", yourtrueatk);
                    youratk = savedyourattack;

                }

                if (act.Equals("defend", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("");
                    yourdef = yourdef + 5;
                    Console.WriteLine("Your defences increased for this turn only!");
                }

                if (act.Equals("item", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("");
                    items:
                    Console.WriteLine("You have...");
                    Console.WriteLine("Potion (Restores 25 HP)x {0}", potion);
                    Console.WriteLine("Ether (Restores 10 MP)x {0}", ether);
                    Console.WriteLine("Type Potion, or Ether to act.");
                    string actitem = Console.ReadLine();

                    if (actitem.Equals("potion", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (potion == 0)
                        {
                            Console.WriteLine("You have ran out of potions.");
                            //goto items;
                            goto EnemyPhase;
                        }
                        if (yourhp == 45)
                        {
                            Console.WriteLine("You already have full HP.");
                            //goto items;
                            goto EnemyPhase;
                        }


                        else
                        {

                            if (yourhp >= 20)
                            {
                                potion = potion - 1;
                                yourhp = 45;
                                Console.WriteLine("Your HP has been healed to the max!");
                                goto EnemyPhase;
                            }
                            else if (yourhp < 20)
                            {
                                potion = potion - 1;
                                yourhp = yourhp + 25;
                                Console.WriteLine("Your HP is now {0}!", yourhp);
                                goto EnemyPhase;
                            }
                        }
                    }

                    if (actitem.Equals("ether", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (ether == 0)
                        {
                            Console.WriteLine("You have ran out of ethers.");
                            //goto items;
                            goto EnemyPhase;
                        }
                        if (yourmp == 18)
                        {
                            Console.WriteLine("You already have full MP.");
                            //goto items;
                            goto EnemyPhase;
                        }
                        else
                        {

                            if (yourmp >= 8)
                            {
                                ether = ether - 1;
                                yourmp = 18;
                                Console.WriteLine("Your MP has been restored to the max!");
                                goto EnemyPhase;
                            }
                            else if (yourmp < 8)
                            {
                                ether = ether - 1;
                                yourmp = yourmp + 10;
                                Console.WriteLine("Your MP is now {0}!", yourmp);
                                goto EnemyPhase;
                            }
                        }
                    }

                    if (act.Equals("back", StringComparison.CurrentCultureIgnoreCase))
                    {
                        //goto Back;
                    }

                }

                if (act.Equals("magic", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("");
                    Console.WriteLine("You use fire magic! (It costs 7 MP!)");

                    {
                        if (yourmp < 7)
                        {
                            Console.WriteLine("However, you do not have enough MP!");
                            //goto Back;
                        }

                        else if (yourmp >= 7)
                        {
                            yourmp = yourmp - 7;
                            int savedyourmagattack = yourmagatk;

                            int yourtruemagatk = randomizedattack.atk(yourmagatk);
                            yourtruemagatk = yourtruemagatk - enemymagdef;
                            enemyhp = enemyhp - yourtruemagatk;
                            Console.WriteLine("The enemy took {0} damage!", yourtruemagatk);
                            //Console.WriteLine("Value of true final attack: {0}", yourtrueatk);
                            yourmagatk = savedyourmagattack;
                        }
                    }


                }

                if (act.Equals("status", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Your current stats are...");
                    Console.WriteLine("HP: {0}", yourhp);
                    Console.WriteLine("MP: {0}", yourmp);
                    Console.WriteLine("Attack: {0}", youratk);
                    Console.WriteLine("Defence: {0}", yourdef);
                    Console.WriteLine("Magic Attack: {0}", yourmagatk);
                    Console.WriteLine("Magic Defence: {0}", yourmagdef);
                    Console.WriteLine("");

                    if (enemyscanned == true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Also, because you scanned the enemy, here are their stats!");
                        Console.WriteLine("HP: {0}", enemyhp);
                        Console.WriteLine("MP: {0}", enemymp);
                        Console.WriteLine("Attack: {0}", enemyatk);
                        Console.WriteLine("Defence: {0}", enemydef);
                        Console.WriteLine("Magic Attack: {0}", enemymagatk);
                        Console.WriteLine("Magic Defence: {0}", enemymagdef);

                    }
                }

                if (act.Equals("skills", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("You know of only two skills; scan and chance. Scan needs 1 MP to be used, and chance needs 2 MP to be used.");
                    string actskill = Console.ReadLine();

                    if (actskill.Equals("scan", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (yourmp <= 0)
                        {
                            Console.WriteLine("However, you do not have enough MP to use this skill!");
                            //goto Back;

                        }
                        else if (yourmp >= 1)
                        {
                            enemyscanned = true;
                            Console.WriteLine("Your enemy's stats are...");
                            Console.WriteLine("HP: {0}", enemyhp);
                            Console.WriteLine("MP: {0}", enemymp);
                            Console.WriteLine("Attack: {0}", enemyatk);
                            Console.WriteLine("Defence: {0}", enemydef);
                            Console.WriteLine("Magic Attack: {0}", enemymagatk);
                            Console.WriteLine("Magic Defence: {0}", enemymagdef);
                            yourmp = yourmp - 1;


                        }
                        goto EnemyPhase;
                    }
                    if (actskill.Equals("chance", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (yourmp <= 1)
                        {
                            Console.WriteLine("However, you do not have enough MP to use this skill!");
                            //goto Back;

                        }
                        else if (yourmp>=2)
                        {
                            int chanced = chance.Next(0, 100);
                            Console.WriteLine("You prepare for a strong hit-or-miss attack!");
                            if (chanced >= 50)
                            {
                                misschance = 1;

                            }
                            if (chanced < 50)
                            {
                                hitchance = 1;
                            }

                        }

                        // C H E C K   T H E   M P   U S A G E   B E T W E E N   S K I L L S ! ! ! ! !

                    }
                    //goto Back;
                }
                if (enemyhp == 0)
                {

                    Console.WriteLine("You've won and the world is saved! The end!! :)");
                    Console.ReadLine();
                    break;
                }

                if (enemyhp < 0)
                {

                    Console.WriteLine("You've won and the world is saved! The end!! :)");
                    Console.ReadLine();
                    break;
                }

                EnemyPhase:

                Console.WriteLine("The enemy attacks!");

                int savedyourenemyattack = enemyatk;

                int yourtrueenemyatk = randomizedattack.atk(enemyatk);

                yourtrueenemyatk = yourtrueenemyatk - yourdef;
                yourhp = yourhp - yourtrueenemyatk;
                Console.WriteLine("You took {0} damage!", yourtrueenemyatk);
                Console.WriteLine("");
                //Console.WriteLine("Value of true final attack: {0}", yourtrueenemyatk);
                enemyatk = savedyourenemyattack;

                

                if (yourhp == 0)
                {
                    
                    Console.WriteLine("Oh no, you've been defeated! Now you go to milkshake prison!! ):");
                    Console.ReadLine();
                    break;
                }

                if (yourhp < 0)
                {

                    Console.WriteLine("Oh no, you've been defeated! Now you go to milkshake prison!! ):");
                    Console.ReadLine();
                    break;
                }

                yourdef = yoursaveddef;

            }
        }
    }

    public class randomizedattack
    {

        

        public static int atk(int attack)
        {
            Random atk = new Random();

            double randomatk1 = 0;

            //Console.WriteLine("Value of inputting attack: {0}", attack);

                   randomatk1 = atk.Next(75, 125);

            //Console.WriteLine("Value of random number: {0}", randomatk1);

            double randomatk2 = randomatk1/100;

            //Console.WriteLine("Value of random number divided by 100: {0}", randomatk2);

            double multipliedattack = attack * randomatk2;

            Math.Round(multipliedattack, 0, MidpointRounding.AwayFromZero);

            attack = Convert.ToInt32(multipliedattack);

            //Console.WriteLine("Value of inputting attack multiplied by randomness: {0}", attack);

            int randomcrit = atk.Next(0, 100);


            //if (element its weak to = true)
            //xattack = xattack * 1.5
            int attacked = 0;

            if (randomcrit <= 10)
            {
                attack = attack * 3;
                Console.WriteLine("It was a critical attack!");
                //Console.WriteLine("Value of final attack: {0}", attack);
                attacked = attack;
                

            }
            if (randomcrit > 10)
            {
                attack = attack * 1;
               // Console.WriteLine("Value of final attack: {0}", attack);
                attacked = attack;
            }
           // Console.WriteLine("Value of attacked: {0}", attacked);
            return attacked;
        }



    }


    // E X T R E Y   E X T R E Y   E X T R E Y   R E A D   A L L   A B O U T   I T ! ! ! ! ! 


    class Program2
    {
        static void Mainy(string[] args)
        {
            Console.WriteLine("Special Websites! :D");
            Console.WriteLine("https://msdn.microsoft.com/en-us/dn308572.aspx");
            Console.WriteLine("https://www.pluralsight.com/");
            Console.WriteLine("https://www.lynda.com/");
            Console.WriteLine("Check GameTheory for video editing sayings on a video for lynda on a vid previously watched...");
            Console.WriteLine("Also check XNA Game Microsoft");
        }

    }
 

    class test
    {
        static void Main()
        {
            long longValue = 12345;
            int intValue = (int)longValue;
            int peoples = 32;
            Console.WriteLine("(int) {0} = {1}", longValue, intValue); // The (int) {0} = {1} tells the program to take the format of x = y, where
                                                                       //the integer of the first value (0, which is longvalue) takes x, and
                                                                       //the integer of the second value (1, which is intValue) takes y.
            Console.WriteLine(" Hello {{peoples}}", peoples);
            Console.WriteLine("(int) (0) = (1)", longValue, intValue); //Doesn't format
            Console.WriteLine("(int) [0] = [1]", longValue, intValue); //Doesn't format
            Console.ReadLine();                                        //Keeps the console open


        }
    }

    class jaggedArrays
    {

        static void Main()
        {
            int[] arr = new int[4]; //this tells how many times it will be repeated, so that it will be less than its length 
                                    //so it doesn't exceed its number repeated that amount of times.
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i * i;
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine("arr[{0}] = {1}", i, arr[i]); //Inside curleys is called token
            Console.ReadLine();
        }


    }

    class testytest
    {
        static void Main()
        {
            int i = 1234;
            string s = i.ToString();
        }

    }

    class boxing_and_unboxing
    {
        static void Main()
        {
            int i = 123;
            object o = i;   //boxing
            int j = (int)o; //unboxing

        }

    }
    public class AbsVal
    {
        static void Main()
        {
            AbsVal myval = new AbsVal(); //A new instance of a new class with info 
                                         //inside to be manipulated must have a = new <classnamehere>();
            myval.Val = -500;
            Console.WriteLine("Value is now {0}", myval.Val);
            Console.ReadLine();

        }
        private int ival;
        public int Val
        {
            get
            {
                return ival;
            }

            set
            {
                if (value < 0)
                    ival = -value;
                else
                    ival = value;
            }
        }
    }

    class Foo
    {
        public void MyMethod(out int outParam, ref int inAndOutParam) //Out = Used in different static sections. 
                                                                      //ref = Reference of the REAL value, as if it was a copy. Also like out.
        {
            outParam = 123;
            inAndOutParam += 10;

        }
        public static void Main()
        {
            int outParam;
            int inAndOutParam = 10;
            Foo f = new Foo();
            f.MyMethod(out outParam,
                ref inAndOutParam);

            Console.ReadLine();
        }
    }




}
