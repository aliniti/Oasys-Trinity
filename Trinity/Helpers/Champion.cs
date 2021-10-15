#region Copyright © 2021 Kurisu Solutions
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//       Document:	Helpers\Champion.cs
//       Date:		10/14/2021
//       Author:	Robin Kurisu
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see http://www.gnu.org/licenses/
#endregion

namespace Trinity.Helpers
{
    using System.Collections.Generic;
    using Oasys.Common.GameObject.Clients;

    public class Champion
    {
        /// <summary>
        /// The champion instance
        /// </summary>
        public AIHeroClient Instance { get; set; }

        /// <summary>
        /// The aura info dictionary
        /// </summary>
        public Dictionary<string, int> AuraInfo;

        /// <summary>
        /// Creates the champion object.
        /// </summary>
        /// <param name="hero"></param>
        public Champion(AIHeroClient hero)
        {
            Instance = hero;
            AuraInfo = new Dictionary<string, int>();
        }
    }
}
