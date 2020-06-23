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
        public IHttpActionResult Attend ([FromBody] int gigId)
        {
           var  userId = User.Identity.GetUserId();
            var exists = _context.Attendencies.Any(a => a.AttendeeId == userId && a.GigId == gigId);

            if (exists) BadRequest("Attendance already exists");

            var attendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = userId
            };
            _context.Attendencies.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

    }
}
