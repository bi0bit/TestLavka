using UnityEngine;

namespace Game.Container
{
	public interface IConstructor
	{
		void SetHoldElement(IElement holdElement);
		
		void SetElement();

		void FindElementForSet(Camera camera);

		bool CanSetElement();
	}
}