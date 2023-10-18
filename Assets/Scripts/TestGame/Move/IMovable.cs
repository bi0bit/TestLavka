using UnityEngine;

namespace TestGame.Move
{
	public interface IMovable
	{
		void Move(Vector3 moveDirection, float speed);
	}
}