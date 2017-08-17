using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuffPlacer
{
	public abstract class SubStateBase
	{
		private string _sceneName;
		private ViewBase _viewBase;
		private bool _activated = false;

		public bool Activated { get { return _activated; } }

		public string SceneName
		{
			get { return _sceneName; }
		}

		public SubStateBase(string sceneName)
		{
			_sceneName = sceneName;
		}

		public virtual void OnActivate()
		{
			_viewBase = GetView();
			_viewBase.Title = Approot.Instance.Title;
			_activated = true;
		}

		public virtual void OnDeactivate()
		{
			_activated = false;
		}

		public virtual ViewBase GetView()
		{
			return null;
		}

		public virtual void Update()
		{

		}
	}
}
