using AutoMapper;
using Azure.Core;
using DotNet8API.AppDataContext;
using DotNet8API.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet8API.services
{
    public class OurHeroService : IOurHeroService
    {
        //private readonly List<OurHero> _ourHeroesList;
        private readonly AppDbContext _context;
        private readonly ILogger<OurHeroService> _logger;
        private readonly IMapper _mapper;
        public OurHeroService(AppDbContext context, ILogger<OurHeroService> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public OurHero AddOurHero(AddUpdateOurHero request)
        {
            try
            {
                var ourhero = _mapper.Map<OurHero>(request);
                _context.OurHero.Add(ourhero);
                _context.SaveChangesAsync();
                return ourhero;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Todo item.");
                throw new Exception("An error occurred while creating the Todo item.");
            }
        }

        public bool DeleteHerosByID(int id)
        {
            var hero = _context.OurHero.Find(id);
            if (hero != null)
            {
                _context.OurHero.Remove(hero);
                _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception($"No item found with the id {id}");
            }
        }

        public List<OurHero> GetAllHeros(bool? isActive)
        {
            var hero = _context.OurHero.ToList();
            if (hero == null)
            {
                throw new Exception(" No Todo items found");
            }
            return hero;
        }
        public OurHero? GetHerosByID(int id)
        {
            var hero =  _context.OurHero.Find(id);
            if (hero == null)
            {
                throw new Exception($" No Items with {id} found ");
            }
            return hero;
        }

        public OurHero? UpdateOurHero(int id, AddUpdateOurHero request)
        {
            try
            {
                var hero = _context.OurHero.Find(id);
                if (hero == null)
                {
                    throw new Exception($"OurHero item with id {id} not found.");
                }

                if (request.FirstName != null)
                {
                    hero.FirstName = request.FirstName;
                }

                if (request.LastName != null)
                {
                    hero.LastName = request.LastName;
                }

                _context.SaveChanges();
                return hero;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the todo item with id {id}.");
                throw;
            }
        }
       
    }
}
