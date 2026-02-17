using System.Text.Json;
using Api.Models;

public class FileManager
{
    private List<Person> _peoples;

    private static readonly Lazy<FileManager> lazySingleton
        = new Lazy<FileManager>(() => new FileManager());

    public static FileManager Instance
        => lazySingleton.Value;

    private FileManager()
    {
        GetFromJson();
    }


    private void GetFromJson()
    {
        using (StreamReader json = new StreamReader(Path.GetFullPath("..\\records.json")))
        {
            string jsonVal = json.ReadToEnd();
            this._peoples = JsonSerializer.Deserialize<List<Person>>(jsonVal) ?? new List<Person>();
        }
    }

    private void SaveToJson()
    {
        string jsonString = JsonSerializer.Serialize(this._peoples);
        using (StreamWriter json = new StreamWriter(Path.GetFullPath("..\\records.json")))
        {
            json.Write(jsonString);
        }
    }
}