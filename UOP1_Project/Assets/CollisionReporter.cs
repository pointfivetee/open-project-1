using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReporter : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "BigRock2PressurePlate")
        {
            hit.gameObject.SendMessage("PlayerHit", hit, SendMessageOptions.DontRequireReceiver);
        }
    }
}
