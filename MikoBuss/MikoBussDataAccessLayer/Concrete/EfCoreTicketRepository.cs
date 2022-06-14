using MikoBussDataAccessLayer.Abstract;
using MikoBussEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikoBussDataAccessLayer.Concrete
{
    public class EfCoreTicketRepository : EfCoreGenericRepository<Ticket, MikoBussContext>, ITicketRepository
    {
        public List<int> FullSeats(int GuzergahId)
        {
            using (var context = new MikoBussContext())
            {
                return context.Tickets
                    .Where(i => i.GuzergahId == GuzergahId)
                    .Select(i => i.TicketSeatNo)
                    .ToList();
            }
        }
    }
}
