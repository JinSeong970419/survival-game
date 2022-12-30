using UnityEngine;
using FarmGame.StateMachine;
using FarmGame.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "MoveAction", menuName = "State Machines/Actions/Player Move")]
public class MoveActionSO : StateActionSO<MoveAction>
{
    public float speed = 2f;
}

public class MoveAction : StateAction
{
    private PlayerController _Movement;

    private MoveActionSO originSO => (MoveActionSO)OriginSO;
    public override void Awake(StateMachine stateMachine)
    {
        _Movement = stateMachine.GetComponent<PlayerController>();
    }

    public override void OnUpdate()
    {
    }
}