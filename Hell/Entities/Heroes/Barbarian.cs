﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hell.Entities.Heroes
{
    public class Barbarian : AbstractHero
    {
        private const int InitialStrength = 90;
        private const int InitialAgility = 25;
        private const int InitialIntelligence = 10;
        private const int InitialHitPoints = 350;
        private const int InitialHitDamage = 150;

        public Barbarian(string name) : base(name, InitialStrength, InitialAgility, InitialIntelligence, InitialHitPoints, InitialHitDamage)
        {
        }
    }
}
