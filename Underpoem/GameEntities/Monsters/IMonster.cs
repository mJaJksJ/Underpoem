using System;
using System.Collections.Generic;
using System.Text;

namespace Underpoem.GameEntities
{
    interface IMonster: IUpdatable
    {
        /// <summary>
        /// every monster is different
        /// </summary>
        string Ip { get; set; }

        /// <summary>
        /// every monster should move (even if moving is staying)
        /// </summary>
        void Move();

        /// <summary>
        /// every monster should die
        /// </summary>
        void Die();
    }
}
