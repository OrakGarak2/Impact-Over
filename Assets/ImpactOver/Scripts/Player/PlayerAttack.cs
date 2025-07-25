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
    public partial class Player : MonoBehaviour
    {
        [Header("공격")]
        [SerializeField] protected Indicator indicator;
        protected Attack.Attack attack;

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
    }
}
