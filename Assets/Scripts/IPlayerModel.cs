using System;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerModel
{
    Dictionary<KeyCode, Action> MoveMap { get; set; }

}
