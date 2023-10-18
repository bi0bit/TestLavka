using UnityEngine;

namespace TestGame.Player.Data
{
	[CreateAssetMenu(fileName = "PlayerSettings", menuName = "GameData/Player", order = 0)]
	public class PlayerSettingsData : ScriptableObject
	{
		[field: SerializeField] public float GrabDistance { get; private set; }

		[field: SerializeField] public float Speed { get; private set; }
		
		[field: SerializeField] public float HSensity { get; private set; }
		
		[field: SerializeField] public float VSensity { get; private set; }
		
		[field: SerializeField] public float VerticalRotationLimit { get; private set; }
	}
}