using TestGame.Construction.Data;
using UnityEngine;

namespace TestGame.Construction.ConstructionElementImpl
{
	public class ElementConstruction : MonoBehaviour, IElement
	{
		private static readonly Color TooltipColor = Color.green;

		[field: SerializeField] public ConstructionElementData ElementData { get; private set; }
		
		[field: SerializeField] public IElementView View { get; private set; }
		
		[field: SerializeField] public IElement Parent { get; private set; }

		private bool _isSet;

		private void Awake()
		{
			_isSet = false;
			if (transform.parent != null && transform.parent.TryGetComponent(out IElement parentElement))
			{
				Parent = parentElement;
			}
			
			View = GetComponentInChildren<IElementView>();
			View.SetColor(ElementData.Color);
		}

		public void SetActive(bool active)
		{
			View.SetActive(active);
			View.SetColor(ElementData.Color);
			_isSet = active;
		}

		public void SetActiveTooltip(bool active)
		{
			if (_isSet) return;
			
			View.SetActive(active);
			if (active)
			{
				View.SetColor(TooltipColor);
			}
		}
	}
}