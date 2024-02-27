using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace SpaceInvadersRetro.Utils;

public static class ScoreManager
{
    public static int Score { get; private set; }

    public static void Increment(int points) => Score += points;

    public static void Reset() => Score = 0;

    public static void SaveScoreList(PlayerData player)
    {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HighScores.json");

            List<PlayerData> playerDataList;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                playerDataList = JsonConvert.DeserializeObject<List<PlayerData>>(json);
            }
            else
            {
                playerDataList = new List<PlayerData>();
            }

            playerDataList.Add(player);
            playerDataList = playerDataList.OrderByDescending(p => p.Score).ToList();

            if (playerDataList.Count > 5)
            {
                playerDataList.RemoveAt(playerDataList.Count - 1);
            }

            var updatedJson = JsonConvert.SerializeObject(playerDataList, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

    }
    public static List<PlayerData> LoadScoreList()
    {
        List<PlayerData> playerDataList = new List<PlayerData>();
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HighScores.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            playerDataList = JsonConvert.DeserializeObject<List<PlayerData>>(json);
        }

        return playerDataList;
    }
}

public class PlayerData
{
    public string Name { get; set; }
    public int Score { get; set; }
}
