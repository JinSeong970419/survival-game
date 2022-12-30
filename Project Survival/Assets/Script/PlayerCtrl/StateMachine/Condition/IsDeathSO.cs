using UnityEngine;
using FarmGame.StateMachine;
using FarmGame.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Conditions/Death")]
public class IsDeathSO : StateConditionSO<IsDeathCondition>
{
    public bool TestNeverDie = false;
}

public class IsDeathCondition : Condition
{
    private IsDeathSO originSO => (IsDeathSO)OriginSO;
    public override void Awake(StateMachine stateMachine)
    {

    }

    protected override bool Statement()
    {
        throw new System.NotImplementedException();
    }
}
