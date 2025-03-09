using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Rendering;

namespace Assets
{
	public class RatDashAttack : MonoBehaviour
    {
        public float dashSpeed = 2f; // Distance to dash
        public float dashRecoil = 0.1f;
        public static bool isDashing = false;
        private Rigidbody2D myRigidbody;

        void Start()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(DashAndReturn());
            }
        }

        IEnumerator DashAndReturn()
        {
            Vector2 dashDirection = RatScript.facingRight ? new Vector2(dashSpeed, 0) : new Vector2(-dashSpeed, 0);

            // Move first
            myRigidbody.MovePosition(myRigidbody.position + dashDirection);
            isDashing = true;
            yield return new WaitForSeconds(dashRecoil);
            isDashing = false;
            // Move back to original position
            myRigidbody.MovePosition(myRigidbody.position - dashDirection);
        }
    }
}