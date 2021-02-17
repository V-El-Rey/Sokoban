using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerViewModel _viewModel;
    public void Initialize(PlayerViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.GetPosition(transform.position);
    }

    public void MovePlayer(KeyCode code)
    {
        _viewModel.MovePlayer(code);
        transform.position = _viewModel.PushPosition();
    }
}
