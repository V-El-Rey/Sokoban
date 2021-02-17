using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : IPlayerModel
{
    public Vector2 Position;
    public Dictionary<KeyCode, Action> MoveMap { get; set; }
}
