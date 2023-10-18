using TestGame.Construction;
using UnityEngine;

namespace TestGame.Player
{
	public class PlayerConstructor : IConstructor
	{
		private readonly float _setElementDistance;
		
		private IElement _holdElement;
		private IElement _findElementSlot;

		public PlayerConstructor(float setElementDistance)
		{
			_setElementDistance = setElementDistance;
		}
		
		public void SetHoldElement(IElement holdElement)
		{
			_holdElement = holdElement;
		}

		public void SetElement()
		{
			_findElementSlot.SetActive(true);
		}

		public void FindElementForSet(Camera camera)
		{
			var ray = camera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
			if (Physics.Raycast(ray, out var hit, _setElementDistance))
			{
				if (hit.rigidbody != null && hit.rigidbody.TryGetComponent(out IElement element))
				{
					if (CanSetElement(_holdElement, element))
					{
						_findElementSlot?.SetActiveTooltip(false);
						_findElementSlot = element;
						_findElementSlot?.SetActiveTooltip(true);
					}
					
				}
				else
				{
					_findElementSlot?.SetActiveTooltip(false);
					_findElementSlot = null;
				}
			}
			else
			{
				_findElementSlot?.SetActiveTooltip(false);
				_findElementSlot = null;	
			}
		}

		public bool CanSetElement()
		{
			return CanSetElement(_holdElement, _findElementSlot);
		}

		private bool CanSetElement(IElement setElement, IElement slot)
		{
			return slot != null &&
			       slot.Parent != null &&
			       slot.Parent.View.Active &&
			       setElement != null &&
			       setElement.ElementData.Id == slot.ElementData.Id;
		}
	}
}