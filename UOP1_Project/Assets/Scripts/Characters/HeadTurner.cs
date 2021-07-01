using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HeadTurner : MonoBehaviour
{
    [HideInInspector] public bool isPlayerInNoticeZone;
    public Transform lookTarget;
    public GameObject aimConstraint;

    public void OnNoticeTriggerChange(bool entered, GameObject who)
	{
		isPlayerInNoticeZone = entered;
        //aimConstraint.SetActive(entered);
        Debug.Log("entered = " + entered);
	}
}
