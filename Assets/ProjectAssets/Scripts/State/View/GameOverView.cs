﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StuffPlacer
{
	public class GameOverView : ViewBase
	{
		[SerializeField]
		private Button _restartBtn;
		[SerializeField]
		private Text _scoreText;

		private int _score;

		private event Action _onRestartPressed;

		public event Action OnRestartPressed
		{
			add { _onRestartPressed += value; }
			remove { _onRestartPressed -= value; }
		}

		public int Score
		{
			get { return _score; }
			set
			{
				_score = value;
				//_scoreText.text = string.Format(Constants.GameOverScoreFormat, value);
			}
		}

		private void Awake()
		{
			_restartBtn.onClick.AddListener(RestartPressed);
		}

		private void RestartPressed()
		{
			if (_onRestartPressed != null)
			{
				_onRestartPressed.Invoke();
			}
		}
	}
}