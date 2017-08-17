using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StuffPlacer
{
	public partial class Approot
	{
		private StateBase _currentState;
		private Stack<StateBase> _states = new Stack<StateBase>();
		private SubStateBase _currentSubState;
		private Stack<SubStateBase> _subStates = new Stack<SubStateBase>();

		public void PushState(StateBase state)
		{
			if (_currentState != null)
			{
				_currentState.OnDeactivate();
			}

			_states.Push(_currentState);
			_currentState = state;
			PrepareState(_currentState);
		}

		public void SetState(StateBase state)
		{
			if (_currentState != null)
			{
				_currentState.OnDeactivate();
			}

			_states.Clear();
			_currentState = state;
			PrepareState(_currentState);
		}

		public void PopState()
		{
			_currentState.OnDeactivate();
			_currentState = _states.Pop();
			PrepareState(_currentState);
		}

		private void PrepareState(StateBase state)
		{
			SceneLoader.LoadScene(state.SceneName, state.OnActivate);

			//clears all substates
			SetSubState(null);
		}

		public void PushSubState(SubStateBase subState)
		{
			if (_currentSubState != null)
			{
				_currentSubState.OnDeactivate();
			}

			_subStates.Push(_currentSubState);
			_currentSubState = subState;
			PrepareSubState(_currentSubState);
		}

		public void SetSubState(SubStateBase subState)
		{
			if (_currentSubState != null)
			{
				_currentSubState.OnDeactivate();
			}

			_subStates.Clear();
			_currentSubState = subState;
			PrepareSubState(_currentSubState);
		}

		public void PopSubState()
		{
			_currentSubState.OnDeactivate();
			_currentSubState = _subStates.Pop();
			PrepareSubState(_currentSubState);
		}

		private void PrepareSubState(SubStateBase subState)
		{
			if (subState != null)
			{
				SceneLoader.LoadScene(subState.SceneName, subState.OnActivate, false);
			}
		}
	}
}