using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
//using IPosNotifier = StuffPlacer.INotifier<UnityEngine.Vector3>;
//using IFloatNotifier = StuffPlacer.INotifier<float>;

namespace StuffPlacer
{
	public interface IEnemyNotifiable<T> where T: INotifier
	{
		void OnSpawn(T enemy);
		void OnDestroy(T enemy, ICollidable other);
		void Notify(T enemy);
	}
}
