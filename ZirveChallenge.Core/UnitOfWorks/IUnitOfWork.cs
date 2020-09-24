using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Repositories;

namespace ZirveChallenge.Core.UnitOfWorks
{
     public interface IUnitOfWork
    {

        Task CommitAsync();
        void Commit();
        IMovieRepository Movie { get; }
        IUserRepository User { get; }

        IMovieRatingRepository MovieRating { get; }
    }
}
