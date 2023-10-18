using TestGame.Move.MoveImpl;
using TestGame.Player;
using TestGame.Player.PlayerInput;
using UnityEngine;

namespace TestGame
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