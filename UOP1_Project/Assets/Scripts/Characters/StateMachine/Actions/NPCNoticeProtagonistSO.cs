using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "NPCNoticeProtagonist", menuName = "State Machines/Actions/NPC Notice Protagonist")]
public class NPCNoticeProtagonistSO : StateActionSO
{
	public TransformAnchor playerAnchor;
	protected override StateAction CreateAction() => new NPCNoticeProtagonist();
}

public class NPCNoticeProtagonist : StateAction
{
	TransformAnchor _protagonist;
    HeadTurner _headTurner;
	Transform _actorTransform;

	Quaternion rotationOnEnter;
	public override void Awake(StateMachine stateMachine)
	{
		_protagonist = ((NPCNoticeProtagonistSO)OriginSO).playerAnchor;
        Debug.Log("Notice _protagonist = " + _protagonist);
        if (stateMachine.TryGetComponent<Component>(out Component c))
        {
            //Debug.Log(c.name);
            if (c.TryGetComponent<HeadTurner>(out HeadTurner h))
            {
                _headTurner = h;
                //Debug.Log(h.name);
            }
        }
	    _actorTransform = stateMachine.transform;
		rotationOnEnter = _actorTransform.rotation;
	}

	public override void OnUpdate()
	{
        //Debug.Log("_headturner = " + _headTurner);
        //Debug.Log("_protagonist = " + _protagonist);
		if (_protagonist != null && _protagonist.isSet && _headTurner != null && _headTurner.isPlayerInNoticeZone)
		{
			Vector3 relativePos = _protagonist.Transform.position - _actorTransform.position;
			relativePos.y = 0f; // Force rotation to be only on Y axis.

			Quaternion rotation = Quaternion.LookRotation(relativePos);
            Debug.Log("Notice player: " + rotation);
			_actorTransform.rotation = rotation;
		}
	}

	public override void OnStateEnter()
	{

	}

	public override void OnStateExit()
	{
	 _actorTransform.rotation = rotationOnEnter;
	}
}
