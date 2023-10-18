using Game.MoveImpl;
using Game.Player;
using Game.Player.PlayerInput;
using UnityEngine;

namespace Game
{
	public class GameSetup : MonoBehaviour
	{
		[SerializeField]
		private PlayerController _player;

		private IPlayerInput _playerInput;
		
		private void Awake()
		{
			Cursor.visible = false;
			
			SetupComponents();

			SetupPlayer();
		}

		private void SetupComponents()
		{
			_playerInput = GetComponentInChildren<IPlayerInput>();
		}

		private void SetupPlayer()
		{
			var moveImplementation = new ForwardMovement(_player.gameObject);
			var constructor = new PlayerConstructor(_player.Data.GrabDistance);
			_player.Init(_playerInput, moveImplementation, constructor);
		}
	}
}