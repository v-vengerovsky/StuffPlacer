using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StuffPlacer
{
	public interface ISpawnItemSource<T> where T:Component
	{
		T GetItem();
	}
}
