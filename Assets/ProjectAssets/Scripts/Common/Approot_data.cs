using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace StuffPlacer
{
	public partial class Approot
	{
		[SerializeField]
		private SceneLoader _sceneLoader;

		public SceneLoader SceneLoader
		{
			get { return _sceneLoader; }
		}

		public string Title
		{
			get { return Constants.AppTitle; }
		}
	}
}
