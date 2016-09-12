/*
 * Created by SharpDevelop.
 * User: breakfast
 * Date: 10/09/2016
 * Time: 19:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using Verse;
using RimWorld;
using UnityEngine;

namespace KappaTwitchStoryteller
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class VoteWindow : Window
	{
		private string title;
		private string desc;
		
		private string vote1;
		private string vote2;
		private string vote3;
		private string voteRandom;
		
		public override Vector2 InitialSize {
		get {
			return new Vector2(500,600);
		}
}
		
		public VoteWindow(string _title, string _desc, string _vote1, string _vote2, string _vote3)
		{
			this.resizeable = true;
			this.draggable = true;
			this.forcePause = false;
			this.title = _title.Translate();
			this.desc = _desc.Translate();
			this.vote1 = _vote1.Translate();
			this.vote2 = _vote2.Translate();
			this.vote3 = _vote3.Translate();
			this.voteRandom = "random".Translate();
			
		}
		
		public override void DoWindowContents(Rect inRect)
		{
			Widgets.Label(new Rect(0f, 0f, windowRect.width, 100f), this.title);
			Widgets.Label(new Rect(0f, 100f, windowRect.width, 100f), this.desc);
			Widgets.Label(new Rect(0f, 200f, windowRect.width, 100f), this.vote1);
			Widgets.Label(new Rect(0f, 300f, windowRect.width, 100f), this.vote2);
			Widgets.Label(new Rect(0f, 400f, windowRect.width, 100f), this.vote3);
			Widgets.Label(new Rect(0f, 500f, windowRect.width, 100f), this.voteRandom);
		}
	

		
	}
}