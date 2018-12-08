using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Time
{

    public sealed class Clock
    {
        /// <summary>
        /// Singleton variables (thread-safe method)
        /// </summary>
        private static Clock instance = null;
        private static readonly object padlock = new object();


        /// <summary>
        /// Period of time (in milliseconds), 1sec default, can be set
        /// </summary>
        private int _period = 60000 ;
        public int Period
        {
            get { return this._period / _speed; }
            set { this._period = value; }
        }

        /// <summary>
        /// Time is divided by speed 
        /// (ex: if period = 1min and speed = 2x, final period = 30sec (1000ms/2 = 500ms) )
        /// </summary>
        private int _speed = 1;
        public int Speed
        {
            get { return this._speed; }
            set { this._speed = value; }
        }


        /// <summary>
        /// Singleton implementation
        /// </summary>
        public static Clock Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Clock();
                    }
                    return instance;
                }
            }
        }

    }
}

