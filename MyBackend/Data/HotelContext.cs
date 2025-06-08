using Microsoft.EntityFrameworkCore;

namespace HotelCheckInSystem.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<LoginUser> LoginTable { get; set; }
    }

    public class LoginUser
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}