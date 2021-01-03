using ManageGameApi.Domain.Entities;

namespace ManageGameApi.Domain.Output
{
    public class LocateGameResponse : BaseResponse
    {
        public LocateGame LocateGame{ get; set; }

        public LocateGameResponse(bool success, string message, LocateGame locateGame) : base(success, message)
        {

        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="LocateGame">Saved locate Game.</param>
        /// <returns>Response.</returns>
        public LocateGameResponse(LocateGame locateGame) : this(true, string.Empty, locateGame)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public LocateGameResponse(string message) : this(false, message, null)
        { }

    }
}
