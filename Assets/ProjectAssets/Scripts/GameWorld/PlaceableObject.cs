using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StuffPlacer
{
	[Serializable]
	public class PlaceableObject
	{
		[SerializeField]
		private string _name;
		[SerializeField]
		private GameObject _prefab;
		[SerializeField]
		private Place[] _places;

		private Place _center;

		private GameObject _placedObject;

		public string Name { get { return _name; } }
		public Place[] Places { get { return _places; } }
		public Place Center { get { return _center; } }

		public PlaceableObject(string name, GameObject prefab, Place[] places)
		{
			_name = name;
			_prefab = prefab;
			_places = places;

			Vector2 temp = default(Vector2);

			foreach (var item in places)
			{
				temp += item;
			}

			temp *= 1f / places.Length;
			_center = (Place)temp;
		}

		public GameObject Instantiate()
		{
			if (_placedObject == null)
			{
				_placedObject = GameObject.Instantiate(_prefab);
			}

			return _placedObject;
		}

		public PlaceableObject Clone()
		{
			return new PlaceableObject(_name, _prefab, _places);
		}
	}
}
