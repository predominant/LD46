using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

namespace LD46.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        private Vector3 _input;
        private float _rotation;
        private Rigidbody _rigidbody;

        [SerializeField]
        private float MovementSpeed = 1f;
        [SerializeField]
        private float RotationSpeed = 1f;

        private void OnEnable()
        {
            this._rigidbody = this.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            this.ProcessControls();
        }

        private void FixedUpdate()
        {
            this.Movement();
        }

        private void ProcessControls()
        {
            var input = new Vector3();
            input.x = Input.GetAxis("Horizontal");
            input.z = Input.GetAxis("Vertical");

            input.y = Input.GetAxis("Jump") - Input.GetAxis("Fire1");

            this._input = input;

            this._rotation = Input.GetAxis("Mouse X");
            Debug.Log(this._rotation);
        }

        private void Movement()
        {
            this._rigidbody.AddRelativeForce(this._input * this.MovementSpeed);
            this._rigidbody.AddTorque(this.transform.up * this._rotation * this.RotationSpeed);
            // if (Mathf.Abs(this._rotation) > 0.01f)
            //     this.transform.Rotate(this.transform.up, this._rotation * this.RotationSpeed);
        }
    }
}