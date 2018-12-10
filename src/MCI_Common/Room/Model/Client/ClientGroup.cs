using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MCI_Common.RoomMaterials;
using MCI_Common.Time;
using MCI_Common.Recipes;
using MCI_Common.Communication;
using Room.Model.Staff;
using Room.Model.Behaviour;

namespace Room.Model.Client
{
    public class ClientGroup : Movable
    {
        /// <summary>
        /// Delegate for ReadyToOrder event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public delegate void ReadyToOrderEventHandler(object source, OrderEventArgs args);

        /// <summary>
        /// Delegate for DishFinished event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public delegate void DishFinishedEventHandler(object source, OrderEventArgs args);

        /// <summary>
        /// Delegate for ReadyToPay event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public delegate void ReadyToPayEventHandler(object source, OrderEventArgs args);

        // TODO ajouter les envent handler au staff + abonnement


        public int Id;
        public List<Client> ClientList;
        private Table TableSit;
        private Boolean Reserved;
        private Boolean IsHurry;
        
        // Events
        private event ReadyToOrderEventHandler ReadyToOrder;
        private event DishFinishedEventHandler DishFinished;
        private event ReadyToPayEventHandler ReadyToPay;

        
        private string Sprite;
        
        public ClientGroup(int id)
        {

            Id = id;

            //adding subscriptions to events
            DishFinished += StaffManager.Instance.OnDishFinished;
            ReadyToOrder += StaffManager.Instance.OnReadyToOrder;
            ReadyToPay += StaffManager.Instance.OnReadyToPay;

            

            //Spawns at inital position
            MoveTo(1, 1);


            //Go to room master's counter
            MoveTo(10, 10);
            StaffManager.Instance.Master.AssignTable(this);

            //Follows the room master (or leaves)


            //Gets seated -> set individual clients around table

            //Gets menus, reflexion moment

            //Meal Orders are done

            //(Wine order)

            //Wait for food, then eats

            this.Eat(RecipeType.DESSERT);  //for test purpose


            //Meal finished, ready to pay

        }

        /// <summary>
        /// Eat for given time, depending on meal eaten
        /// </summary>
        /// <param name="CurrentDish"></param>
        private void Eat(RecipeType CurrentDish)
        {
            int delay;
            

            // Delay according to the dish eaten
            if (CurrentDish == RecipeType.STARTER)
                delay = Global_Settings.timeStarter;
            else if (CurrentDish == RecipeType.MAIN)
                delay = Global_Settings.timeMain;
            else
                delay = Global_Settings.timeDessert;

            // If the client group is in a hurry, they stay twice less time
            if (IsHurry == true)
                delay /= 2;

            // Wait for the group to finish eating, delay multiplied to get minutes
            Thread.Sleep(delay*Clock.Instance.Period);

            OnDishFinished(Id);

            if (CurrentDish == RecipeType.DESSERT)
                OnReadyToPay(Id);

        }
        
        
        
        
        //methode manger    -> appeler dishfinished
        //                  -> appeler readytopay quand dessert fini

        //en fonction du type de commande, lorsque les clients ont rempli leur choix -> appeler readytoorder



        // RAISING EVENTS

        /// <summary>
        /// Executed when clients have decided
        /// </summary>
        /// <param name="GroupId"></param>
        protected virtual void OnReadyToOrder(int GroupId)
        {
            ReadyToOrder?.Invoke(this, new OrderEventArgs(this.Id));
        }

        /// <summary>
        /// Executed when every client of a group has finished eating
        /// </summary>
        /// <param name="GroupId"></param>
        protected virtual void OnDishFinished(int GroupId)
        {
            DishFinished?.Invoke(this, new OrderEventArgs(this.Id));
        }

        /// <summary>
        /// Executed when client is ready to pay (after finishing it's dessert)
        /// </summary>
        /// <param name="GroupId"></param>
        protected virtual void OnReadyToPay(int GroupId)
        {
            ReadyToPay?.Invoke(this, new OrderEventArgs(this.Id));
        }


    }

    /// <summary>
    /// Class for passing the id of the client group to the event handler (waiter)
    /// </summary>
    public class OrderEventArgs : EventArgs
    {
        public int Id { get; set; }

        public OrderEventArgs(int id_clt) { this.Id = id_clt; }

    }
}
