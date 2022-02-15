using System;
using System.Collections.Generic;
using System.Text;

namespace e3
{
    class Player
    {
        public string name;
        public int age;
        public double hp;
        //public double hitratio;
        public int weaponPower;
        public List<Player> players = new List<Player>();
        public Random randomGenerator = new Random();
        public Player(string name, int age, double hp, double hitratio, int weaponPower) 
        {
            this.name = name;
            this.age = age;
            this.hp = hp;
            this.weaponPower = weaponPower;
        }
        public void Smash(List<Player> players, int turn, List<double> newHP)
        {
            double randomHit = 0;
            var hitList = new List<double>();
            for (int i = 0; i < 2; i++)
            {

                randomHit = randomGenerator.NextDouble();// .Next(0, 100)/100.0;
                
                hitList.Add(randomHit);
            }
            if (hitList[0]<hitList[1] && turn == 1)// 1 
            {
                players[0].Reduce0(hitList[0], weaponPower, Convert.ToDouble(players[0].hp), players);
            }
            if (hitList[0] > hitList[1] && turn == 0)//
            {
                players[1].Reduce1(hitList[1], weaponPower, Convert.ToDouble(players[1].hp), players);
            }
            /*
            newHP.Add(players[0].hp);
            newHP.Add(players[1].hp);*/

        }
        public double Reduce0(double randomHit, int weaponpower, double hp, List<Player> players)
        {
            players[0].hp = players[0].hp - players[1].weaponPower;
            return players[0].hp;
        }
        public double Reduce1(double randomHit, int weaponpower, double hp, List<Player> players)
        {
            players[1].hp = players[1].hp - players[0].weaponPower;
            return players[1].hp;
        }
    }
}
