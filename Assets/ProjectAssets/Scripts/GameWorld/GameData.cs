using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using IPosNotifier = StuffPlacer.INotifier<UnityEngine.Vector3>;
//using IFloatNotifier = StuffPlacer.INotifier<float>;

namespace StuffPlacer
{
	public class GameData : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;
		[SerializeField]
		private Transform _bottomLeftEdge;
		[SerializeField]
		private Transform _topRightEdge;
		[SerializeField]
		private Terrain _terrain;
		[SerializeField]
		private GameObject _grid;
		[SerializeField]
		private GameObject _linePrefab;
		[SerializeField]
		private List<PlaceableObject> _placeables;

		private static GameData _instance;

		public static GameData Instance
		{
			get { return _instance; }
		}

		public Camera Camera { get { return _camera; } }
		public Transform BottomLeftEdge { get { return _bottomLeftEdge; } }
		public Transform TopRightEdge { get { return _topRightEdge; } }
		public Terrain Terrain { get { return _terrain; } }
		public GameObject Grid { get { return _grid; } }
		public GameObject LinePrefab { get { return _linePrefab; } }
		public List<PlaceableObject> Placeables { get { return _placeables; } }

		public void SetPosition(IPosNotifier notifier)
		{
			Vector3 position = notifier.Position;
			position.y = _camera.transform.position.y;
			_camera.transform.position = position;
		}

		private void Awake()
		{
			_instance = this;

		}
	}
}