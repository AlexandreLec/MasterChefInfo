﻿using MCI_Common.Behaviour;
using MCI_Common.Dishes;
using MCI_Common.Recipes;
using Microsoft.Xna.Framework;
using SimulationKitchen.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationKitchen.Model
{
    public class Kitchen : IModel
    {
        /// <summary>
        /// List of the recipe available in menu
        /// </summary>
        public List<Recipe> Menu { get; private set; }

        public Counter RoomCounter { get; set; }

        public List<Cooker> Cookers { get; set; }

        public CookChief Chief { get; set; }

        public Washer WashMan { get; set; }

        

        public Kitchen(int cookersNb)
        {
            this.RoomCounter = Counter.GetInstance();
            this.WashMan = new Washer();
            this.CreateCookers(cookersNb);
            this.Chief = new CookChief(this.Cookers, this.RoomCounter);
        }

        public void Start()
        {
            Console.WriteLine("Test");
            Order order = new Order();
            Dish one = new Dish(order);
            Dish two = new Dish(order);
            Console.WriteLine("Test456");
            one.Recipe = new RecipeProcess().GetOne(1);
            two.Recipe = new RecipeProcess().GetOne(2);

            order.Dishes.Add(one);
            order.Dishes.Add(two);

            one.Id = 1;
            two.Id = 2;
            //this.RoomCounter.RoomCommunication.StartListening();
            this.WashMan.StartWorking().Start();
            

            this.Chief.CarryOrder(order);
        }

        private void CreateCookers(int nb)
        {
            this.Cookers = new List<Cooker>();
            Oven oven = new Oven();
            int space = 0;
            for (int i = 1; i <= nb; i++)
            {
                Position position = new Position(80 + space, 160);
                this.Cookers.Add(new Cooker(i, this.WashMan, oven, position));
                space += 80;
            }
        }

        
    }
}
