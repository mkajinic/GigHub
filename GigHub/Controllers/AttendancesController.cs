using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{


    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend (AttendanceDto dto)
        {
           var  userId = User.Identity.GetUserId();
            var exists = _context.Attendencies.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);

            if (exists) BadRequest("Attendance already exists");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendencies.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

    }
}
