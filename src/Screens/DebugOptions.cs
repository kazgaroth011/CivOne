// CivOne
//
// To the extent possible under law, the person who associated CC0 with
// CivOne has waived all copyright and related or neighboring rights
// to CivOne.
//
// You should have received a copy of the CC0 legalcode along with this
// work. If not, see <http://creativecommons.org/publicdomain/zero/1.0/>.

using System;
using System.Linq;
using CivOne.Enums;
using CivOne.Graphics;
using CivOne.Screens.Debug;
using CivOne.Graphics.Sprites;
using CivOne.Tasks;
using CivOne.UserInterface;

namespace CivOne.Screens
{
	internal class DebugOptions : BaseScreen
	{
		private bool _update = true;
		
		private void MenuCancel(object sender, EventArgs args)
		{
			Destroy();
		}

		private void MenuSetGameYear(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.Screen<SetGameYear>());
			Destroy();
		}

		private void MenuSetPlayerGold(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.Screen<SetPlayerGold>());
			Destroy();
		}

		private void MenuSetPlayerScience(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.Screen<SetPlayerScience>());
			Destroy();
		}

		private void MenuSetPlayerAdvances(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.Screen<SetPlayerAdvances>());
			Destroy();
		}

		private void MenuSetCitySize(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.Screen<SetCitySize>());
			Destroy();
		}

		private void MenuChangeHumanPlayer(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.Screen<ChangeHumanPlayer>());
			Destroy();
		}

		private void MenuSpawnUnit(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.Screen<SpawnUnit>());
			Destroy();
		}

		private void MenuMeetWithKing(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.Screen<MeetWithKing>());
			Destroy();
		}

		private void MenuRevealWorld(object sender, EventArgs args)
		{
			Settings.Instance.RevealWorldCheat();
			Destroy();
		}

		private void MenuBuildPalace(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.BuildPalace());
			Destroy();
		}

		private void MenuShowPowerGraph(object sender, EventArgs args)
		{
			GameTask.Enqueue(Show.Screen<PowerGraph>());
			Destroy();
		}

		protected override bool HasUpdate(uint gameTick)
		{
			if (_update)
			{
				_update = false;

				Picture menuGfx = new Picture(131, 103)
					.Tile(Pattern.PanelGrey)
					.DrawRectangle3D()
					.DrawText("Debug Options:", 0, 15, 4, 4)
					.As<Picture>();

				IBitmap menuBackground = menuGfx[2, 11, 128, 88].ColourReplace((7, 11), (22, 3));

				this.AddLayer(menuGfx, 25, 17);

				Menu menu = new Menu(Palette, menuBackground)
				{
					X = 27,
					Y = 28,
					MenuWidth = 127,
					ActiveColour = 11,
					TextColour = 5,
					DisabledColour = 3,
					FontId = 0,
					Indent = 8
				};
				menu.MissClick += MenuCancel;
				menu.Cancel += MenuCancel;

				menu.Items.Add("Set Game Year").OnSelect(MenuSetGameYear);
				menu.Items.Add("Set Player Gold").OnSelect(MenuSetPlayerGold);
				menu.Items.Add("Set Player Science").OnSelect(MenuSetPlayerScience);
				menu.Items.Add("Set Player Advances").OnSelect(MenuSetPlayerAdvances);
				menu.Items.Add("Set City Size").OnSelect(MenuSetCitySize);
				menu.Items.Add("Change Human Player").OnSelect(MenuChangeHumanPlayer);
				menu.Items.Add("Spawn Unit").OnSelect(MenuSpawnUnit);
				menu.Items.Add("Meet With King").OnSelect(MenuMeetWithKing);
				menu.Items.Add("Toggle Reveal World").OnSelect(MenuRevealWorld);
				menu.Items.Add("Build Palace").OnSelect(MenuBuildPalace);
				menu.Items.Add("Show PowerGraph").OnSelect(MenuShowPowerGraph);

				this.FillRectangle(24, 16, 105, menu.RowHeight * (menu.Items.Count + 1), 5);

				AddMenu(menu);
			}
			return true;
		}

		public DebugOptions() : base(MouseCursor.Pointer)
		{
			Palette = Common.DefaultPalette;
			this.AddLayer(Common.Screens.Last(), 0, 0)
				.FillRectangle(24, 16, 133, 105, 5);
		}
	}
}