using UnityEngine;

namespace TestGame.Construction
{
	public interface IElementView
	{
		bool Active { get; }
		
		void SetActive(bool active);
		
		void SetColor(Color color);
	}
}