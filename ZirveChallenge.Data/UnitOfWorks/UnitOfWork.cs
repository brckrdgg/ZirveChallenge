using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Repositories;
using ZirveChallenge.Core.UnitOfWorks;
using ZirveChallenge.Data.Repositories;

namespace ZirveChallenge.Data.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private MovieRepository _movieRepository;
        private UserRepository _userRepository;
        private MovieRatingRepository _movieRatingRepository;


        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public IMovieRepository Movie => _movieRepository = _movieRepository ?? new MovieRepository(_context);

        public IUserRepository User => _userRepository = _userRepository ?? new UserRepository(_context);

        public IMovieRatingRepository MovieRating => _movieRatingRepository = _movieRatingRepository ?? new MovieRatingRepository(_context);

       

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
