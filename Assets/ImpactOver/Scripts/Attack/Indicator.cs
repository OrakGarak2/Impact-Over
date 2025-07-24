// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;

namespace ImpactOver.Player.Attack
{
    public class Indicator : MonoBehaviour
    {
        public void ShowIndicator(Vector2 direction)
        {
            gameObject.SetActive(true);
            RotateIndicator(direction);
        }

        public void RotateIndicator(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public void HideIndicator()
        {
            gameObject.SetActive(false);
        }
    }
}