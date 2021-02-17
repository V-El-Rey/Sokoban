using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxViewModel : CheckIsBlocked
{
    private readonly BoxModel _boxModel;

    public BoxViewModel(BoxModel boxModel)
    {
        _boxModel = new BoxModel();
    }

    public void GetPosition(Vector3 currentPosition)
    {
        _boxModel.Position = currentPosition;
    }

    public Vector3 PushPosition()
    {
        return _boxModel.Position;
    }
    public void Move(string direction)
    {
        switch (direction)
        {
            case "Up":
            {
                _boxModel.Position.y += 1;
            }
                break;
            case "Down":
            {
                _boxModel.Position.y -= 1;
            }
                break;
            case "Left":
            {
                _boxModel.Position.x -= 1;
            }
                break;
            case "Right":
            {
                _boxModel.Position.x += 1;
            }
                break;
        }
    }
}
