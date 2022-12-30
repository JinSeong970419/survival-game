using UnityEngine;
using FarmGame.StateMachine;
using FarmGame.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Conditions/Move")]
public class IsMoveSO : StateConditionSO<IsMoveCondition>
{
    public float treshold = 0.02f;
}

public class IsMoveCondition : Condition
{
    private PlayerController _MoveMent;
    private IsMoveSO originSO => (IsMoveSO)OriginSO;

    public override void Awake(StateMachine stateMachine)
    {
        _MoveMent = stateMachine.GetComponent<PlayerController>();
    }

    protected override bool Statement()
    {
        Vector3 direction = _MoveMent._moveVector;
        direction.y = 0f;
        return direction.sqrMagnitude > originSO.treshold;
    }
}