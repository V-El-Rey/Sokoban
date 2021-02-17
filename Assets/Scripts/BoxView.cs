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

    public void MoveBox(string direction)
    {
        _viewModel.Move(direction);
        transform.position = _viewModel.PushPosition();
    }
}
