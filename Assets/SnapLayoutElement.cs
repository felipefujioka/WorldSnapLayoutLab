using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class SnapLayoutElement : MonoBehaviour
    {
        public Transform AnchorMinXZ;
        public Transform AnchorMaxXZ;

        public float ElementHeight()
        {
            return AnchorMaxXZ.localPosition.z - AnchorMinXZ.localPosition.z;
        }
    }
}