using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableUIBehavior : MonoBehaviour, ISelectHandler
{
    public void OnSelect(BaseEventData eventData)
    {
        UIManager.Instance.PlaySelected();
    }
}
