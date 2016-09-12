/*
 * Created by SharpDevelop.
 * User: breakfast
 * Date: 12/09/2016
 * Time: 12:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Verse;
using RimWorld;
using System.Collections.Generic;

namespace KappaTwitchStoryteller
{
	
	/// <summary>
	/// Description of .
	/// </summary>
	/// 
	
	
	public class IncidentWorker_ViewerVote : IncidentWorker
	{
		private const float voteTime = 45.0f; // 45 sec for voting
		private const float mintickBetweenVote = 120.0f; // 2 minutes for next Vote
		
		private float lastTickVote;
		private bool voteActiv;
		private SimpleTimer voteTimer;
		private TimerTickFunc myFunc;
			
		public IncidentWorker_ViewerVote()
		{
			Log.Message("Incident worker creation");
			lastTickVote = 0.0f;
			voteActiv = false;
			voteTimer = ThingMaker.MakeThing(ThingDef.Named("VoteTimer")) as SimpleTimer;
			Find.TickManager.RegisterAllTickabilityFor(voteTimer);
			myFunc = timerTick;
		}
		
		protected override bool CanFireNowSub()
		{
			Log.Message("==================");
			
			if (voteActiv)
			{
				Log.Message("vote active");
				return false;
			}
			
			Log.Message("vote not active");

			
			return true;
		}
		
		public override bool TryExecute(IncidentParms parms)
		{
			if (voteActiv)
				return false;

			Log.Message("Start the vote");

			lastTickVote = Find.TickManager.TicksAbs.TicksToSeconds();
			voteActiv = true;
			
			if(voteTimer.add(myFunc))
				Log.Message("callback timer correctly added");
			
			VoteWindow voteW = new VoteWindow("test", "desc", "vote1", "vote2", "vote3");
			Find.WindowStack.Add(voteW);
			Log.Message("==================");
			return true;
		}
		
		
		void timerTick(int gameTickAbs)
		{
			Log.Message("test try execute");
			
			Log.Message("test try execute" + Find.TickManager.TicksAbs.TicksToSeconds() + "/"  +lastTickVote  + "/" + mintickBetweenVote);
			
			float delta = (Find.TickManager.TicksAbs.TicksToSeconds() - lastTickVote);
			
			if (delta >= voteTime) //Stop voting
			{
				Log.Message("Stop Vote");
				//todo
			}	
			else if(delta >= mintickBetweenVote) //reactive for next next vote
			{
				voteActiv = false;
				
				if(voteTimer.remove(myFunc))
					Log.Message("callback timer correctly removed");
			}
		}
	}
}
