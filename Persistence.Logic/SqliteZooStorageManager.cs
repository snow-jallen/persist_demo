using SQLite;

namespace Persistence.Logic;

public class SqliteZooStorageManager : IZooStorageManager
{
    public SqliteZooStorageManager()
    {
        db = new SQLiteConnection("zoo.sqlite");
        db.CreateTable<Animal>();//magic.
    }

    private SQLiteConnection db;

    public IEnumerable<Animal> GetAnimals()
    {
        return db.Table<Animal>();
    }

    public void AddAnimal(Animal newAnimal)
    {
        db.Insert(newAnimal);
    }

    public void UpdateAnimal(Animal updated)
    {
        db.Update(updated);
    }
}
