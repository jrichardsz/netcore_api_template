using MySql.Data.MySqlClient;
using Src.Database;
using Src.Repository;

public class MovieRepository: IMovieRepository
{
    private Datasource Datasource { get; set; }
    public MovieRepository(Datasource Datasource)
    {
        this.Datasource = Datasource;
    }
    
    public List<Dictionary<string, object>> FindMovies()
    {
        var rows = new List<Dictionary<string, object>>();
        using (var connection = this.Datasource.Connection)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM movie";
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    row.Add(rdr.GetName(i), rdr.GetValue(i));
                }
                rows.Add(row);
            }
        }

        return rows;    
    }    
}