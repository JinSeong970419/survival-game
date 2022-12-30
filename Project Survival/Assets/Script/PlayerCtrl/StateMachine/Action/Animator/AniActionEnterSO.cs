using UnityEngine;
using FarmGame.StateMachine;
using FarmGame.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "AniAction", menuName = "State Machines/Actions/AniEnter")]
public class AniActionEnterSO : StateActionSO
{
    protected override StateAction CreateAction() => new AniActionEnter();
}

public class AniActionEnter : StateAction
{
    PlayerController _movement;
    public override void Awake(StateMachine stateMachine)
    {
        _movement = stateMachine.GetComponent<PlayerController>();
    }
    public override void OnStateEnter()
	{
    }
	public override void OnUpdate() { }

	public override void OnStateExit() { }
}