using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : MonoBehaviour
{
    void FixedUpdate()
    {
        EventManager.Instance.PostNotification(EVENT_TYPE.TEST_HS, this,1);
    }
}
