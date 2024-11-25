    using UnityEngine;

    public class CameraFollow : MonoBehaviour {
        public Transform player;            
        public Vector3 offset;          
        public float followSpeed = 5f;      

        void Start() {
            if (offset == Vector3.zero) {
                offset = new Vector3(0, 1.5f, -4);
            }
        }

        void LateUpdate() {
            if (player != null) {
                Vector3 targetPosition = player.position + offset;
                transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
                transform.LookAt(player);
            }
        }
    }
