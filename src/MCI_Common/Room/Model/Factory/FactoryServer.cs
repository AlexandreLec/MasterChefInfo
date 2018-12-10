﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Room.Model.Staff;

namespace Room.Model.Factory
{
    class FactoryServer : FactoryStaff
    {
        public override Staff.Staff Create()
        {
            return (new Server());
        }
    }
}