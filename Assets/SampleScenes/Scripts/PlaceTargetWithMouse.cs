using System;
using UnityEngine;


namespace UnityStandardAssets.SceneUtils
{
    public class PlaceTargetWithMouse : MonoBehaviour
    {
        public float surfaceOffset = 1.5f;
        public GameObject setTargetOn;

        public float minX;
        public float maxX;
        public float minZ;
        public float maxZ;

        // Update is called once per frame
        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (!Physics.Raycast(ray, out hit))
            {
                return;
            }
            transform.position = hit.point + hit.normal*surfaceOffset;
            if (setTargetOn != null)
            {
                setTargetOn.SendMessage("SetTarget", transform);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag=="Enemy")
            {
                transform.position = new Vector3(UnityEngine.Random.Range(minX, maxX), transform.position.y, UnityEngine.Random.Range(minZ, maxZ));
            }
          
        }
    }
}
