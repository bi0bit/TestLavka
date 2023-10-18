using UnityEngine;

namespace Game.Container
{
	public interface IElementView
	{
		bool Active { get; }
		
		void SetActive(bool active);
		
		void SetColor(Color color);
	}
}