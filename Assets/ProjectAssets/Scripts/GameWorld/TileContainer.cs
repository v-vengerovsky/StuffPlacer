using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StuffPlacer
{
	public class TileContainer
	{
		private GameData _gameData;
		private PlaceableObject[,] _placedObjects;
		private List<PlaceableObject> _placedObjectList;
		private float _maxHeightTerrain;

		private Vector3 BottomLeftEdge { get { return _gameData.BottomLeftEdge.position; } }
		private Vector3 TopRightEdge { get { return _gameData.TopRightEdge.position; } }

		public bool GridVisible
		{
			get { return _gameData.Grid.activeSelf; }
			set
			{
				_gameData.Grid.SetActive(value);
			}
		}

		public TileContainer(GameData gamedata)
		{
			_placedObjects = new PlaceableObject[Constants.xTileCount,Constants.yTileCount];
			_placedObjectList = new List<PlaceableObject>();
			_gameData = gamedata;
			_maxHeightTerrain = GetMaxHeight(_gameData.Terrain);
			InstantiateGrid();

		}

		public bool TestObjectPlace(PlaceableObject placeableObject, Vector3 pos)
		{
			return TestObjectPlace(placeableObject, GetCenter(pos));
		}

		public bool AddObject(PlaceableObject placeableObject, Vector3 pos)
		{
			Place center = GetCenter(pos);

			if (!TestObjectPlace(placeableObject, center))
			{
				return false;
			}

			PlaceableObject placedObject = placeableObject.Clone();

			foreach (var item in placedObject.Places)
			{
				SetPO(center + item - placedObject.Center, placedObject);
			}

			_placedObjectList.Add(placedObject);
			PlaceObject(placedObject);

			return true;
		}

		private bool TestObjectPlace(PlaceableObject placeableObject, Place center)
		{
			foreach (var item in placeableObject.Places)
			{
				if (GetPO(center + item - placeableObject.Center) != null)
				{
					return false;
				}
			}

			return true;
		}

		private Place GetCenter(Vector3 pos)
		{
			Vector3 range = TopRightEdge - BottomLeftEdge;
			Vector3 centerPos = pos - BottomLeftEdge;
			Place center = new Place(centerPos.x / range.x * _placedObjects.GetLength(0), centerPos.y / range.y * _placedObjects.GetLength(1));

			return center;
		}

		private PlaceableObject GetPO(Place place)
		{
			return _placedObjects[place.X, place.Y];
		}

		private void SetPO(Place place, PlaceableObject po)
		{
			_placedObjects[place.X, place.Y] = po;
		}

		private void PlaceObject(PlaceableObject placeableObject)
		{
			GameObject go = placeableObject.Instantiate();
		}

		private void InstantiateGrid()
		{
			Vector3 range = TopRightEdge - BottomLeftEdge;
			Vector3 start = BottomLeftEdge;
			start.x += range.x / 2;
			start.y += _maxHeightTerrain;
			Vector3 end = TopRightEdge;
			end.x -= range.x / 2;
			end.y += _maxHeightTerrain;
			int count = _placedObjects.GetLength(0);
			Vector3 scale = _gameData.BottomLeftEdge.localScale;
			scale.x = range.x;

			InstantiateAxis(start,end,count,_gameData.BottomLeftEdge.rotation, scale, _gameData.Grid.transform);

			start = BottomLeftEdge;
			start.z += range.z / 2;
			start.y += _maxHeightTerrain;
			end = TopRightEdge;
			end.z -= range.z / 2;
			end.y += _maxHeightTerrain;
			count = _placedObjects.GetLength(1);
			scale = _gameData.TopRightEdge.localScale;
			scale.y = range.z;

			InstantiateAxis(start, end, count, _gameData.TopRightEdge.rotation, scale, _gameData.Grid.transform);
		}

		private void InstantiateAxis(Vector3 start, Vector3 end, int count, Quaternion rotation, Vector3 scale, Transform parent)
		{
			for (int i = 0; i <= count; i++)
			{
				GameObject line = GameObject.Instantiate(_gameData.LinePrefab);
				line.transform.position = Vector3.Lerp(start, end, (float)i / count);
				line.transform.rotation = rotation;
				line.transform.localScale = scale;
				line.transform.SetParent(parent);
			}
		}

		private float GetMaxHeight(Terrain terrain)
		{
			var heightMap = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapWidth, terrain.terrainData.heightmapHeight);

			float maxHeight = float.MinValue;

			foreach (var item in heightMap)
			{
				if (maxHeight < item)
				{
					maxHeight = item;
				}
			}

			maxHeight *= terrain.terrainData.size.y;

			return maxHeight;
		}
	}
}
