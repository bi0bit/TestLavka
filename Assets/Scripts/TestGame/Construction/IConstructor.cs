using UnityEngine;

namespace TestGame.Construction
{
	public interface IConstructor
	{
		void SetHoldElement(IElement holdElement);
		
		void SetElement();

		void FindElementForSet(Camera camera);

		bool CanSetElement();
	}
}