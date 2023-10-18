using TestGame.Construction.Data;

namespace TestGame.Construction
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