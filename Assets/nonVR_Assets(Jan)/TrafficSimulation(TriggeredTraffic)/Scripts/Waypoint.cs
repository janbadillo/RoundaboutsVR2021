// Traffic Simulation
// https://github.com/mchrbn/unity-traffic-simulation

using UnityEngine;

namespace TrafficSimulation {
    public class Waypoint : MonoBehaviour {
        [HideInInspector] public Segment segment;
        public float speed;
        public bool isSpawn;

        public void Refresh(int newId, Segment newSegment) {
            segment = newSegment;
            name = "Waypoint-" + newId;
            tag = "Waypoint";
            
            //Set the layer to Default
            gameObject.layer = 0;
            
            //Remove the Collider cause it it not necessary any more
            RemoveCollider();
        }

        private void RemoveCollider() {
            if (GetComponent<SphereCollider>()) {
                DestroyImmediate(gameObject.GetComponent<SphereCollider>());
            }
        }

        public Vector3 GetVisualPos() {
            return transform.position + new Vector3(0, 0.5f, 0);
        }
    }
}
