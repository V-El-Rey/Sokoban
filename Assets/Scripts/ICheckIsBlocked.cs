using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsBlocked
{
    protected bool IsBlocked(Vector3 position, string direction)
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
                Debug.Log("Boxxy");
                var Box = box.GetComponent<BoxView>();
                Box.MoveBox(direction);
            }
        }

        return false;
    }
}
