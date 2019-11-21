using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreatorKitCodeInternal
{
    public class WeaponScript : MonoBehaviour
    {
        private float timer = 1.1f; //throw animation is 2.2 default, 1.1 at 2x speed
        public static Transform snowball;

        void Update()
        {
            if (snowball != null)
            {
                timer -= Time.deltaTime;
                if (timer <= 0.0f)
                {
                    Destroy(snowball.gameObject);
                }
            }
            else
            {
                timer = 1.1f;
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
            {
                if (snowball != null)
                {
                    // snowball.gameObject.GetComponent<Rigidbody>().Sleep();
                    // snowball.gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
                    // snowball.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                    // Rigidbody[] rbs = snowball.gameObject.GetComponentsInChildren<Rigidbody>();
                    // foreach (Rigidbody rb in rbs)
                    // {
                    //     rb.AddExplosionForce(150, transform.position, 30);
                    // }
                    Destroy(snowball.gameObject);
                }
            }
        }
    }
}