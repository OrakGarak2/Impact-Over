// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ImpactOver.UI
{
    public class AttackJoystick : VirtualJoystick
    {
        [SerializeField] private Player.Player player;
        [SerializeField] private float cooldown = 0.5f;
        [SerializeField] private bool isCooldown;

        [SerializeField] private Image iconImage;

        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (isCooldown) { return; }

            base.OnBeginDrag(eventData);

            player.ShowIndicator(leverDirection);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (isCooldown) { return; }

            base.OnDrag(eventData);

            player.RotateIndicator(leverDirection);                
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (isCooldown) { return; }

            base.OnEndDrag(eventData);

            player.Attack(leverDirection);
            StartCoroutine(CooldownCoroutine());
        }

        private IEnumerator CooldownCoroutine()
        {
            isCooldown = true;

            float timer = 0f;
            while (timer <= cooldown)
            {
                iconImage.fillAmount = timer / cooldown;
                timer += Time.deltaTime;

                yield return null;
            }

            iconImage.fillAmount = 1f;

            isCooldown = false;
        }
    }
}