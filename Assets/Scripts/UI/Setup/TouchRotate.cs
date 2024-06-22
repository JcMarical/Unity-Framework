using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TouchRotate : MonoBehaviour,IDragHandler
{
    public Transform Target;
    public void OnDrag(PointerEventData eventData)
    {
        Target.Rotate(new Vector3(0,-eventData.delta.x,0));  
    }

}
