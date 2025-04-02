using System.Text.Json;

namespace Persistence.Logic;

public interface IZooStorageManager
{
    IEnumerable<Animal> GetAnimals();
    void AddAnimal(Animal newAnimal);
    void UpdateAnimal(Animal updated);
}

public class JsonZooStorageManager : IZooStorageManager
{
    List<Animal> animals = new();

    public JsonZooStorageManager()
    {
        if (File.Exists("animals.json"))
        {
            var json = File.ReadAllText("animals.json");
            animals = JsonSerializer.Deserialize<List<Animal>>(json);
        }
    }
    public void AddAnimal(Animal newAnimal)
    {
        animals.Add(newAnimal);
        var json = JsonSerializer.Serialize(animals);
        File.WriteAllText("animals.json", json);
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return animals;
    }

    public void UpdateAnimal(Animal updated)
    {
        var existing = animals.Single(a => a.Id == updated.Id);
        animals.Remove(existing);
        animals.Add(updated);
        var json = JsonSerializer.Serialize(animals);
        File.WriteAllText("animals.json", json);
    }
}