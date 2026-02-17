using System.Text.Json;
using Api.Models;

public class FileManager
{
    public List<Person> Persons { get; set; }

    private static readonly Lazy<FileManager> _lazySingleton
        = new Lazy<FileManager>(() => new FileManager());

    public static FileManager Instance
        => _lazySingleton.Value;

    private FileManager()
    {
        GetFromJson();
    }


    private void GetFromJson()
    {
        try
        {
            using (StreamReader json = new StreamReader(Path.GetFullPath("../Api/records.json")))
            {
                string jsonVal = json.ReadToEnd();
                this.Persons = JsonSerializer.Deserialize<List<Person>>(jsonVal) ?? new List<Person>();
            }
        }
        catch
        {
            this.Persons = new List<Person>();
        }
    }

    public void Save()
    {
        string jsonString = JsonSerializer.Serialize(this.Persons);
        using (StreamWriter json = new StreamWriter(Path.GetFullPath("../Api/records.json")))
        {
            json.Write(jsonString);
        }
    }
}