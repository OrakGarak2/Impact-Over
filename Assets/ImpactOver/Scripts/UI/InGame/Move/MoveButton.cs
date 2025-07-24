// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ImpactOver.UI
{
    public enum MoveDirection
    {
        Left,
        Right    
    }

    public class MoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("플레이어")]
        [SerializeField] private Player.Player player;

        [Header("버튼 기능")]
        [SerializeField] private bool isPressed = false;
        [SerializeField] private MoveDirection moveDirection;
        public float MoveDirectionSign { get { return moveDirection == MoveDirection.Left ? -1f : 1f; } }

        [Header("스프라이트")]
        [SerializeField] Image image;
        [SerializeField] private Color originalColor;
        [SerializeField] private Color pressedColor;

        private void Start()
        {
            image = GetComponent<Image>();

            originalColor = image.color;
            pressedColor = GetColor(135, 159, 180, 190);
        }

        private Color GetColor(int r, int g, int b, int a)
        {
            float colorOffset = 255f;
            return new Color(r / colorOffset, g / colorOffset, b / colorOffset, a / colorOffset);
        }

        private void Update()
        {
            if (isPressed)
            {
                player.MovePositionX(MoveDirectionSign);
            }
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            isPressed = true;
            image.color = pressedColor;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            isPressed = false;
            image.color = originalColor;
        }
    }
}