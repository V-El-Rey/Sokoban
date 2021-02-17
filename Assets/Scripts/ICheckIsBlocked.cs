using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICheckIsBlocked
{
    bool IsBlocked(Vector3 position, string direction);
}
