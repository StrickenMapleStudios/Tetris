using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    using Data;

    public partial class GameManager
    {
        public static List<Result> Results => SaveSystem.GetLeaderboards().Results;

        private void SaveResult(string name) {
            var result = new Result(name, Score, Level, Lifetime);

            SaveSystem.SaveResult(result);
        }

    }
}