using UnityEngine;
using UnityEngine.Events;

namespace TestGame.Player.PlayerInput
{
	public interface IPlayerInput
	{
		Vector2 GetMoveDirection();

		Vector2 GetCameraMovement();
		
		void AddGrabListener(UnityAction onGrab);
	}
}