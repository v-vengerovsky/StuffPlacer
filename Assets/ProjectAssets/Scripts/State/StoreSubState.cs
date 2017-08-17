using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuffPlacer
{
	public class StoreSubState : SubStateBase
	{
		public StoreSubState() : base(Approot.Instance.SceneLoader.Scenes.Find(scene => scene.SceneName == "Store").SceneName)
		{
		}
	}
}
