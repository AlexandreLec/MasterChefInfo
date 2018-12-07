using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MCI_Common.RoomMaterials;

namespace Room.Model.Client
{
    public class ClientGroup
    {
        /// <summary>
        /// Delegate for ReadyToOrder event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public delegate void ReadyToOrderEventHandler(object source, EventArgs args);

        /// <summary>
        /// Delegate for DishFinished event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public delegate void DishFinishedEventHandler(object source, EventArgs args);

        /// <summary>
        /// Delegate for ReadyToPay event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public delegate void ReadyToPayEventHandler(object source, EventArgs args);

        // TODO ajouter les envent handler au staff + abonnement


        private int Id;
        public List<Client> ClientList;
        private Table TableSit;
        private Boolean Reserved;
        private Boolean IsHurry;
        private event ReadyToOrderEventHandler ReadyToOrder;
        private event DishFinishedEventHandler DishFinished;
        private event ReadyToPayEventHandler ReadyToPay;
        private string Sprite;
        


        private void Eat(string CurrentDish)
        {
            int delay;

            // Delay according to the dish eaten
            if (CurrentDish == "Starter")
                delay = 15;
            else if (CurrentDish == "Dish")
                delay = 30;
            else
                delay = 10;

            // If the client group is in a hurry, they stay twice less time
            if (IsHurry == true)
                delay /= 2;

            // Wait for the group to finish eating, delay multiplied to get minutes
            Thread.Sleep(delay*10000);

            OnDishFinished(Id);

            if (CurrentDish == "Dessert")
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
            ReadyToOrder?.Invoke(this, new OrderEventArgs() { Id = GroupId } );
        }

        /// <summary>
        /// Executed when every client of a group has finished eating
        /// </summary>
        /// <param name="GroupId"></param>
        protected virtual void OnDishFinished(int GroupId)
        {
            DishFinished?.Invoke(this, new OrderEventArgs() { Id = GroupId });
        }

        /// <summary>
        /// Executed when client is ready to pay (after finishing it's dessert)
        /// </summary>
        /// <param name="GroupId"></param>
        protected virtual void OnReadyToPay(int GroupId)
        {
            ReadyToPay?.Invoke(this, new OrderEventArgs() { Id = GroupId });
        }


    }

    /// <summary>
    /// Class for passing the id of the client group to the event handler (waiter)
    /// </summary>
    public class OrderEventArgs : EventArgs
    {
        public int Id { get; set; }
    }
}
