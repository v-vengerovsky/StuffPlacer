using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using IEnemyPosNotifiable = StuffPlacer.IEnemyNotifiable<StuffPlacer.IPlayerNotifier>;

namespace StuffPlacer
{
	public class GameWorld
	{
		private GameData _gameData;
		private TileContainer _tiles;

		public GameWorld(GameData gameData)
		{
			_gameData = gameData;
			_tiles = new TileContainer(_gameData);
		}

		public void Update()
		{
		}

		public void Dispose()
		{
		}

		private void Lost()
		{
		}

	}
}