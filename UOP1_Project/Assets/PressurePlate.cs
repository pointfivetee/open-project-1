using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

	[SerializeField] private LayerMask _layers = default;
    //

    void PlayerHit(ControllerColliderHit hit)
    {
        if (hit.normal.y > .95f)
        {
            Debug.Log("player is on top of plate");
        }
    }
}
