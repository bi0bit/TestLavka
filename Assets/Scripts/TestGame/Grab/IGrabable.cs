using UnityEngine;

namespace TestGame.Grab
{
	public interface IGrabable
	{
		void Take(GameObject takeSlot);
		void Throw();
	}
}