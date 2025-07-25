// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

namespace ImpactOver.Player
{
    public partial class Player : MonoBehaviour
    {
        [Header("이동")]
        [SerializeField] protected Rigidbody2D rb2D;
        [SerializeField] protected float moveSpeed;

        public virtual void MovePositionX(float moveDirectionX)
        {
            Vector2 newPos = rb2D.position;
            newPos.x += moveDirectionX * moveSpeed * Time.deltaTime;
            rb2D.MovePosition(newPos);
        }

        public virtual void AddForce(Vector2 force)
        {
            rb2D.linearVelocity = Vector2.zero;

            rb2D.AddForce(force, ForceMode2D.Impulse);
        }
    }
}