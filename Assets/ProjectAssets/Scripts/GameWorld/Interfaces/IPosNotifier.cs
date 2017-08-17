using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StuffPlacer
{
	public interface IPosNotifier:INotifier
	{
		Vector3 Position { get; }
	}
}
