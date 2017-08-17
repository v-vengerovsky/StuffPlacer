using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StuffPlacer
{
	[Serializable]
	public struct Place
	{
		[SerializeField]
		private int _x;
		[SerializeField]
		private int _y;

		public int X { get { return _x; } }
		public int Y { get { return _y; } }

		public Place(int x, int y)
		{
			_x = x;
			_y = y;
		}

		public Place(float x, float y)
		{
			_x = Mathf.FloorToInt(x);
			_y = Mathf.FloorToInt(y);
		}

		public Vector2 ToV2()
		{
			return new Vector2(_x,_y);
		}

		public static Place operator + (Place p1, Place p2)
		{
			return new Place(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Place operator - (Place p1, Place p2)
		{
			return new Place(p1.X - p2.X, p1.Y - p2.Y);
		}

		public static implicit operator Vector2(Place place)
		{
			return place.ToV2();
		}

		public static explicit operator Place(Vector2 v2)
		{
			return new Place(Mathf.FloorToInt(v2.x), Mathf.FloorToInt(v2.y));
		}
	}
}
