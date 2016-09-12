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

namespace KappaTwitchStoryteller
{
	/// <summary>
	/// Description of .
	/// </summary>
	public class IncidentWorker_ViewerVote : IncidentWorker
	{
		public override bool TryExecute(IncidentParms parms)
		{
			VoteWindow voteW = new VoteWindow("test", "desc","vote1", "vote2", "vote3");
			Find.WindowStack.Add(voteW);
			return true;
		}
	}
}
