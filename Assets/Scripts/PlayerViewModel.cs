using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Object = System.Object;

public class PlayerViewModel : ICheckIsBlocked
{
    private readonly PlayerModel _playerModel;
    public PlayerViewModel(PlayerModel model)
    {
        _playerModel = model;
        _playerModel.MoveMap = new Dictionary<KeyCode, Action>
        {
            {KeyCode.A, MoveLeft},
            {KeyCode.D, MoveRight},
            {KeyCode.S, MoveDown},
            {KeyCode.W, MoveUp},
        };
        _playerModel.Position = Vector2.zero;
    }

    public void GetPosition(Vector3 currentPosition)
    {
        _playerModel.Position = currentPosition;
    }

    public Vector3 PushPosition()
    {
        return _playerModel.Position;
    }

    public void MovePlayer(KeyCode code)
    {
        foreach (var direction in _playerModel.MoveMap.Where(direction => code == direction.Key))
        {
            direction.Value?.Invoke();
        }
    }
    
    private void MoveUp()
    {
        if (!IsBlocked(_playerModel.Position, "Up"))
        {
            _playerModel.Position.y += 1;
        }
    }

    private void MoveDown()
    {
        if (!IsBlocked(_playerModel.Position, "Down"))
        {
            _playerModel.Position.y -= 1;
        }
    }

    private void MoveLeft()
    {
        if (!IsBlocked(_playerModel.Position, "Left"))
        {
            _playerModel.Position.x -= 1;
        }
    }

    private void MoveRight()
    {
        if (!IsBlocked(_playerModel.Position, "Right"))
        {
            _playerModel.Position.x += 1;
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
                var Box = box.GetComponent<BoxView>();
                if (Box.IsBlocked(nextPosition, direction))
                {
                    return true;
                }
                Box.MoveBox(nextPosition, direction);
            }
        }

        return false;
    }
}
