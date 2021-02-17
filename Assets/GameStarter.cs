using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameStarter : MonoBehaviour
{
    private InputManager _inputManager;
    [SerializeField] private PlayerView playerView;
    [SerializeField] private BoxView[] boxViews;
    void Start()
    {
        _inputManager = new InputManager();
        var playerModel = new PlayerModel();
        var playerViewModel = new PlayerViewModel(playerModel);
        playerView.Initialize(playerViewModel);
        foreach (var box in boxViews)
        {
            var boxModel = new BoxModel();
            var boxViewModel = new BoxViewModel(boxModel);
            box.Initialize(boxViewModel);
        }
    }
    void Update()
    {
        playerView.MovePlayer(_inputManager.GetInput());
    }
}
