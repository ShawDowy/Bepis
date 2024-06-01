
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class JsonManager : MonoBehaviour
{
    private string jsonFilePath;

    void Start()
    {
        jsonFilePath = Path.Combine(Application.streamingAssetsPath, "data.json");
        // Пример чтения JSON файла
        ReadJson();
        // Пример записи в JSON файл
        WriteJson();
    }

    void ReadJson()
    {
        if (File.Exists(jsonFilePath))
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            foreach (var item in data)
            {
                Debug.Log($"Key: {item.Key}, Value: {item.Value}");
            }
        }
        else
        {
            Debug.LogError("JSON file not found!");
        }
    }

    void WriteJson()
    {
        Dictionary<string, string> data = new Dictionary<string, string>
        {
            { "Name", "John Doe" },
            { "Age", "30" },
            { "Job", "Developer" }
        };

        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(jsonFilePath, jsonData);
        Debug.Log("JSON file written!");
    }
}
