using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;

namespace CreatorKitCodeInternal
{

    public class WeaponScript : MonoBehaviour
    {
        public SFXManager.Use UseType;
        public AudioClip[] snowballHitSFX;
        private bool firstHit = false;
        private float timer = 1.1f; //throw animation is 2.2 default, 1.1 at 2x speed
        public static Transform snowball;
        public static bool done = true;

        public static CharacterData m_CharacterData;
        public static CharacterData m_CurrentTargetCharacterData;

        void Update()
        {
            if (snowball != null)
            {
                timer -= Time.deltaTime;
                if (timer <= 0.0f)
                {
                    done = true;
                    timer = 1.1f;
                    Destroy(snowball.gameObject);
                }
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == 8 || collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
            {
                if (snowball != null)
                {
                    Rigidbody snowballRb = snowball.GetComponent<Rigidbody>();
                    // float power = 300;
                    // Vector3 pos = snowball.transform.position;
                    // float radius = 30;

                    // snowballRb.Sleep();
                    // snowballRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
                    // snowballRb.isKinematic = true;
                    snowballRb.useGravity = true;
                    if (firstHit == false) //Only play sound on first collision not on the bounces
                    {
                        firstHit = true;
                        SFXManager.PlaySound(UseType, new SFXManager.PlayData()
                        {
                            Clip = snowballHitSFX[Random.Range(0, snowballHitSFX.Length)],
                            Position = transform.position
                        });
                    }
                    if (collision.gameObject.layer == 11)
                    {
                        m_CurrentTargetCharacterData.Stats.ChangeHealth(-3);
                    }

                    // snowballRb.AddExplosionForce(power, pos, radius);
                    // Destroy(snowball.gameObject);

                    // Collider[] colliders = Physics.OverlapSphere(pos, radius);
                    // foreach (Collider collider in colliders)
                    // {
                    //     Rigidbody rb = collider.GetComponent<Rigidbody>();
                    //     if (rb != null)
                    //         rb.AddExplosionForce(power, pos, radius);
                    // }
                }
            }
        }
    }
}