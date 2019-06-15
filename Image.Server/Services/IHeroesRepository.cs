using System.Collections.Generic;
using System.Threading.Tasks;

namespace Image.Server.Services
{
    public interface IHeroesRepository
    {
        //IEnumerable<Entities.Hero> GetHeroes();

        //Entities.Hero GetHero(int id);

        Task<IEnumerable<Entities.Hero>> GetHeroesAsync();

        Task<Entities.Hero> GetHeroAsync(int id);

        void AddHero(Entities.Hero HeroToAdd);

        Task<bool> SaveChangesAsync();
    }
}
