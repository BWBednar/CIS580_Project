/**
 * Starting code taken from Nathan Bean's particle-system-example assignment from CIS 580 at K-State
 */

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CIS580_Project
{
    /// <summary>
    /// Class for fireworks using the explosion image, uses the alpha coloring for it
    /// </summary>
    public class ExplosionFireworkParticleSystem : ParticleSystem
    {
        
        Color[] colors = new Color[]
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Purple
        };

        Color color;
        public ExplosionFireworkParticleSystem(Game game, int maxExplosions) : base (game, maxExplosions * 40)
        {

        }

        protected override void InitializeConstants()
        {
            textureFilename = "explosion1";
            minNumParticles = 20;
            maxNumParticles = 40;
            blendState = BlendState.Additive;
            DrawOrder = AdditiveBlendDrawOrder;
        }

        protected override void InitializeParticle(ref Particle p, Vector2 where)
        {
            var velocity = RandomHelper.NextDirection() * RandomHelper.NextFloat(40, 200);
            var lifetime = RandomHelper.NextFloat(0.5f, 1.0f);
            var acceleration = -velocity / lifetime;
            var rotation = RandomHelper.NextFloat(0, MathHelper.TwoPi);
            var angularVelocity = RandomHelper.NextFloat(-MathHelper.PiOver4, MathHelper.PiOver4);
            var scale = RandomHelper.NextFloat(4, 6);

            p.Initialize(where, velocity, acceleration, color, lifetime: lifetime, rotation: rotation, angularVelocity: angularVelocity, scale: scale);
        }

        protected override void UpdateParticle(ref Particle particle, float dt)
        {
            base.UpdateParticle(ref particle, dt);

            float normalizedLifetime = particle.TimeSinceStart / particle.Lifetime;
            float alpha = 4 * normalizedLifetime * (1 - normalizedLifetime);
            particle.Color = Color.White * alpha;
            particle.Scale = 0.3f + 0.25f * normalizedLifetime;
        }

        public void PlaceFirework(Vector2 where)
        {
            color = colors[RandomHelper.Next(colors.Length)];
            AddParticles(where);
        }
    }

}
