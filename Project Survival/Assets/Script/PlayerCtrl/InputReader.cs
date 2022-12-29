using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Input System/InputReader")]
public class InputReader : ScriptableObject, PlayerCtrl.IPlayerActions
{
    public event UnityAction<Vector2> _Movement = delegate { };

    private PlayerCtrl _playerCtrl;

    #region OnEnable & OnDisable
    private void OnEnable()
    {
        if (_playerCtrl == null)
        {
            _playerCtrl = new PlayerCtrl();

            // SetCallbacks 콜백 함수
            _playerCtrl.Player.SetCallbacks(this);
            _playerCtrl.Enable();
        }
    }

    private void OnDisable()  
    {
        _playerCtrl.Player.Disable();
    }
    #endregion

    #region IPlayerActions
    public void OnMove(InputAction.CallbackContext context) { _Movement.Invoke(context.ReadValue<Vector2>()); }

    public void OnJump(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    #endregion
}