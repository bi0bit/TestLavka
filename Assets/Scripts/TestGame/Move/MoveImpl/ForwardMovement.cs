using UnityEngine;

namespace TestGame.Move.MoveImpl
{
	public class ForwardMovement : IMovable
	{
		private GameObject _movableObject;
		
		public ForwardMovement(GameObject movableObject)
		{
			_movableObject = movableObject;
		}
		
		public void Move(Vector3 moveDirection, float speed)
		{
			var directionByForward =
				_movableObject.transform.forward * moveDirection.z +
				_movableObject.transform.right * moveDirection.x +
				_movableObject.transform.up * moveDirection.y;
			_movableObject.transform.position += directionByForward * speed * Time.deltaTime;
		}
	}
}