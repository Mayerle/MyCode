using Newtonsoft.Json;
using UnityEngine;
public interface ISaver
{
    void Save<T>(string key, T data);
    void Save<T>(T data);
    T Load<T>(string key);
    T Load<T>();
}
public class SaveSystem : ISaver
{
    public void Save<T>(string key, T data)
    {
        var stringedData = JsonConvert.SerializeObject(data);
        PlayerPrefs.SetString(key, stringedData);
        PlayerPrefs.Save();
    }
    public void Save<T>(T data)
    {
        Save((typeof(T)).Name, data);
    }
    public T Load<T>(string key)
    {
        var stringData = PlayerPrefs.GetString(key, default);
        var data = JsonConvert.DeserializeObject<T>(stringData);
        return data;
    }
    public T Load<T>()
    {
        return Load<T>((typeof(T)).Name); 
    }
}
