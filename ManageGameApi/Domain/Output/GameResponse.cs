using ManageGameApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Output
{
    public class GameResponse : BaseResponse
    {
        public Game Game { get; private set; }

        public GameResponse(bool success, string message, Game game) : base(success, message)
        {
            Game = game;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="game">Saved game.</param>
        /// <returns>Response.</returns>
        public GameResponse(Game game) : this(true, string.Empty, game)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public GameResponse(string message) : this(false, message, null)
        { }

    }
}
