﻿/**
 * Starting Code from Nathan Bean's GameArchitectureExample project
 */

using System;
using Microsoft.Xna.Framework;

namespace CIS580_Project.Screens
{
    // Custom event argument which includes the index of the player who
    // triggered the event. This is used by the MenuEntry.Selected event.
    public class PlayerIndexEventArgs : EventArgs
    {
        public PlayerIndex PlayerIndex { get; }

        public PlayerIndexEventArgs(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
        }
    }
}