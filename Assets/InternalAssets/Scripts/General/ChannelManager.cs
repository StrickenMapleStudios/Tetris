using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace General {

    using Game;
    using UI;
    using Input;

    public class ChannelManager : MonoBehaviour
    {
        
        [SerializeField] private GameEventChannel _gameEventChannel;
        [SerializeField] private InputEventChannel _inputEventChannel;
        [SerializeField] private UIEventChannel _uiEventChannel;
    }
}