using UnityEngine;
using System.Collections;

namespace Assets
{    public class CameraFollow : MonoBehaviour
    {
        public Transform target; // Assign your player’s transform in the Inspector
        public Vector3 offset = new Vector3(0f, 2f, -10f); // Adjust for better positioning
        void LateUpdate()
        {
            if (target != null)
            {
                transform.position = target.position + offset;
            }
        }
    }

}