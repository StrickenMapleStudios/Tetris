using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General {

    public static class Helper
    {
        public static string FormatTime(float time, bool milliseconds = true) {

            var hours = Format(time / 3600);
            var minutes = Format(time % 3600 / 60);
            var seconds = Format(time % 60);
            var ms = Format(time % 1000);

            var text = $"{hours}:{minutes}:{seconds}";
            if (milliseconds) { text += $":{ms}"; }
            
            return text;
        }

        private static string Format(float value) {
            string text = $"{(int) value}";
            if (value < 10) {
                text = "0" + text;
            }
            return text;
        }
    }
}