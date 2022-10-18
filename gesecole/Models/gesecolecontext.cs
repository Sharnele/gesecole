using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace gesecole.Models
{
    public class gesecolecontext: DbContext
    {
        public gesecolecontext(DbContextOptions <gesecolecontext> Options)
       
          :base(Options)
        {
        }
        public DbSet < Etudiant > etudiants { get; set; }
        public DbSet<Cour>  cours{ get; set; }
    
    }

}
               
            
    
