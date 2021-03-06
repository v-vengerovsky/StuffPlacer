﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuffPlacer
{
	public interface INotifierEvent<T> where T : INotifier
	{
		event Action<T> OnNotify;
	}
}
