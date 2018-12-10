using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCI_Common.Communication
{
    /// <summary>
    /// Application settings
    /// </summary>
    static public class Global_Settings
    {
        // Put here everything you can modify in controller

        //Staff population

        /// <summary>
        /// Number of rank chiefs (default = 2)
        /// </summary>
        static private int _nbRankChief = 2;
        static public int nbRankChief
        {
            get { return _nbRankChief; }
            set { _nbRankChief = value; }
        }
        

        /// <summary>
        /// Number of waiters (default = 2)
        /// </summary>
        static private int _nbServers = 2;
        static public int nbServers
        {
            get { return _nbServers; }
            set { _nbServers = value; }
        }

        /// <summary>
        /// Number of cooks (default = 2)
        /// </summary>
        static public int _nbCooks = 2;
        static public int nbCooks
        {
            get { return _nbCooks; }
            set { _nbCooks = value; }
        }

        //Client population

        /// <summary>
        /// Number of clients per shift
        /// </summary>
        static public int _nbCltPerShift = 200;
        static public int nbCltPerShift
        {
            get { return _nbCltPerShift; }
            set { _nbCltPerShift = value; }
        }

    }
}
