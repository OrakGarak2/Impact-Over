// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

// ImpactOver
using ImpactOver.Player.Attack;

namespace ImpactOver.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb2D;
        [SerializeField] protected Indicator indicator;
        [SerializeField] protected Attack.Attack attack;
        [SerializeField] protected float moveSpeed;

        protected virtual void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        public virtual void ShowIndicator(Vector2 direction)
        {
            indicator.ShowIndicator(direction);
        }

        public virtual void RotateIndicator(Vector2 direction)
        {
            indicator.RotateIndicator(direction);
        }

        public virtual void Attack(Vector2 direction)
        {
            // attack.Attack();
            indicator.HideIndicator();
        }

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