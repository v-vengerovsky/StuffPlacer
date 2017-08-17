using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StuffPlacer
{
	public abstract class ViewBase : MonoBehaviour
	{
		[SerializeField]
		private Text _titleText;

		public string Title
		{
			get
			{
				if (_titleText == null)
				{
					return _titleText.text;
				}

				return string.Empty;
			}
			set
			{
				if (_titleText != null)
				{
					_titleText.text = value;
				}
			}
		}
	}
}