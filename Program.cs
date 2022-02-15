///ETML
///Andre Nyfeler
///Exercice 3 "Jedi"

using System;
using System.Collections.Generic;
/// <summary>
/// Programme simulant un jeu à deux joueurs.
/// </summary>
namespace e3
{
    class Program
    {
        static void Main(string[] args)
        {
            var end = false;
            while (end == false)
            {
                // affichage principal //
                Console.CursorVisible = false;
                Console.SetCursorPosition(5, 3);
                Console.WriteLine("$FIGHT 2\n\n");
                for (int i = 0; i < 15; i++)
                {
                    Idle();
                }

                // création automatique des joueurs //
                Random randomGenerator = new Random();
                var min = 2 / 10;
                var max = 9 / 10;
                var players = new List<Player>();
                var newHP = new List<double>();
                var p1Name = "player 1";
                var p2Name = "player 2";
                var HP1 = randomGenerator.Next(8, 11);
                var HP2 = randomGenerator.Next(8, 11);
                Player player1 = new Player(p1Name, 30, 30, 0.65, HP1);
                Player player2 = new Player(p2Name, 31, 30, 0.66, HP2);
                players.Add(player1);
                players.Add(player2);
                Console.CursorLeft = 5;
                Console.WriteLine("Joueur 1 créé avec un wp de " + player1.weaponPower + ".");
                Console.CursorLeft = 5;
                Console.WriteLine("Joueur 2 créé avec un wp de " + player2.weaponPower + ".\n\n");
                var turn = 0;
                var deltaHit1 = players[0].hp;
                var deltaHit2 = players[1].hp;
                var end1 = 0;
                for (int i = 0; i < 15; i++)
                {
                    Idle();
                }

                // lancement du jeu //
                while (end1 == 0)

                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(5, 9);
                    Console.WriteLine(">> Appuyez sur ENTER pour vous battre ! <<");
                    System.Threading.Thread.Sleep(500);
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        end1 = 1;
                    }



                }
                var leftMove = 0;

                for (int i = 0; i < 5; i++)
                {
                    Console.CursorLeft = leftMove;
                    Console.ForegroundColor = ConsoleColor.Black;
                    for (int i2 = 0; i2 < 10; i2++)
                    {
                        Console.Write("\n");
                        System.Threading.Thread.Sleep(50);
                    }
                    leftMove++;
                }
                Console.Clear();

                // affichage des joueurs //
                Ship();
                Points(30);
                Ennemyship();
                XPoints(30);

                // combat entre les joueurs tant qu'un joueur a de l'hp //
                while (player1.hp > 0 && player2.hp > 0)
                {
                    /*
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine(p1Name +" attaque "+p2Name+" !");
                    Console.ForegroundColor = ConsoleColor.White;*/
                    Idle();
                    players[0].Smash(players, 0, newHP);
                    Fire1();

                    Idle();

                    if (deltaHit2 == players[1].hp)
                    {
                        //manqué
                    }

                    if (deltaHit2 < players[1].hp)
                    {

                        XHit(players[1].hp);
                        XPoints(players[1].hp);
                        deltaHit2 = players[1].hp;
                    }
                    XPoints(players[1].hp);
                    Idle();
                    Idle();
                    Fire2();
                    players[1].Smash(players, 1, newHP);
                    Idle();
                    if (deltaHit1 == players[0].hp)
                    {
                        //manqué
                    }

                    if (deltaHit1 < players[0].hp)
                    {
                        Hit(players[0].hp);
                        Points(players[0].hp);
                        deltaHit1 = players[0].hp;
                    }
                    Points(players[0].hp);

                }

                // victoire d'un joueur //
                if (players[0].hp <= 0)
                {
                    Damaged1(5, 5);
                    Hit(30);
                    Console.SetCursorPosition(5, 20);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Victoire " + p2Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.ReadKey();
                }
                if (players[1].hp <= 0)
                {
                    //Damaged1(5, 5);
                    XHit(30);
                    Console.SetCursorPosition(5, 20);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Victoire " + p1Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.ReadKey();
                }
                Console.SetCursorPosition(5, 22);

                // relancer ou quitter //
                Console.WriteLine("<ENTER> pour rejouer / <ESCAPE> pour quitter");
                var replaySelect = false;
                while (replaySelect == false)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        replaySelect = true;
                    }
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        replaySelect = true;
                        return;
                    }
                }
                
            }
            
        }
        static void Idle()
        {
            System.Threading.Thread.Sleep(55);
        }
        static void Ship()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            var ref1 = 5;
            var ref2 = 5;
            Console.SetCursorPosition(ref1, ref2); // Ligne principale
            for (int i = 0; i < 25; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(ref1, ref2 + 1);
            for (int i = 0; i < 20; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(ref1, ref2 + 2);
            for (int i = 0; i < 11; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(ref1 + 2, ref2 + 3);
            for (int i = 0; i < 4; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(ref1 + 1, ref2 - 1);
            for (int i = 0; i < 2; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(ref1 + 2, ref2 - 2);
            for (int i = 0; i < 2; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(ref1 - 1, ref2 + 1);
            for (int i = 0; i < 1; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write(" ");
            }
        }
        static void Ennemyship()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(65, 7);
            for (int i = 0; i < 5; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(68, 6);
            Console.Write(" ");
            Console.SetCursorPosition(68, 4);
            Console.Write(" ");
            Console.SetCursorPosition(68, 5);
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Fire1()
        {
            var xTop = 4;
            var xLeft = 20;

            for (int i = 0; i < 50; i++)
            {

                Console.SetCursorPosition(xLeft, xTop);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("-");
                Console.SetCursorPosition(xLeft - 1, xTop);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("-");
                xLeft++;
                System.Threading.Thread.Sleep(1);

            }
            Console.SetCursorPosition(xLeft-1, xTop);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("-");
        }
        static void Fire2()
        {
            var xTop2 = 7;
            var xLeft2 = 58;
            Console.SetCursorPosition(xLeft2, xTop2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("-");
            //xLeft2--;

            for (int i = 0; i < 45; i++)
            {
                //Console.MoveBufferArea(xLeft2-i, xTop2, 1, 1, xLeft2 - i-1, xTop2);
                Console.Out.Flush();
                //Console.
                
                Console.SetCursorPosition(xLeft2, xTop2);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("-");
                Console.Out.Flush();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                
                //Console.SetCursorPosition(xLeft2, xTop2);
                Console.Write(" ");
                Console.Out.Flush();
                xLeft2--;
                

                //xLeft2--;
                System.Threading.Thread.Sleep(1);
            }
            Console.SetCursorPosition(xLeft2 + 1, xTop2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("-");

        }
        static void Damaged1(int ref1, int ref2)
        {
            Console.SetCursorPosition(ref1 + 4, ref2 + 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 5; i++)
            {
                Console.Write("X");
                System.Threading.Thread.Sleep(20);
            }
            System.Threading.Thread.Sleep(30);
            Console.SetCursorPosition(ref1 + 5, ref2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 0; i < 3; i++)
            {
                Console.Write("X");
                System.Threading.Thread.Sleep(20);
            }
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(ref1 + 4, ref2 + 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Red;
                for (int i2 = 0; i2 < 5; i2++)
                {
                    Console.Write("X");

                }
                Console.SetCursorPosition(ref1 + 5, ref2);

                for (int i3 = 0; i3 < 3; i3++)
                {
                    Console.Write("X");
                }
                System.Threading.Thread.Sleep(30);
                Console.SetCursorPosition(ref1 + 4, ref2 + 1);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i2 = 0; i2 < 5; i2++)
                {
                    Console.Write("X");

                }
                Console.SetCursorPosition(ref1 + 5, ref2);

                for (int i3 = 0; i3 < 3; i3++)
                {
                    Console.Write("X");
                }
                System.Threading.Thread.Sleep(30);
            }

        }
        static void Points(double score)
        {
            var real = score;
            int posLp1 = 5;
            int posTp1 = 15;
            Console.SetCursorPosition(posLp1, posTp1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < 30; i++)
            {
                Console.Write(" ");
            }
            System.Threading.Thread.Sleep(1);
            Console.SetCursorPosition(posLp1, posTp1 - 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Player 1");
            Console.SetCursorPosition(posLp1, posTp1);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < real; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void XPoints(double score)
        {
            var real = score;
            int posLp1 = 65;
            int posTp1 = 15;
            Console.SetCursorPosition(posLp1, posTp1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < 30; i++)
            {
                Console.Write(" ");
            }
            System.Threading.Thread.Sleep(1);
            Console.SetCursorPosition(posLp1, posTp1-2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Player 2");
            Console.SetCursorPosition(posLp1, posTp1);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < real; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Hit( double score)
        {
            int posLp1 = 5;
            int posTp1 = 15;
            var real = score;
            Console.SetCursorPosition(posLp1, posTp1 - 2);
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(posLp1, posTp1);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i3 = 0; i3 < real; i3++)
                {
                    Console.Write(" ");
                }
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(posLp1, posTp1);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                for (int i2 = 0; i2 < real; i2++)
                {
                    Console.Write(" ");
                }
                System.Threading.Thread.Sleep(100);
            }
            Points(score);
            Console.SetCursorPosition(posLp1, posTp1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i3 = 0; i3 < real; i3++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void XHit(double score)
        {
            int posLp1 = 5;
            int posTp1 = 15;
            double real = score;
            Console.SetCursorPosition(posLp1+60, posTp1 - 2);
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(posLp1+60, posTp1);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i3 = 0; i3 < real; i3++)
                {
                    Console.Write(" ");
                }
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(posLp1+60, posTp1);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                for (int i2 = 0; i2 < real; i2++)
                {
                    Console.Write(" ");
                }
                
                System.Threading.Thread.Sleep(100);
            }
            XPoints(1);
            Console.SetCursorPosition(posLp1 + 60, posTp1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i3 = 0; i3 < real; i3++)
            {
                Console.Write(" ");
            }
            

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
