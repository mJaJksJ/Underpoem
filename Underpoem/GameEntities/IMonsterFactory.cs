using System;
using System.Collections.Generic;
using System.Text;

namespace Underpoem.GameEntities
{
    interface IMonsterFactory
    {
        /// <summary>
        /// Factory should create monster
        /// </summary>
        /// <returns>new object of IMonster</returns>
        IMonster Create();
    }
}
