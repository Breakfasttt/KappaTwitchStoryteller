/*
 * Created by SharpDevelop.
 * User: breakfast
 * Date: 12/09/2016
 * Time: 22:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace KappaTwitchStoryteller
{
	
	public delegate void TimerTickFunc(int gameTickAbs);
	
	/// <summary>
	/// Description of SimpleTimer.
	/// </summary>
	public class SimpleTimer : Thing
	{
		
		List<TimerTickFunc> callbackList;
		
		public SimpleTimer()
		{
			callbackList = new List<TimerTickFunc>();
		}
		
		public bool add(TimerTickFunc toAdd)
		{
			if(callbackList.Contains(toAdd))
				return false;
			
			callbackList.Add(toAdd);
			return true;
		}
		
		
		public bool remove(TimerTickFunc toRemove)
		{
			if(!callbackList.Contains(toRemove))
				return false;
			
			callbackList.Remove(toRemove);
			return true;
		}
		
		public override void Tick()
		{
			for(int i = 0; i < callbackList.Count; i++)
			{
				callbackList[i](Find.TickManager.TicksAbs);
			}
		}
		
	}
}
