/**
 * Starting code taken from Nathan Bean's particle-system-example assignment from CIS 580 at K-State
 */

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CIS580_Project.Particles
{
    public interface IParticleEmitter
    {
        public Vector2 Position { get; }

        public Vector2 Velocity { get; }
    }
}
