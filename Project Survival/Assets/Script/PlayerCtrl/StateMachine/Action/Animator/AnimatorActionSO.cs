using UnityEngine;
using FarmGame.StateMachine;
using FarmGame.StateMachine.ScriptableObjects;
using Moment = FarmGame.StateMachine.StateAction.SpecificMoment;

public enum ParameterType
{
    Bool, Int, Float, Trigger,
}

[CreateAssetMenu(fileName = "AnimatorAction", menuName = "State Machines/Actions/Set Animator")]
public class AnimatorActionSO : StateActionSO
{
    public ParameterType parameterType;
    public string parmetName;

    public bool boolValue;
    public int intValue;
    public float floatValue;

    public Moment moment;

    protected override StateAction CreateAction() => new AnimatorAction(Animator.StringToHash(parmetName));
}

public class AnimatorAction : StateAction
{
    private Animator _animator;
    private PlayerController _movement;
    private int _parameterHash;

    private AnimatorActionSO originSO => (AnimatorActionSO)base.OriginSO;

    public AnimatorAction(int parmetHash)
    {
        _parameterHash = parmetHash;
    }

    public override void Awake(StateMachine stateMachine)
    {
        _animator = stateMachine.GetComponentInChildren<Animator>();
        _movement = stateMachine.GetComponent<PlayerController>();
    }

    public override void OnStateEnter()
    {
        if (originSO.moment == SpecificMoment.OnStateEnter)
            SetParameter(_movement._moveVector);

    }

    public override void OnStateExit()
    {
        if (originSO.moment == SpecificMoment.OnStateExit)
            SetParameter(_movement._moveVector);
    }

    public override void OnUpdate()
    {
        if (originSO.moment == SpecificMoment.OnUpdate)
            SetParameter(_movement._moveVector);
    }

    private void SetParameter(Vector3 direction)
    {
        switch (originSO.parameterType)
        {
            case ParameterType.Bool:
                _animator.SetBool(_parameterHash, originSO.boolValue);
                break;
            case ParameterType.Int:
                _animator.SetInteger(_parameterHash, originSO.intValue);
                break;
            // Test
            case ParameterType.Float:
                _animator.SetFloat("horizontal", direction.x);
                _animator.SetFloat("vertical", direction.z);
                break;
            case ParameterType.Trigger:
                _animator.SetTrigger(_parameterHash);
                break;
        }
    }
}
