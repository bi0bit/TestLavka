using System;
using UnityEngine;

namespace Game.Grab
{
	[RequireComponent(typeof(Rigidbody))]
	public class GrabableObject : MonoBehaviour, IGrabable
	{
		private Rigidbody _rigidbody;
		
		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void Take(GameObject takeSlot)
		{
			_rigidbody.isKinematic = true;
			_rigidbody.detectCollisions = false;
			transform.SetParent(takeSlot.transform, true);
			transform.localPosition = Vector3.zero;
			transform.localRotation = takeSlot.transform.localRotation;

		}

		public void Throw()
		{
			_rigidbody.isKinematic = false;
			_rigidbody.detectCollisions = true;
			transform.parent = null;
		}
	}
}