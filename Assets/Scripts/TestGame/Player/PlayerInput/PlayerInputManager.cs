using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Player.PlayerInput
{
	public class PlayerInputManager : MonoBehaviour, IPlayerInput
	{
		[SerializeField] private UnityEvent _onGrabEvent;
		
		public Vector2 GetMoveDirection()
		{
			var xDirection = Input.GetAxis("Horizontal");
			var yDirection = Input.GetAxis("Vertical");
			return new Vector2(xDirection, yDirection);
		}

		public Vector2 GetCameraMovement()
		{
			var xDirection = Input.GetAxis("Mouse X");
			var yDirection = Input.GetAxis("Mouse Y");
			return new Vector2(xDirection, yDirection);
		}

		public void AddGrabListener(UnityAction onGrab)
		{
			_onGrabEvent.AddListener(onGrab);
		}

		private void Update()
		{
			if (Input.GetButtonDown("Fire1"))
			{
				_onGrabEvent.Invoke();
			}
		}
	}
}