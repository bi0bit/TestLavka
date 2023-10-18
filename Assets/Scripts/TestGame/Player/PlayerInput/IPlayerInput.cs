using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Player.PlayerInput
{
	public interface IPlayerInput
	{
		Vector2 GetMoveDirection();

		Vector2 GetCameraMovement();
		
		void AddGrabListener(UnityAction onGrab);
	}
}