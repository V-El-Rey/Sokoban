using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxView : MonoBehaviour
{
    private BoxViewModel _viewModel;

    public void Initialize(BoxViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.GetPosition(transform.position);
    }

    public void MoveBox(Vector3 nextPosition, string direction)
    {
        _viewModel.Move(nextPosition, direction);
        transform.position = _viewModel.PushPosition();
    }

    public bool IsBlocked(Vector3 nextPosition, string direction)
    {
        return _viewModel.IsBlocked(nextPosition, direction);
    }
}
