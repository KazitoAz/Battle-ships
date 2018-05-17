
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;
using System.Runtime.ExceptionServices;
using System.Security;

using System.Media;
using System.Runtime.InteropServices;

static class GameLogic
{
    [DllImport("winmm.dll")]
    public static extern bool PlaySound(String Filename, int Mod, int Flags);

    [HandleProcessCorruptedStateExceptions]
    [SecurityCritical]
    public static int Main()
    {


        //Opens a new Graphics Window
        SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);
        PlaySound(@"C:\Users\Battle-ships\GameTemplate\Resources\sounds\horrordrone1.wav", 0, 9);
        System.Media.SoundPlayer sp = new SoundPlayer();
        //sp.SoundLocation = @"E:\BattleShipsCS_2018\Resources\sounds\horrordrone_000000-000500.wav";
        //sp.PlayLooping();

        //Load Resources
        GameResources.LoadResources();

        SwinGame.PlayMusic(GameResources.GameMusic("Background"));
        



        //Game Loop
        do
        {
			GameController.HandleUserInput();
			GameController.DrawScreen();
		} while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));


        //Free Resources and Close Audio, to end the program.
        try {
            GameResources.FreeResources();
        } catch (Exception e)
        {
            System.Console.WriteLine("The following exception is due to .NET 4+");
            System.Console.WriteLine(e.Message);
            return 1;
        }

        return 0;
	}
}