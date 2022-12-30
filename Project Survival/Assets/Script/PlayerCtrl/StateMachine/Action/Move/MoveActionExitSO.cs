using FarmGame.StateMachine;
using FarmGame.StateMachine.ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveAction", menuName = "State Machines/Actions/MoveActionExit")]
public class MoveActionExitSO : StateActionSO
{
	[SerializeField]
	private StateAction.SpecificMoment _moment;
	public StateAction.SpecificMoment Moment => _moment;
	protected override StateAction CreateAction() => new MoveActionExit();
}

public class MoveActionExit : StateAction
{
	private PlayerController _movement;
	private new MoveActionExitSO OriginSO => (MoveActionExitSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_movement = stateMachine.GetComponent<PlayerController>();
	}

	public override void OnUpdate()
	{
		if (OriginSO.Moment == SpecificMoment.OnUpdate)
			_movement._moveVector = Vector3.zero;
	}

	public override void OnStateEnter()
	{
		if (OriginSO.Moment == SpecificMoment.OnStateEnter)
			_movement._moveVector = Vector3.zero;
	}

	public override void OnStateExit()
	{
		if (OriginSO.Moment == SpecificMoment.OnStateExit)
			_movement._moveVector = Vector3.zero;
	}
}