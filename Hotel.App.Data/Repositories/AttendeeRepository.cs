using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.App.Model;
using Hotel.App.Data;
using Hotel.App.Data.Repositories;
using Hotel.App.Data.Abstract;

namespace Hotel.App.Data.Repositories
{
    public class AttendeeRepository : EntityBaseRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(HotelAppContext context)
            : base(context)
        { }
    }
}
