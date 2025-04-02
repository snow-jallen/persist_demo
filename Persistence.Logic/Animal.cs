using SQLite;

namespace Persistence.Logic;

public class Animal
{
    [PrimaryKey, AutoIncrement]
    public int Id{get;set;}
    public string Name{get;set;}
    public decimal StreetValue{get;set;}
}
