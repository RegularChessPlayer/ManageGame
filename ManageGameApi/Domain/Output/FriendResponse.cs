using ManageGameApi.Domain.Entities;

namespace ManageGameApi.Domain.Output
{
    public class FriendResponse : BaseResponse
    {
        public Friend Friend { get; private set; }

        public FriendResponse(bool success, string message, Friend friend) : base(success, message)
        {
            Friend = friend;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="friend">Saved friend.</param>
        /// <returns>Response.</returns>
        public FriendResponse(Friend friend) : this(true, string.Empty, friend)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public FriendResponse(string message) : this(false, message, null)
        { }

    }
}
