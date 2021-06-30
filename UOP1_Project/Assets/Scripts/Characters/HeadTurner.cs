using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTurner : MonoBehaviour
{
    [HideInInspector] public bool isPlayerInNoticeZone;
    public void OnNoticeTriggerChange(bool entered, GameObject who)
	{
		isPlayerInNoticeZone = entered;
        //Debug.Log("Notice Zone entered = " + entered);
	}
}
