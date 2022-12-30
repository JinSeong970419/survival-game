using UnityEngine;
using FarmGame.StateMachine;
using FarmGame.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "MovementVector", menuName = "State Machines/Actions/Movement Vector")]
public class MovePlayerSO : StateActionSO<MovePlayer> { }

public class MovePlayer : StateAction
{
    public PlayerController _movement;

    public override void Awake(StateMachine stateMachine)
    {
        _movement = stateMachine.GetComponent<PlayerController>();
    }

    public override void OnUpdate()
    {
    }
}