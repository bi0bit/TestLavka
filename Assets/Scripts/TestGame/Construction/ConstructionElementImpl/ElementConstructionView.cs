using UnityEngine;

namespace TestGame.Construction.ConstructionElementImpl
{
	[RequireComponent(typeof(Renderer))]
	public class ElementConstructionView : MonoBehaviour, IElementView
	{
		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private Renderer _renderer;

		private void Awake()
		{
			_renderer = GetComponent<Renderer>();
		}

		public bool Active => _renderer != null && _renderer.enabled;

		public void SetActive(bool active)
		{
			_renderer.enabled = active;
		}

		public void SetColor(Color color)
		{
			if (_renderer == null) return;
			
			_renderer.material.SetColor(Color1, color);
		}
	}
}