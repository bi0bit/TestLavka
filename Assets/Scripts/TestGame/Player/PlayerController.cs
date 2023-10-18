using TestGame.Construction;
using TestGame.Grab;
using TestGame.Move;
using TestGame.Player.Data;
using TestGame.Player.PlayerInput;
using UnityEngine;

namespace TestGame.Player
{
	public class PlayerController : MonoBehaviour
	{
		[field: SerializeField] public PlayerSettingsData Data { get; private set; }

		[field: SerializeField] public Camera Camera { get; private set; }

		[SerializeField]
		private GameObject _takeSlot;

		public Vector3 MoveDirection => _moveDirection;

		public bool Grabbing => _takeSlot.transform.childCount > 0;

		private Vector2 _rotation;
		
		private Vector3 _moveDirection;

		private IMovable _moveImplementation;

		private IConstructor _constructor;

		private IPlayerInput _playerInput;

		public void Init(IPlayerInput playerInput, IMovable moveImplementation, IConstructor constructor)
		{
			_moveImplementation = moveImplementation;
			_constructor = constructor;
			_playerInput = playerInput;
			_playerInput.AddGrabListener(Grab);
		}

		private void Update()
		{
			Rotation(_playerInput.GetCameraMovement());
			Move(ref _moveDirection, _playerInput.GetMoveDirection());
			_constructor.FindElementForSet(Camera);
		}

		private void Move(ref Vector3 moveDirection, Vector2 newMoveDirection)
		{
			moveDirection.x = newMoveDirection.x;
			moveDirection.z = newMoveDirection.y;
			_moveImplementation.Move(moveDirection, Data.Speed);
		}

		private void Rotation(Vector3 cameraMoveDirection)
		{
			var cameraHorizontalRotation = cameraMoveDirection.x * Data.HSensity * Time.deltaTime;
			var cameraVerticalRotation = cameraMoveDirection.y * Data.VSensity * Time.deltaTime;
			_rotation.x += cameraHorizontalRotation;
			_rotation.y += cameraVerticalRotation;
			_rotation.y = Mathf.Clamp(_rotation.y, -Data.VerticalRotationLimit, Data.VerticalRotationLimit);
			var xQuaternion = Quaternion.AngleAxis(_rotation.x, Vector3.up);
			var yQuaternion = Quaternion.AngleAxis(_rotation.y, Vector3.left);
			Camera.transform.localRotation = yQuaternion;
			transform.localRotation =  xQuaternion;
		}

		private void Grab()
		{
			if (!Grabbing)
			{
				TryGrabSomething();
			}
			else
			{
				if (_constructor.CanSetElement())
				{
					_constructor.SetElement();
					Destroy(_takeSlot.transform.GetChild(0).gameObject);
				}
				else
				{
					var grabbingGrabable = _takeSlot.GetComponentInChildren<IGrabable>();
					grabbingGrabable?.Throw();
				}
				
			}
		}

		private void TryGrabSomething()
		{
			var ray = Camera.ViewportPointToRay(new Vector3(.5f, .5f, 0));
			if (!Physics.Raycast(ray, out var raycastHit, Data.GrabDistance)) 
				return;

			if (raycastHit.rigidbody == null || !raycastHit.rigidbody.TryGetComponent(out IGrabable grabable)) return;

			if (raycastHit.rigidbody != null && raycastHit.rigidbody.TryGetComponent(out IElement element))
			{
				_constructor.SetHoldElement(element);
			}
			
			grabable.Take(_takeSlot);
		}
	}
}