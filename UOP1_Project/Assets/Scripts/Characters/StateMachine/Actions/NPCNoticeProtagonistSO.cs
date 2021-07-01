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
	Transform _lookTarget;
	Transform _actorTransform;
	Vector3 _defaultLookVector = new Vector3(0f, 0f, 1f);
	float _headTurnSpeed = 6f;

	public override void Awake(StateMachine stateMachine)
	{
		_protagonist = ((NPCNoticeProtagonistSO)OriginSO).playerAnchor;
            if (stateMachine.gameObject.TryGetComponent<HeadTurner>(out HeadTurner h))
            {
                _headTurner = h;
				_lookTarget = h.lookTarget;
            }
	    _actorTransform = stateMachine.transform;
		//rotationOnEnter = _actorTransform.rotation;
		Debug.Log("_headTurner = " + _headTurner);
		Debug.Log("for " + stateMachine.gameObject.name);
	}

	public override void OnUpdate()
	{
		Debug.Log("_protagonist = " + _protagonist);
		if (_protagonist.isSet && _headTurner != null && _headTurner.isPlayerInNoticeZone)
		{
			Vector3 direction = _protagonist.Transform.position - _lookTarget.position;
			//_lookTarget.position = _protagonist.Transform.position;
			_lookTarget.position += direction.normalized * Time.deltaTime * _headTurnSpeed;
		} else {
			Vector3 direction = _defaultLookVector - _lookTarget.localPosition;
			_lookTarget.localPosition += direction.normalized * Time.deltaTime * _headTurnSpeed;
		}
	}

	public override void OnStateEnter()
	{

	}

	public override void OnStateExit()
	{

	}
}
