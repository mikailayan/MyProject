﻿using MikoBussEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikoBussDataAccessLayer.Abstract
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        List<int> FullSeats(int GuzergahId);

    }
}
