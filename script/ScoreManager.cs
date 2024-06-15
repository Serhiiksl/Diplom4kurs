using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Dictionary<string, int> scores = new Dictionary<string, int>();
    private Dictionary<string, float> times = new Dictionary<string, float>();

    private const string ScoresKey = "Scores";
    private const string TimesKey = "Times";
    private const string CompletedLevelsKey = "CompletedLevels";

    private void Awake()
    {
        LoadScores();
    }

    public void SaveScore(string levelName, int score, float time)
    {
        scores[levelName] = score;
        times[levelName] = time;

        SaveScores();
    }

    public int GetScore(string levelName)
    {
        return scores.ContainsKey(levelName) ? scores[levelName] : 0;
    }

    public float GetTime(string levelName)
    {
        return times.ContainsKey(levelName) ? times[levelName] : 0f;
    }

    public void MarkLevelCompleted(string levelName)
    {
        int completedLevels = PlayerPrefs.GetInt(CompletedLevelsKey, 0);
        int levelIndex = int.Parse(levelName.Replace("Level", ""));

        if (levelIndex >= completedLevels)
        {
            PlayerPrefs.SetInt(CompletedLevelsKey, levelIndex);
            PlayerPrefs.Save();
        }
    }

    public int GetCompletedLevels()
    {
        return PlayerPrefs.GetInt(CompletedLevelsKey, 0);
    }

    private void SaveScores()
    {
        PlayerPrefs.SetString(ScoresKey, JsonUtility.ToJson(new Serialization<string, int>(scores)));
        PlayerPrefs.SetString(TimesKey, JsonUtility.ToJson(new Serialization<string, float>(times)));
        PlayerPrefs.Save();
    }

    private void LoadScores()
    {
        if (PlayerPrefs.HasKey(ScoresKey))
        {
            scores = JsonUtility.FromJson<Serialization<string, int>>(PlayerPrefs.GetString(ScoresKey)).ToDictionary();
        }
        if (PlayerPrefs.HasKey(TimesKey))
        {
            times = JsonUtility.FromJson<Serialization<string, float>>(PlayerPrefs.GetString(TimesKey)).ToDictionary();
        }
    }

    [System.Serializable]
    private class Serialization<TKey, TValue>
    {
        public List<TKey> keys;
        public List<TValue> values;

        public Serialization(Dictionary<TKey, TValue> dict)
        {
            keys = new List<TKey>(dict.Keys);
            values = new List<TValue>(dict.Values);
        }

        public Dictionary<TKey, TValue> ToDictionary()
        {
            Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
            for (int i = 0; i < keys.Count; i++)
            {
                dict.Add(keys[i], values[i]);
            }
            return dict;
        }
    }
}
