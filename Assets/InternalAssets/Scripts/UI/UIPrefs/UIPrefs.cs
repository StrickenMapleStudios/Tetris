using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEditor {

    [CreateAssetMenu(fileName = "UIPrefs", menuName = "Prefs/UIPrefs")]
    public class UIPrefs : ScriptableObject
    {
        [field: SerializeField] public Color BGColor { get; private set; }
    }
}