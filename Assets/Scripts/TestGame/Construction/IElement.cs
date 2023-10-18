using Game.Player.Data.Construction;
using UnityEngine;

namespace Game.Container
{
	public interface IElement
	{
		ConstructionElementData ElementData { get; }
		
		IElementView View { get; }
		
		IElement Parent { get; }
		
		void SetActive(bool active);
		
		void SetActiveTooltip(bool active);
	}
}