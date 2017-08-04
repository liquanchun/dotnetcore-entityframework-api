using Hotel.App.Data.Abstract;
using Hotel.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.App.Data.Repositories
{
    public class ScheduleRepository : EntityBaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(HotelAppContext context)
            : base(context)
        { }
    }
}
