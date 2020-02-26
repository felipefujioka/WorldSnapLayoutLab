using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class SnapLayout : MonoBehaviour
{
    public Transform InitialAnchor;

    public SnapLayoutElement AddElement(SnapLayoutElement element, int siblingIndex = -1)
    {
        var instance = Instantiate(element, transform);

        if (siblingIndex >= 0)
        {
            instance.transform.SetSiblingIndex(siblingIndex);
        }  

        UpdatePositions();

        return instance;
    }

    private void UpdatePositions()
    {
        var childCount = transform.childCount;

        var lastPosition = InitialAnchor.position;

        for (int i = 0; i < childCount; i++)
        {
            var element = transform.GetChild(i).GetComponent<SnapLayoutElement>();

            if (element == null)
            {
                continue;
            }

            var localPosition = element.AnchorMinXZ.localPosition;
            element.transform.position = lastPosition - localPosition;
            
            lastPosition += (new UnityEngine.Vector3(
                0,
                0,
                element.AnchorMaxXZ.localPosition.z -
                localPosition.z
                ));
        }
    }
}