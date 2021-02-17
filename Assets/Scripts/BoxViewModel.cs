using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class BoxViewModel : ICheckIsBlocked
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
    public void Move(Vector3 nextPosition, string direction)
    {
        switch (direction)
        {
            case "Up":
            {
                if (!IsBlocked(nextPosition, direction))
                {
                    _boxModel.Position.y += 1;
                }
                
            }
                break;
            case "Down":
            {
                if (!IsBlocked(nextPosition, direction))
                {
                    _boxModel.Position.y -= 1;
                }
               
            }
                break;
            case "Left":
            {
                if (!IsBlocked(nextPosition, direction))
                {
                    _boxModel.Position.x -= 1;
                }
                
            }
                break;
            case "Right":
            {
                if (!IsBlocked(nextPosition, direction))
                {
                    _boxModel.Position.x += 1;
                }
                
            }
                break;
        }
    }

    public bool IsBlocked(Vector3 position, string direction)
    {
        var walls = GameObject.FindGameObjectsWithTag("Wall");
        var boxes = GameObject.FindGameObjectsWithTag("Box");
        var nextPosition = new Vector3();
        switch (direction)
        {
            case "Up":
            {
                nextPosition = position;
                nextPosition.y += 1;
            }
                break;
            case "Down":
            {
                nextPosition = position;
                nextPosition.y -= 1;
            }
                break;
            case "Left":
            {
                nextPosition = position;
                nextPosition.x -= 1;
            }
                break;
            case "Right":
            {
                nextPosition = position;
                nextPosition.x += 1;
            }
                break;
        }

        foreach (var wall in walls)
        {
            if (wall.transform.position == nextPosition)
            {
                return true;
            }
        }

        foreach (var box in boxes)
        {
            if (box.transform.position == nextPosition)
            {
                return true;
            }
        }

        return false;
    }
}
