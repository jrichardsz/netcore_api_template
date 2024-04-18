namespace Src.Repository;

public interface IMovieRepository
{
    public List<Dictionary<string, object>> FindMovies();
}