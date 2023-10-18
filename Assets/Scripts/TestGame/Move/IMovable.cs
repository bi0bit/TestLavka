using UnityEngine;

namespace Game
{
	public interface IMovable
	{
		void Move(Vector3 moveDirection, float speed);
	}
}