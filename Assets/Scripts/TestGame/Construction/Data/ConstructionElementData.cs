using UnityEngine;

namespace TestGame.Construction.Data
{
	[CreateAssetMenu(fileName = "ElementData", menuName = "GameData/ConstructionElementData", order = 0)]
	public class ConstructionElementData : ScriptableObject
	{
		[field: SerializeField] public string Id { get; private set; }
		
		[field: SerializeField] public Color Color { get; private set; }
	}
}