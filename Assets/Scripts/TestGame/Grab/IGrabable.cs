using UnityEngine;

namespace Game.Grab
{
	public interface IGrabable
	{
		void Take(GameObject takeSlot);
		void Throw();
	}
}