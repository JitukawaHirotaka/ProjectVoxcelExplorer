using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// InGameDisplayDebugEvent class
/// </summary>
public class InGameDisplayDebugEvent : DisplayDebugEventBase
{
	[SerializeField]
	private InGameDisplay _titleDisplay;

	public override void OnAwake()
	{
		InGameEvents e = _titleDisplay._events;

		debugEvents
			.eventList = new List<DisplayDebugger.DebugEvents.Element>()
			{

			};
	}
}