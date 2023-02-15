using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game.Data {

    [System.Serializable]
    public class Leaderboards {
        public List<Result> Results { get; private set; }

        public Leaderboards() {
            Init();
        }

        public Leaderboards(List<Result> results) {
            Results = results;
        }

        public void Init() {
            Results = new List<Result>() {
                new Result("Mark", 25000, 15, 2500),
                new Result("Eugen", 10000, 9, 1000),
                new Result("Paul", 5000, 5, 500),
                new Result("Steve", 2000, 3, 200),
                new Result("John", 1000, 2, 100),
            };
        }

        public void AddResult(Result result) {
            
            Results.Add(result);
        }


        public void Reset() {
            Results.Clear();
            Init();
        }
    }

    [System.Serializable]
    public class Result {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public int Level { get; private set; }
        public float Lifetime { get; private set; }

        public Result(string name, int score, int level, float lifetime) {
            Name = name;
            Score = score;
            Level = level;
            Lifetime = lifetime;
        }
    }

    public static class SaveSystem
    {
        private static string path => Application.persistentDataPath + "/Leaderboards.bin";

        private static void Init() {

            var leaderboards = new Leaderboards();

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, leaderboards);
            stream.Close();
        }


        public static void SaveResult(Result result) {

            if (!File.Exists(path)) { Init(); }

            var leaderboards = GetLeaderboards();
            leaderboards.AddResult(result);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, leaderboards);
            stream.Close();
        }

        public static Leaderboards GetLeaderboards() {

            if (!File.Exists(path)) { Init(); }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            Leaderboards leaderboards = formatter.Deserialize(stream) as Leaderboards;
            stream.Close();
            
            return leaderboards;
        }

        public static void Reset() {
            var leaderboards = new Leaderboards();

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            
            formatter.Serialize(stream, leaderboards);
            stream.Close();
        }
    }
}